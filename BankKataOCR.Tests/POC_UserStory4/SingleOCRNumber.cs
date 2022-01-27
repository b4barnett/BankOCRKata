using System.Collections.Immutable;

namespace BankKataOCR.Business.Data
{
    public record SingleOCRNumber( ImmutableList<Rank> PossibleValues )
    {
        //Possibly some enumerator nonesense could go here
        public List<int> GetPossibleValues( int withinScore )
        {
            return PossibleValues.Where( x => x.Score <= withinScore ).Select( x => x.Value ).ToList();
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
                return new SingleOCRNumber( _numberSpecifications.Select( x => x.Score( _letters ) ).OrderBy( x => x.Score ).ToImmutableList() );
            }
        }
    }
}
