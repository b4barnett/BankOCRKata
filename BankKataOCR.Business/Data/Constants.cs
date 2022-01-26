using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankKataOCR.Business.Data
{
    public static class Constants
    {
        /* On the widths because the empty line for numbers does not
        matter then I'm just going to filter it out and say that these
        3x3 arrays represent the number */

        public static class OcrNumberWidth
        {
            public static readonly int Width = 3;
            public static readonly int WidthZeroIndexBased = 2;
        }

        public static class OcrNumberHeight
        {
            public static readonly int Height = 3;
            public static readonly int HeightZeroIndexBased = 2;
        }
    }
}
