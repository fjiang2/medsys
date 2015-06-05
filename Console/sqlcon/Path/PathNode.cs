using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys.Data;

namespace sqlcon
{
    class PathNode : IDataPath
    {
        public readonly PathLevel Level;
        public PathNode(PathLevel level)
        {
            this.Level = level;
        }

        public string Path
        {
            get { return Level.ToString(); }
        }

        public override string ToString()
        {
            return Path;
        }
    }
}
