using BankKataOCR.Business;
using BankKataOCR.Business.Data;
using BankKataOCR.Business.Interfaces;
using Moq;
using NUnit.Framework;
using System.IO;

namespace BankOcrKata
{
    public class UserStory3
    {
        [TestCase(@"
 _  _  _  _  _  _  _  _     
| || || || || || || ||_   |
|_||_||_||_||_||_||_| _|  |", "000000051")]
        [TestCase(@"
    _  _  _  _  _  _     _ 
|_||_|| || ||_   |  |  | _ 
  | _||_||_||_|  |  |  | _|", "49006771? ILL")]
        [TestCase(@"
    _  _     _  _  _  _  _ 
  | _| _||_| _ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _ ", "1234?678? ILL")]
        [TestCase( @"
 _  _  _  _  _  _  _  _     
| || || || || || || ||_ |_|
|_||_||_||_||_||_||_| _|  |", "000000054 ERR" )] //Added in extra test case because error wasn't covered
        public void Tests(string input, string expectedResult)
        {
            Mock<IOutputter> outputter = new Mock<IOutputter>();
            IOcrResultsOutputer resultsOutputter = new OcrOutputter( new Mod11CheckSumCalculator(), outputter.Object );
            OCRReader reader = new OCRReader( Constants.NumberSpecifications.Defaults() );

            string result;

            using ( var strReader = new StringReader( input ) )
            {
                result = reader.ReadSingleOCRLine( strReader );
            }

            resultsOutputter.Output( result );

            outputter.Verify( x => x.Output( expectedResult ), Times.Once );
        }
    }
}