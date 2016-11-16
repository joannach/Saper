using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saper
{
    public class Options
    {
        public enum Difficulty { EASY, MEDIUM, HARD };
        public Difficulty difficulty = Difficulty.EASY;
        public enum Size { SMALL, MEDIUM, LARGE };
        public Size size = Size.SMALL;
        public bool highlight = true;

    }
}
