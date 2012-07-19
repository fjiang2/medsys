#define NODATABAE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X12.DpoPackage;
using X12.DpoClass;
using X12.Specification;
using System.Data;
using Sys.Data;
using Sys;

namespace X12.Specification
{
    

    class Spec5010A
    {
        static Spec5010A instance = null;

        List<LoopTemplateDpo> specLoopTemplates;
        List<SegmentTemplateDpo> specSegmentTemplates;
        List<SegmentInstanceDpo> specSegmentInstances;
        List<ElementTemplateDpo> specElementTemplates;
        List<ElementInstanceDpo> specElementInstances;
        List<CodeDefinitionDpo> specCodeDefinitions;

        private Spec5010A()
        {
#if NODATABAE
            this.specLoopTemplates = new X12LoopTemplateDpoPackage().ToList<LoopTemplateDpo>().OrderBy(dpo=>dpo.Sequence).ToList();
            this.specSegmentTemplates = new X12SegmentTemplateDpoPackage().ToList<SegmentTemplateDpo>();
            this.specSegmentInstances = new X12SegmentInstanceDpoPackage().ToList<SegmentInstanceDpo>();
            this.specElementTemplates = new X12ElementTemplateDpoPackage().ToList <ElementTemplateDpo>();
            this.specElementInstances = new X12ElementInstanceDpoPackage().ToList <ElementInstanceDpo>();
            this.specCodeDefinitions = new X12CodeDefinitionDpoPackage().ToList<CodeDefinitionDpo>();
#else
            DataTable dt;
            dt = new TableReader<LoopTemplateDpo>().Table;
            this.specLoopTemplates = new DPList<LoopTemplateDpo>(dt).ToList().OrderBy(dpo=>dpo.Sequence).ToList();

            dt = new TableReader<X12SegmentTemplateDpo>().Table;
            this.specSegmentTemplates = new DPList<SegmentTemplateDpo>(dt).ToList();

            dt = new TableReader<SegmentInstanceDpo>().Table;
            this.specSegmentInstances = new DPList<SegmentInstanceDpo>(dt).ToList();

            dt = new TableReader<X12ElementTemplateDpo>().Table;
            this.specElementTemplates = new DPList<ElementTemplateDpo>(dt).ToList();

            dt = new TableReader<X12ElementInstanceDpo>().Table;
            this.specElementInstances = new DPList<ElementInstanceDpo>(dt).ToList();

            dt = new TableReader<CodeDefinitionDpo>().Table;
            this.specCodeDefinitions = new DPList<CodeDefinitionDpo>(dt).ToList();

#endif
        }

        public static Spec5010A Instance
        {
            get
            {
                if (instance == null)
                    instance = new Spec5010A();
                return instance;
            }
        }

        public IEnumerable<LoopTemplateDpo> GetLoopTemplates()          { return specLoopTemplates;    }
        
        public IEnumerable<SegmentTemplateDpo> GetSegmentTemplates()    { return specSegmentTemplates; }
        public IEnumerable<SegmentInstanceDpo> GetSegmentInstances()    { return specSegmentInstances; }
        
        public IEnumerable<ElementTemplateDpo> GetElementTemplates()    { return specElementTemplates; }
        public IEnumerable<ElementInstanceDpo> GetElementInstances()    { return specElementInstances; }

        public IEnumerable<CodeDefinitionDpo> GetCodeDefinitions()      { return specCodeDefinitions; }


        
        public NTree<LoopTemplateDpo> GetLoopTemplateTree()
        {
            int parentId = 0;
            return new NTree<LoopTemplateDpo>(GetLoopTemplates(), parentId);
        }

        public SegmentInstanceDpo[] GetSegmentInstances(LoopTemplateDpo loop)
        {
            return specSegmentInstances
                                .Where(segment => segment.LoopName == loop.Name)
                                .OrderBy(segment => segment.Sequence)
                                .ToArray();
        }

      

      

   
    }
}
