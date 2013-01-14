//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.PersistentObjects.DpoClass;
using Sys.Data;

namespace Sys.Data.Manager
{
    public class EnumField : dictEnumTypeDpo
    {
        public EnumField()
        { 
        }

        public EnumField(DataRow row)
            : base(row)
        {
           
        }

        public EnumField(string category, string feature)
            :base(category, feature)
        {
        }

      

        public bool Validate(MessageBuilder messages)
        {
            this.Feature = this.Feature.Trim();

            bool good = ident.Identifier(this.Feature).Equals(this.Feature);
           
            if (!good)
                messages.Add(Message.Error(string.Format("Invalid identifier: {0}", this.Feature)));

            return good;
        }

        public string Caption
        {
            get
            {
                if (this.Label == null)
                    return this.Feature;
                else
                    return this.Label;
            }
        }

        public string ToCode()
        {
            return string.Format("\t\t{0}\r\n\t\t{1} = {2}", 
                new FieldAttribute(this.Caption), 
                ident.Identifier(this.Feature), 
                this.Value
                );
        }

        
        public override string ToString()
        {
            return string.Format("{0}.{1}={2}", this.Category, this.Feature, this.Value);
        }
    }
}
