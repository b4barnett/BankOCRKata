using System.Collections.Immutable;

namespace BankKataOCR.Business.Data
{
    public record SingleOCRNumber( int Number )
    {
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
                var allSuccess = _numberSpecifications.Select( x => x.Match( _letters ) )
                                      .Where( x => x.IsSuccessful );
                if ( allSuccess.Count() > 1 )
                {
                    int k = 0;
                }

                var value = _numberSpecifications.Select( x => x.Match( _letters ) )
                                      .Where( x => x.IsSuccessful )
                                      .Single()
                                      .Value; //normally a dangerous assumption but really validation should be done on the AllSpecifications
                return new SingleOCRNumber( value );
            }
        }
    }
}
