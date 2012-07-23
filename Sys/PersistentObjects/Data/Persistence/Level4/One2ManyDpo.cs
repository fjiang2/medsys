//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;
//using System.ComponentModel;

//namespace Sys.Data
//{
//    public class OneManyObject<TMany> : DPObject 
//        where TMany: class, IDPObject, new()
//    {
//        public event AddingNewEventHandler AddingNew;

//        DPList<TMany> many;

//        public OneManyObject()
//        {
//            this.many = new DPList<TMany>();
//        }

//        public OneManyObject(DataRow dataRow)
//            : base(dataRow)
//        {
//        }

//        public override void Fill(DataRow dataRow)
//        {
//            base.Fill(dataRow);
            
//            if (AddingNew != null)
//            {
//                var args = new AddingNewEventArgs();
//                AddingNew(this, args);
//                this.many = (DPList<TMany>)args.NewObject;
//            }
//            else
//                this.many = new DPList<TMany>(new TableReader<TMany>(new ColumnValue("", this.DPObjectId)));
//        }

//        public override DataRow Save()
//        {
//            DataRow row = base.Save();
//            this.many.Save();

//            return row;
//        }
//    }
//}
