using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_CSharp
{
    public class Location
    {
        public int row;
        public int column;

        public Location(int column,int row)
        {
            this.row = row;
            this.column = column;
        }
    }
}
