using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X12.Specification;
using Sys;

namespace X12.File
{
    abstract class BaseParser
    {
        
        /// <summary>
        /// Producer/Input
        /// </summary>
        protected List<SegmentLine> segmentLines;
        private int line = 0;
    
        /// <summary>
        /// Consumer/Output
        /// </summary>
        protected Tree<LoopLine> consumer;
        protected TreeNode<LoopLine> consumerNode;

        /// <summary>
        /// Parser Director/Syntax
        /// </summary>
        protected TreeNode<LoopTemplateDpo> directorNode;


        public BaseParser(List<SegmentLine> segmentLines)
        {
            this.segmentLines = segmentLines;

            this.consumer = new Tree<LoopLine>();
            this.consumerNode = consumer.RootNode;
        }

        public Tree<LoopLine> Consumer
        {
            get { return this.consumer; }
        }


        protected int Line
        {
            get { return this.line; }
        }

        protected void NextLine()
        {
           line++;
        }

        protected void TraceBack(int line)
        {
            this.line = line;
        }

        protected LoopTemplateDpo CurrentLoopTemplate
        {
            get
            {
                return directorNode.Item;
            }
        }

        protected SegmentLine CurrentSegmentLine
        {
            get
            {
                return segmentLines[line];
            }
        }


        protected bool IsSegmentName(string segmentName)
        {
            return CurrentSegmentLine.SegmentName == segmentName;
        }



        protected bool Expect(string segmentName)
        {
            if (IsSegmentName(segmentName))
            {
                line++;
                return true;
            }
            else
                throw new X12Exception("Loop={0}, Segment={1} expected at line: {2}", this.CurrentLoopTemplate, segmentName, line + 1);
        }





        public void Parse()
        {
            line = 0;
            //InterchangeControl();
            HierarchicalTransaction();
        }

        #region Control Segments

        private bool InterchangeControl()
        {
            if (IsSegmentName("ISA"))
            {
                NextLine();
                while (FunctionGroup()) ;
                Expect("IEA");

                return true;
            }
            throw new X12Exception("Invalid x12 file");
        }

        private bool FunctionGroup()
        {
            if (IsSegmentName("GS"))
            {
                NextLine();

                while (TransactionSet()) ;

                Expect("GE");
                return true;
            }

            return false;
        }

        private bool TransactionSet()
        {

            if (IsSegmentName("ST"))
            {
                line++;

                Expect("BHT");

                while (HierarchicalTransaction()) ;

                Expect("SE");
                return true;
            }

            return false;
        }

        #endregion


        protected virtual bool HierarchicalTransaction()
        {
           // line = this.segmentLines.Count - 3;
            return false;
        }
    }
}
