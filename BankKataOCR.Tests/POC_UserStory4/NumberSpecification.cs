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

        public Rank Score( char[,] input )
        {
            int score = CalculateScore( _specification );
            for ( int i = 0; i < Constants.OcrNumberWidth.Width; i++ )
            {
                for ( int s = 0; s < Constants.OcrNumberHeight.Height; s++ )
                {
                    if ( input[ i, s ] == _specification[ i, s ] && input[ i, s ] != Constants.Space )
                    {
                        score = score - 1;
                    }
                    //we've found a character where this specification thinks it's a space so increment the score
                    else if ( input[ i, s ] != _specification[ i, s ] && input[ i, s ] != Constants.Space )  
                    {
                        score++;
                    }
                }
            }
            return new Rank()
            {
                Score = score,
                Value = _number
            };
        }

        private static int CalculateScore( char[,] input )
        {
            int score = 0;
            for ( int i = 0; i < Constants.OcrNumberWidth.Width; i++ )
            {
                for ( int s = 0; s < Constants.OcrNumberHeight.Height; s++ )
                {
                    if ( input[ i, s ] != Constants.Space )
                    {
                        score++;
                    }
                }
            }

            return score;
        }
    }

    public class Rank
    {
        public int Score { get; init; }
        public int Value { get; init; }
    }
}
