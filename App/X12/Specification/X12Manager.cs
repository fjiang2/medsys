﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using X12.DpoClass;
using System.Data;

namespace X12.Specification
{
    class X12Manager
    {
        private static X12Manager instance = null;
        private X12Manager()
        {
        }

        public static X12Manager Instance
        {
            get
            {
                if(instance == null)
                    instance = new X12Manager();
        
                return instance;
            }
        }


        public static LoopTemplateDpo[] GetLoopTemplates(int parentID)
        {
            DataTable dt = new TableReader<LoopTemplateDpo>(X12LoopTemplateDpo._ParentID.ColumnName() == parentID).Table;
            var loops = new DPList<LoopTemplateDpo>(dt);


            return loops.OrderBy(dpo => dpo.Sequence).ToArray();
        }


        public static X12SegmentInstanceDpo[] GetSegementInstances(X12LoopTemplateDpo loop)
        {
            DataTable dt = new TableReader<X12SegmentInstanceDpo>(X12SegmentInstanceDpo._LoopName.ColumnName() == loop.Name).Table;
            var segments = new DPList<X12SegmentInstanceDpo>(dt);

            return segments.OrderBy(segment=>segment.Sequence).ToArray();
        }




        public static  ElementTemplateDpo[] GetElementTemplates(X12SegmentInstanceDpo segment)
        {
            DataTable dt = new TableReader<ElementTemplateDpo>(ElementTemplateDpo._SegmentName.ColumnName() == segment.Name).Table;
            var elements = new DPList<ElementTemplateDpo>(dt);

            return elements.OrderBy(dpo => dpo.RefDes).ToArray();
        }




    }
}
