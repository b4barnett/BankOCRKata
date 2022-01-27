using BankKataOCR.Business.Data;
using BankKataOCR.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankKataOCR.Business
{
    public class OCRReader : IOCRReader
    {
        private List<NumberSpecification> _numberSpecifications;

        public OCRReader( List<NumberSpecification> numberSpecifications )
        {
            _numberSpecifications = numberSpecifications;
        }

        public string ReadSingleOCRLine( TextReader reader )
        {
            reader.ReadLine();//ignore the first blank line

            int lineLength = Constants.OcrNumberWidth.Width *
                                    Constants.NumbersPerLine.Count;

            var dict = CreateBuilderCollection( _numberSpecifications );

            for ( int row = 0; row < Constants.OcrNumberHeight.Height; row++ )
            {
                //get round attempting to set EOL to the arrays
                char[] line = reader.ReadLine().ToCharArray();

                for ( int col = 0; col < lineLength; col++ )
                {
                    int builderKey = col / ( Constants.OcrNumberWidth.Width );

                    /* this is to cover if the reader falls short (like the UserStory.1 0
                    where the first row isn't the full 27 characters, but probably within the domain of a scanner 
                    so lets just assume a blank space here*/
                    if ( col >= line.Length )
                    {
                        dict[ builderKey ].SetLetter( Constants.Space );
                    }
                    else
                    {
                        dict[ builderKey ].SetLetter( line[ col ] );
                    }
                }

            }

            return dict.Aggregate( new StringBuilder(), ( builder, kvp ) => 
            {
                string value = kvp.Value.Build().Number.Match( () => "?", n => n.ToString() ); 
                builder.Append( value );
                return builder;
            } ).ToString();
        }


        private static Dictionary<int, SingleOCRNumber.Builder> CreateBuilderCollection( List<NumberSpecification> specifications )
        {
            Dictionary<int, SingleOCRNumber.Builder> ocrNumber = new Dictionary<int, SingleOCRNumber.Builder>();

            for ( int i = 0; i < Constants.NumbersPerLine.Count; i++ )
            {
                ocrNumber.Add( i, new SingleOCRNumber.Builder( specifications ) );
            }

            return ocrNumber;
        }
    }
}
