//
// Machine Generated Code
//   by devel
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace Fruit
{
    
    
    public partial class Product : DPObject
    {
        public string Apple {get; set;} 
        public string Orange {get; set;} 
        [Column(_Apple_Tree, CType.NVarChar, Nullable = true)]                                    public string Apple_Tree {get; set;} 
        public int? Number {get; set;} 
        public bool? Flag {get; set;} 

        public Product()
        {
        }

        public Product(DataRow dataRow)
            :base(dataRow)
        {
        }




        //must override when logger is used
        protected override int DPObjectId
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        


        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[] {});
            }
        }
        


        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys();
            }
        }
        
 

        #region CONSTANT

        public const string _Apple = "Apple";
        public const string _Orange = "Orange";
        public const string _Apple_Tree = "Apple Tree";
        public const string _Number = "Number";
        public const string _Flag = "Flag";

       
        #endregion 




		public override void Fill(DataRow row)
		{
			Apple = (string)row.GetValue(_Apple);
			Orange = (string)row.GetValue(_Orange);
			Apple_Tree = (string)row.GetValue(_Apple_Tree);
			Number = (int?)row.GetValue(_Number);
			Flag = (bool?)row.GetValue(_Flag);
		}

		public override void Collect(DataRow row)
		{
			row.SetValue(_Apple, this.Apple);
			row.SetValue(_Orange, this.Orange);
			row.SetValue(_Apple_Tree, this.Apple_Tree);
			row.SetValue(_Number, this.Number);
			row.SetValue(_Flag, this.Flag);
		}

    }
}

