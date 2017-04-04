using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_CSharp
{
    /// <summary>
    /// Represents a location
    /// </summary>
    public class Location
    {
        public int row;
        public int column;

        /// <summary>
        /// Location constructor
        /// </summary>
        /// <param name="column">column</param>
        /// <param name="row">row</param>
        public Location(int column,int row)
        {
            this.row = row;
            this.column = column;
        }
    }
}
