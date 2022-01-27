using BankKataOCR.Business.Data;
using BankKataOCR.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankKataOCR.Business
{
    public class OcrOutputter : IOcrResultsOutputer
    {
        private readonly ICheckSumCalculator _sumCalculator;
        private readonly IOutputter _outputter;

        public OcrOutputter( ICheckSumCalculator sumCalculator, IOutputter outputter )
        {
            _sumCalculator = sumCalculator;
            _outputter = outputter;
        }

        public void Output( string ocrValue )
        {
            _outputter.Output( GetOutputValue( ocrValue, _sumCalculator ) );
        }

        private static string GetOutputValue( string ocrValue, ICheckSumCalculator checkSumCalculator )
        {
            if ( ocrValue.Contains( "?" ) )
            {
                return ocrValue + Constants.Space + Constants.ReadErrorIndicator;
            }

            return checkSumCalculator.IsCheckSumValid( ocrValue ) ? 
                    ocrValue : 
                    ocrValue + Constants.Space + Constants.CheckSumFailedIndicator;
        }
    }
}
