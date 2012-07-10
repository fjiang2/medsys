using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys;
using X12.Dpo;

namespace X12.Specification
{
    class ElementTemplateDpo : X12ElementTemplateDpo
    {

        public ElementTemplateDpo()
        { 
        
        }

        public ElementTemplateDpo(DataRow dataRow)
            :base(dataRow)
        { 
        }

        public Type Type
        {
            get
            {
                switch (this.DataType)
                {
                    case "R": return typeof(decimal);       //Decimal
                    case "ID": return typeof(Identifier);   //Identifier
                    case "AN": return typeof(string);       //String
                    case "DT": return typeof(DateTime);     //Date, YYMMDD 
                    case "TM": return typeof(TimeSpan);     //Time, HHMMSS
                    case "B": return typeof(byte[]);        //Binary
                    case "N0": return typeof(double);       //Numeric
                    case "": return typeof(string);
                }

                throw new X12Exception("Invalid dataType: {0}", this.DataType);
            }

        }

        public DataELemenType ElementType
        {
            get { return FromDataType(this.DataType); }
            set { this.DataType = ToDataType(value); }
        }

        public ConditionDesignator ConditionDesignator
        {
            get
            {
                return FromCondition(this.Condition);
            }
            set
            {
                this.Condition = ToCondition(value);
            }

        }


        public static DataELemenType FromDataType(string dataType)
        {
            switch (dataType)
            {
                case "N0": return DataELemenType.Numeric;
                case "R": return DataELemenType.Decimal;
                case "ID": return DataELemenType.Identifier;
                case "AN": return DataELemenType.String;
                case "DT": return DataELemenType.Date;
                case "TM": return DataELemenType.Time;
                case "B": return DataELemenType.Binary;
            }

            return DataELemenType.Undefined;
        }

        public static string ToDataType(DataELemenType value)
        {
            switch (value)
            {
                case DataELemenType.Numeric: return "N0";
                case DataELemenType.Decimal: return "R";
                case DataELemenType.Identifier: return "ID";
                case DataELemenType.String: return "AN";
                case DataELemenType.Date: return "DT";
                case DataELemenType.Time: return "TM";
                case DataELemenType.Binary: return "B";

            }
            return "";
        }
           

        public static ConditionDesignator FromCondition(string condition)
        {
            switch (condition)
            {
                case "M": return ConditionDesignator.Mandatory;
                case "O": return ConditionDesignator.Optional;
                case "X": return ConditionDesignator.Relational;
            }

            return ConditionDesignator.Undefined;
        }

        public static string ToCondition(ConditionDesignator value)
        {
            switch (value)
            {
                case ConditionDesignator.Mandatory:
                    return "M";

                case ConditionDesignator.Optional:
                    return "O";

                case ConditionDesignator.Relational:
                    return "X";
            }

            return "";
        }

    

       

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.RefDes, this.Description.ToSentence());

            //return string.Format("{0} {1} {2} {3}{4} {5} {6}/{7}", 
            //    this.RefDes, this.DeNum,
            //    Description,
            //    Condition, RepeatValue, DataType, MinLength, MaxLength
            //    );
        }
    }
}
