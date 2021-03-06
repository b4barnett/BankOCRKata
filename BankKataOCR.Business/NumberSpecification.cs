using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankKataOCR.Business.Data;

namespace BankKataOCR.Business
{
    [DebuggerDisplay( "{Number}" )]
    public class NumberSpecification
    {
        private readonly int _number;

   
        public int Number => _number;

        private char[,] _specification { get; }

        public NumberSpecification( char[,] specification, int number )
        {
            _specification = specification;
            _number = number;
        }

        public Result<int> Match( char[,] input )
        {
            for ( int i = 0; i < Constants.OcrNumberWidth.Width; i++ )
            {
                for ( int s = 0; s < Constants.OcrNumberHeight.Height; s++ )
                {
                    if ( input[ i, s ] != _specification[ i, s ] )
                    {
                        return Result<int>.Failure();
                    }
                }
            }
            return Result<int>.Success( _number );
        }
    }
}
