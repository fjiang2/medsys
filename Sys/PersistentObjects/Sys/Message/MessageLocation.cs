using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    /// <summary>
    /// represents message location
    /// </summary>
    public class MessageLocation
    {

        /// <summary>
        /// any location
        /// </summary>
        public readonly object location;

        //string file;
        //int line;
        //int column;

        /// <summary>
        /// line location
        /// </summary>
        /// <param name="line"></param>
        public MessageLocation(int line)
        {
            this.location = line;
        }

        /// <summary>
        /// string location 
        /// </summary>
        /// <param name="location"></param>
        public MessageLocation(string location)
        {
            this.location = location;
        }


        /// <summary>
        /// return the line of location
        /// </summary>
        public int Line
        {
            get
            {
                if (location is int)
                    return (int)location;
                
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// return description of location
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (location is int)
                return string.Format("Line {0}", location);
            else
                return location.ToString();
        }
    }
}
