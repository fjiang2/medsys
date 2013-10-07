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

namespace Sys
{
    /// <summary>
    /// Sequential List, Order by ID 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SequentialList<T> : List<T>
    {
        public SequentialList()
        {
        }

        public SequentialList(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public SequentialList(int capacity)
            : base(capacity)
        {
        }

        public bool MoveUp(T item)
        {
            int index = this.IndexOf(item);
            if (index == 0)
                return false;

            this.Remove(item);
            this.Insert(index - 1, item);

            return true;
        }

        public bool MoveDown(T item)
        {
            int index = this.IndexOf(item);
            if (index == this.Count - 1)
                return false;

            this.Remove(item);
            this.Insert(index + 1, item);
            return true;
        }


        /// <summary>
        /// Order By Id, e.g. Selecor = row => row.Id;
        /// </summary>
        public Func<T, int> Selector { get; set; }

        /// <summary>
        /// Sequential Id Array 
        /// </summary>
        public int[] Sequence
        {
            get
            {
                if (Selector == null)
                    throw new InvalidOperationException("Selector is not defined");

                List<int> seq = new List<int>();
                foreach (var item in this)
                {
                    seq.Add(Selector(item));
                }

                return seq.ToArray();
            }

            set
            {
                if (Selector == null)
                    throw new InvalidOperationException("Selector is not defined");

                int[] seq = value;

                if (seq == null)
                    return;

                if (seq.Length != this.Count)
                    throw new InvalidOperationException("number of sequence does not match list");

                List<T> list = new List<T>();
                try
                {
                    for (int i = 0; i < seq.Length; i++)
                        list.Add(this.Where(r => Selector(r) == seq[i]).First());
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("sequence id does not match list");
                }

                this.Clear();
                foreach (var item in list)
                {
                    this.Add(item);
                }
            }
        }

    }
}
