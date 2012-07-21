using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.CodeBuilder
{
    class Statement : Format
    {
      //  string sent;

        public Statement()
        { 
        }

        public Statement IF(string exp, Statement sent)
        {
            return this;
        }
        
        public Statement WHILE(string exp, Statement sent)
        {
            return this;
        }


    }
}
