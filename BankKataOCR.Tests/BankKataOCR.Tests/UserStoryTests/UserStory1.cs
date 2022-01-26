using BankKataOCR.Business;
using BankKataOCR.Business.Data;
using BankKataOCR.Business.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System.IO;

namespace BankOcrKata
{

    //FYI I think the Kata is wrong, the description is that the fourth line is blank,
    ////but the example data it gives and is used as part of these tests use the first line as blank
    [TestFixture]
    public class UserStory1
    {
        [TestCase(@"
 _  _  _  _  _  _  _  _  _
| || || || || || || || || |
|_||_||_||_||_||_||_||_||_|", "000000000", TestName = "Zero")]
        [TestCase(@"                         
                           
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |", "111111111", TestName = "One" )]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
 _| _| _| _| _| _| _| _| _|
|_ |_ |_ |_ |_ |_ |_ |_ |_ ", "222222222", TestName = "Two" )]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _
 _| _| _| _| _| _| _| _| _|
 _| _| _| _| _| _| _| _| _|", "333333333", TestName = "Three" )]
        [TestCase(@"
                           
|_||_||_||_||_||_||_||_||_|
  |  |  |  |  |  |  |  |  |", "444444444", TestName = "Four" )]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
 _| _| _| _| _| _| _| _| _|", "555555555", TestName = "Five" )]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
|_||_||_||_||_||_||_||_||_|", "666666666", TestName = "Siz" )]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |", "777777777", TestName = "Seven" )]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
|_||_||_||_||_||_||_||_||_|", "888888888", TestName = "Eight" )]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
 _| _| _| _| _| _| _| _| _|", "999999999", TestName = "Nine" )]
        [TestCase(@"
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|", "123456789", TestName = "1-9_Sequence")]
        public void Tests(string input, string expectedResult)
        {
            IOCRReader reader = new OCRReader( Constants.NumberSpecifications.Defaults() );

            string actual;

            using ( var strReader = new StringReader( input ) )
            {
                actual = reader.ReadSingleOCRLine( strReader );
            }

            actual.Should().Be( expectedResult );
        }
    }
}