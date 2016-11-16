using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saper
{
    class Field
    {
        public int mined_neighbours;
        public bool mined;
        public bool uncovered;
        public bool explosion;
        public bool highlight;
        public Field[] neighbours = new Field[8];
        public int neighbour_count;
    }
}
