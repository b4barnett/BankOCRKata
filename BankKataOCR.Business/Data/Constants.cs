using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankKataOCR.Business.Data
{
    public static class Constants
    {
        #region Character Constants
        public static readonly char Space = ' ';
        public static readonly char Underscore = '_';
        public static readonly char Pipe = '|';
        #endregion

        #region 

        public static readonly string ReadErrorIndicator = "ILL";
        public static readonly string CheckSumFailedIndicator = "ERR";

        #endregion

        #region OCR values

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

        public static class NumbersPerLine
        {
            public static readonly int Count = 9;
            public static readonly int CountZeroIndexBased = 8;
        }

        #endregion

        #region NumberSpecifications

        public static class NumberSpecifications
        {
            public static List<NumberSpecification> Defaults() => new List<NumberSpecification>() { ZeroSpecification(), OneSpecification(), TwoSpecification(), 
                ThreeSpecification(), FourSpecification(), FiveSpecification(), 
                SixSpecification(), SevenSpecification(), EightSpecification(), 
                NineSpecification()  };


            #region zero

            private static readonly char[,] zero = { { Space, Underscore, Space },
                                            { Pipe,  Space,      Pipe },
                                            { Pipe,  Underscore, Pipe } };

            public static NumberSpecification ZeroSpecification() => new NumberSpecification( zero, 0 );

            #endregion

            #region one

            private static readonly char[,] one = { { Space, Space, Space  },
                                                    { Space, Space, Pipe },
                                                    { Space, Space, Pipe } };

            public static NumberSpecification OneSpecification() => new NumberSpecification( one, 1 );

            #endregion

            #region two
            private static readonly char[,] two = { { Space, Underscore, Space },
                                                    { Space, Underscore, Pipe },
                                                    { Pipe, Underscore, Space } };

            public static NumberSpecification TwoSpecification() => new NumberSpecification( two, 2 );

            #endregion

            #region three

            private static readonly char[,] three = { { Space, Underscore, Space },
                                                      { Space, Underscore, Pipe },
                                                      { Space, Underscore, Pipe } };

            public static NumberSpecification ThreeSpecification() => new NumberSpecification( three, 3 );

            #endregion

            #region four

            private static readonly char[,] four = { { Space, Space, Space},
                                                     { Pipe, Underscore, Pipe },
                                                     { Space, Space, Pipe } };

            public static NumberSpecification FourSpecification() => new NumberSpecification( four, 4 );

            #endregion

            #region five

            private static readonly char[,] five = { { Space, Underscore, Space },
                                                     { Pipe, Underscore, Space },
                                                     { Space, Underscore, Pipe } };

            public static NumberSpecification FiveSpecification() => new NumberSpecification( five, 5 );

            #endregion

            #region six

            private static readonly char[,] six = { { Space, Underscore, Space },
                                                     { Pipe, Underscore, Space },
                                                     { Pipe, Underscore, Pipe } };

            public static NumberSpecification SixSpecification() => new NumberSpecification( six, 6 );

            #endregion

            #region seven

            private static readonly char[,] seven = { { Space, Underscore, Space },
                                                       { Space, Space, Pipe },
                                                       { Space, Space, Pipe } };


            public static NumberSpecification SevenSpecification() => new NumberSpecification( seven, 7 );

            #endregion

            #region eight 

            private static readonly char[,] eight = { { Space, Underscore, Space },
                                                    { Pipe, Underscore, Pipe },
                                                    { Pipe, Underscore, Pipe } };

            public static NumberSpecification EightSpecification() => new NumberSpecification( eight, 8 );

            #endregion

            #region nine

            private static readonly char[,] nine = { { Space, Underscore, Space },
                                                    { Pipe, Underscore, Pipe },
                                                    { Space, Underscore, Pipe } };

            public static NumberSpecification NineSpecification() => new NumberSpecification( nine, 9 );

            #endregion

        }

        #endregion
    }
}
