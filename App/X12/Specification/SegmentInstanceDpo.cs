using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X12.DpoClass;
using Sys.Data;
using System.Data;
using Sys;

namespace X12.Specification
{
    class SegmentInstanceDpo : X12SegmentInstanceDpo
    {
        ElementTemplateDpo[] elementTemplates = null;
        ElementInstanceDpo[] elementInstances = null;

        public SegmentInstanceDpo()
        {
        }

        public SegmentInstanceDpo(DataRow dataRow)
            :base(dataRow)
        {
        }

        public ElementTemplateDpo[] ElementTemplates
        {
            get
            {
                if (elementTemplates == null)
                {
                    elementTemplates = Spec5010A.Instance.GetElementTemplates()
                            .Where(element => element.SegmentName == this.Name)
                            .OrderBy(element => element.RefDes)
                            .ToArray();
                }

                return elementTemplates;
            }
        }

        private ElementInstanceDpo[] ElementInstances
        {
            get
            {
                if (elementInstances == null)
                {
                    elementInstances =
                        Spec5010A.Instance.GetElementInstances()
                       .Where(element => element.SegmentInstance_ID == this.ID)
                       .ToArray();
                }

                return elementInstances;
            }
        }


        public ElementInstanceDpo this[int ordinal]
        {
            get
            {
                ElementTemplateDpo elmentTemplate = ElementTemplates[ordinal];
                
                return this.ElementInstances
                    .Where(element => element.ElementTemplate_ID == elmentTemplate.ID)
                    .FirstOrDefault();
            }
        }

        public bool ValidElementCode(File.SegmentLine segmentLine, out string message)
        {
            message = "";

            
            for (int ordinal = 0; ordinal < segmentLine.Count - 1; ordinal++)
            {
                if (segmentLine[ordinal + 1].Text == "")
                    continue;

                CodeDefinitionDpo[] definitions = GetCodeDefinitions(ordinal);

                if (!ValidElementCode(segmentLine[ordinal + 1].Text, definitions))
                {
                    message =
                        string.Format("Invalid code {0}{1:00} = {2}, {3} valid code = {{{4}}}",
                        segmentLine.Name, ordinal + 1,
                        segmentLine[ordinal + 1].Text,
                        this.Text,
                        string.Join(",", definitions.Select(def => def.Code))
                        );

                    return false;
                }
            }

            return true;
        }


        #region Code Definition



        private CodeDefinitionDpo[] GetCodeDefinitions(int ordinal)
        {
            ElementInstanceDpo[] elements = ElementInstances
                   .Where(element => element.ElementTemplate_ID == ElementTemplates[ordinal].ID)
                   .ToArray();

            if (elements.Length == 0)
                return new CodeDefinitionDpo[] { };


            return elements[0].CodeDefinitions;
        }

        private static bool ValidElementCode(string elementCode, CodeDefinitionDpo[] definitions)
        {
            if (definitions.Length == 0)
                return true;

            return definitions.Where(
                    definition =>
                        elementCode == definition.Code
                        || (elementCode.StartsWith(definition.Code) && elementCode.IndexOf(":") >= 0)
                )
                .Count() == 1;
        }



        #endregion


        public string Text
        {
            get
            {
                return string.Format("{0} - {1}", this.Name, this.Description.ToSentence());
            }
        }
        public override string ToString()
        {
            return string.Format("Loop={0} Segment={1} Required={2}", this.LoopName, this.Name, this.Required);
        }
    }
}
