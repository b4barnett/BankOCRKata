using Functional.Option;
using System.Collections.Immutable;

namespace BankKataOCR.Business.Data
{
    public record SingleOCRNumber( ImmutableList<Ranked> PossibleValues )
    {
        public int GetExact()
        {
            var getScores = GetScoresBelow( 0 ); //exact specifications will only produce a value of zero

            if ( getScores.Any() )
            {
                return getScores[ 0 ];
            }

            throw new Exception( "No exact value" );
        }

        //could probably do some enumerator thing here so that we included the exact value
        public List<int> GetScoresBelow( int score )
        {
            return PossibleValues.Where( x => x.Score <= score ).Select( y => y.Value ).ToList();
        }

        public class Builder
        {
            private int colIdx = 0;
            private int rowIdx = 0;
            private char[,] _letters;
            private List<NumberSpecification> _numberSpecifications;

            public Builder( List<NumberSpecification> numberSpecifications )
            {
                _numberSpecifications = numberSpecifications;
                _letters = new char[ Constants.OcrNumberWidth.Width, Constants.OcrNumberHeight.Height ];
            }

            public void SetLetter( char c )
            {
                if ( colIdx == ( Constants.OcrNumberWidth.Width ) )
                {
                    colIdx = 0;
                    rowIdx++;
                }

                _letters[ rowIdx, colIdx ] = c;

                colIdx++;
            }

            public SingleOCRNumber Build()
            {
                var allAssessments = _numberSpecifications.Select( x => x.Match( _letters ) ).OrderBy( x => x.Score ).ToImmutableList();

                return new SingleOCRNumber( allAssessments );
            }
        }
    }
}
