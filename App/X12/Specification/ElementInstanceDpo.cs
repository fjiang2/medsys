using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X12.DpoClass;
using Sys.Data;
using System.Data;

namespace X12.Specification
{
    
    public class ElementInstanceDpo: X12ElementInstanceDpo
    {

        private ElementTemplateDpo specification;
        private CodeDefinitionDpo[] codeDefinitions;

        public ElementInstanceDpo()
        {
        }

        public ElementInstanceDpo(int element1_id, int segment2_id)
            :base(element1_id, segment2_id)
        {
        }

       

        public CodeDefinitionDpo[] CodeDefinitions
        {
            get
            {
                if (codeDefinitions == null)
                {
                    codeDefinitions = Spec5010A.Instance.GetCodeDefinitions()
                          .Where(code => code.ElementInstance_ID == this.ID)
                          .ToArray();
                }

                return codeDefinitions;
            }
        }



        public UsageType UsageType
        {
            get { return (UsageType)this.Usage; }
            set { this.Usage = (int)value; }
        }


        public virtual bool Validate(string value)
        {
            if (string.IsNullOrEmpty(value) && specification.ConditionDesignator == ConditionDesignator.Mandatory)
                throw new X12Exception("element is required, cannot be empty");

            if (specification.MinLength != 0 && specification.MaxLength != 0)
            {
                if (value.Length < specification.MinLength)
                    throw new X12Exception("element length({0}) < minimum length({1})", value.Length, specification.MinLength);

                if (value.Length > specification.MaxLength)
                    throw new X12Exception("element length({0}) > maximum length({1})", value.Length, specification.MaxLength);
            }

            //if (specification.Count > 0)
            //{
            //    if (specification.Where(rule => rule.Validate(this)).Count() != 1)
            //        throw new X12Exception("invalid code {0}", value);
            //}


            return true;

        }

    

        internal ElementTemplateDpo Specification
        {
            get { return specification; }
            set { specification = value; }
        }


        

    }
}
