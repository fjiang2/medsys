using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Sys
{
    /// <summary>
    /// abstract numeric tree node 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INTreeNode<T> where T : class
    {
        /// <summary>
        /// return current node id
        /// </summary>
        int NodeId { get; }

        /// <summary>
        /// return parent node id
        /// </summary>
        int NodeParentId { get; set; }

        /// <summary>
        /// return value item in the node
        /// </summary>
        T NodeItem { get; }
    }
}
