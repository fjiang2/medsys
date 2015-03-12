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
using Sys.Data;

namespace Sys.Data.Manager
{
    public class EnumTypeManager
    {
        List<EnumType> types;

        public EnumTypeManager()
            :this(new TableReader<EnumField>().ToList().OrderBy(field => field.Category))
        {
        }

        private EnumTypeManager(IEnumerable<EnumField> list)
        {
            types = new List<EnumType>();

            var groups = list.GroupBy(field => field.Category);
            foreach (var group in groups)
            {
                EnumType type = new EnumType(group.Select(field => field).OrderBy(field => field.Value).ToList());

                types.Add(type);
            }
        }

        /// <summary>
        /// replace existing EnumType or add new EnumType
        /// </summary>
        /// <param name="type"></param>
        public void Add(EnumType type)
        { 
            if(types.Exists(ty => ty.Name == type.Name))
            {
                types.RemoveAll(ty => ty.Name == type.Name);
            }

            types.Add(type);
        }

        public List<EnumType> Types
        {
            get
            {
                return types;
            }
        }

        private void GenerateCode(string path, string nameSpace)
        {
            MessageBuilder messages = new MessageBuilder();
            foreach (EnumType type in types)
            {
                if (type.Validate(messages))
                    type.GenerateCode(path, nameSpace);
                else
                    throw new MessageException(messages.ToString());
            }
        }

        public static void GenerateEnumType(DataProvider provider, string tableName, string[] enumTypes, string path, string nameSpace)
        {
            TableName tname = new TableName(provider, tableName);
            List<EnumField> list = new List<EnumField>();

            foreach (string enumType in enumTypes)
            {
                foreach (var field in new TableReader(tname, EnumField._Category.ColumnName() == enumType).ToList<EnumField>())
                    list.Add(field);
            }

            EnumTypeManager manager = new EnumTypeManager(list);
            manager.GenerateCode(path, nameSpace);
        }
       

        public static void GenerateEnumType(string[] enumTypes, string path, string nameSpace)
        {
            List<EnumField> list = new List<EnumField>();

            foreach (string enumType in enumTypes)
            {
                foreach (var field in new TableReader<EnumField>(EnumField._Category.ColumnName() == enumType).ToList())
                    list.Add(field);
            }

            EnumTypeManager manager = new EnumTypeManager(list);
            manager.GenerateCode(path, nameSpace);
        }

        /// <summary>
        /// Read user indicated table to generate EnumTypes
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="tableName"></param>
        /// <param name="path"></param>
        /// <param name="nameSpace"></param>
        public static void GenerateEnumType(DataProvider provider, string tableName, string path, string nameSpace)
        {
            List<EnumField> list = new TableReader(new TableName(provider, tableName)).ToList<EnumField>();
            EnumTypeManager manager = new EnumTypeManager(list);
            manager.GenerateCode(path, nameSpace);
        }

        /// <summary>
        /// Read sys00204 and generate EnumType
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nameSpace"></param>
        public static void GenerateEnumType(string path, string nameSpace)
        {
            EnumTypeManager manager = new EnumTypeManager();

            manager.GenerateCode(path, nameSpace);
        }

    }
}
