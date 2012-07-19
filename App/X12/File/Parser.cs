using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X12.DpoPackage;
using X12.DpoClass;
using X12.Specification;
using Sys;
using Tie;

namespace X12.File
{
    class Parser : BaseParser
    {
        protected Spec5010A spec;
        private NTree<LoopTemplateDpo> director;
        
        private Memory DS = new Memory();
        private Worker worker;
        public readonly MessageBuilder Messages = new MessageBuilder();

        public Parser(List<SegmentLine> segmentLines, Worker worker)
            :base(segmentLines)
        {
            this.worker = worker;

            this.spec = Spec5010A.Instance;

        
            this.director = this.spec.GetLoopTemplateTree();

            GlobalVariables();
        }


        /// <summary>
        /// Global variables
        ///     1.define all segment names
        /// </summary>
        private void GlobalVariables()
        {
            
            //All Segment Names in 5010A
            string[] segmentNames = spec.GetSegmentTemplates().Select(segment => segment.Name).Distinct().ToArray();
            foreach (string segmentName in segmentNames)
            {
                SegmentName name = new SegmentName(segmentName);
                DS.AddHostObject(segmentName, name);
            }
        }


     
     


        protected override bool HierarchicalTransaction()
        {
            bool result = parseLoops(director.Nodes, consumer.Nodes);

            //display where error occurs:
            if (this.Line < segmentLines.Count())
            {
                TreeNode<LoopLine> cnode = new TreeNode<LoopLine>(new LoopLine(new LoopName("ERROR")));
                int start = Math.Max(this.Line, 0);
                for(int i = start; i<segmentLines.Count() - 3; i++)
                    cnode.Item.Segments.Add(segmentLines[i]);

                consumer.Nodes.Add(cnode);
            }
            else
                Messages.Clear();

            base.HierarchicalTransaction();
            return false;
        }


        private bool parseLoops(TreeNodeCollection<LoopTemplateDpo> dnodes, TreeNodeCollection<LoopLine> cnodes)
        {
            bool result = false;

            foreach (TreeNode<LoopTemplateDpo> dnode in dnodes)
            {
                LoopTemplateDpo loop = dnode.Item;

                TreeNode<LoopLine> cnode = new TreeNode<LoopLine>(new LoopLine(new LoopName(loop.Name)));
                result = parseLoop(dnode, cnode);

                this.consumerNode = cnode;
                AddConsumerNode(cnodes, cnode);
            }

            return result;
        }

        private static void AddConsumerNode(TreeNodeCollection<LoopLine> cnodes, TreeNode<LoopLine> cnode)
        {

            if (cnode.Nodes.Count != 0 || cnode.Item.Segments.Count != 0)
                cnodes.Add(cnode);

        }

        private bool parseLoop(TreeNode<LoopTemplateDpo> dnode, TreeNode<LoopLine> cnode)
        {
            LoopTemplateDpo loop = dnode.Item;
            SegmentInstanceDpo[] segments = this.spec.GetSegmentInstances(loop);
            this.directorNode = dnode;

            bool result = parseLoop(dnode, cnode, segments);

            //Breadth-First Search(BFS)
            //e.g. serach: (ST/.../SE) (ST/.../SE) (ST/.../SE)
            if (loop.MaxRepeat != -1)
            {
                for (int i = 0; i < loop.MaxRepeat; i++)
                    if (!parseLoops(dnode.Nodes, cnode.Nodes))
                        break;
            }
            else
                while(parseLoops(dnode.Nodes, cnode.Nodes));

            return result;
        }

        private bool parseLoop(TreeNode<LoopTemplateDpo> dnode, TreeNode<LoopLine> cnode, SegmentInstanceDpo[] segments)
        {
            LoopTemplateDpo loop = dnode.Item;
            
            int keep = this.Line;
            for (int i = 0; i < segments.Length; i++)
            {
                if (!repeatParseSegment(segments[i], cnode) && segments[i].Required)
                {
                
                    return false;
                }

              
            }
            
            return true;
        }

        private bool repeatParseSegment(SegmentInstanceDpo segment, TreeNode<LoopLine> cnode)
        {
            bool result = false;

            for (int i = 0; i < segment.RepeatValue; i++)
            {
                //the 1st segment is required, the 2nd and after are optional even this segment is requred
                if (i == 0 && segment.Required)
                {
                    if (parseSegment(segment, true))
                    {
                        cnode.Item.Segments.Add(this.CurrentSegmentLine);
                        NextLine();
                        result = true;
                    }
                    else
                    {
                        //too many error messages because some required rule is not really required e.g. segment = N3
                        //if (segment.RepeatValue == 1)
                        //{
                        //    string message = string.Format("Required Segment={0} in {1}", segment, CurrentLoopTemplate.Name);
                        //    ErrorMessage.Error(this.Line + 1, message);
                        //}
                        return false;
                    }
                }
                else
                {
                    if (parseSegment(segment, false))
                    {
                        cnode.Item.Segments.Add(this.CurrentSegmentLine);
                        NextLine();
                        result = true;
                    }
                    return false;
                }
            }

            return result;
        }


        private bool parseSegment(SegmentInstanceDpo segment, bool required)
        {
            string message;
            if (IsSegmentName(segment.Name))
            {
                if (!segment.ValidElementCode(CurrentSegmentLine, out message))
                {
                    message = string.Format("{0}, {1}", message, this.CurrentLoopTemplate);
                    Messages.Add(Message.Warning(message).At(new MessageLocation(this.Line + 1)));
                    return false;
                }

                if (this.worker != null)
                {
                    if ((this.Line + 1) % 100 == 0)
                        this.worker.SetProgress(string.Format("{0}/{1} completed", this.Line + 1, segmentLines.Count));
                }

                SetResult(segment);
                return true;
            }

            return false;
        }


        private void SetResult(SegmentInstanceDpo segment)
        {
            CurrentSegmentLine.LoopName = segment.LoopName; 
            CurrentSegmentLine.Segment = segment;
        }
    }
}
