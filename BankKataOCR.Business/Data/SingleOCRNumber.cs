using Functional.Option;
using System.Collections.Immutable;

namespace BankKataOCR.Business.Data
{
    public record SingleOCRNumber( Option<int> Number )
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
                var allAssessments = _numberSpecifications.Select( x => x.Match( _letters ) )
                                      .Where( x => x.IsSuccessful );

                if ( allAssessments.Any() == false )
                {
                    return new SingleOCRNumber( Option<int>.None );
                }

                var value = _numberSpecifications.Select( x => x.Match( _letters ) )
                                      .Where( x => x.IsSuccessful )
                                      .Single()
                                      .Value; //normally a dangerous assumption but really validation should be done on the AllSpecifications
                return new SingleOCRNumber( Option.Some<int>( value ) );
            }
        }
    }
}
