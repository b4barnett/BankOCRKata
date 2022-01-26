using NUnit.Framework;
using BankKataOCR.Business;
using BankKataOCR.Business.Data;
using FluentAssertions;

namespace BankKataOCR.Tests
{
    public class NumberSpecificationTests
    {
        [Test]
        public void TestNumberSpecification_Success()
        {
            char[,] match = { { 'a', 'b', 'c', },
                              { 'd', 'e', 'f', },
                              { 'g', 'h', 'i' } };

            char[,] input = { { 'a', 'b', 'c', },
                              { 'd', 'e', 'f', },
                              { 'g', 'h', 'i' } };


            NumberSpecification specification = new NumberSpecification( match, 99 );

            var result = specification.Match( input );

            result.IsSuccessful.Should().BeTrue();
            result.Value.Should().Be( 99 );
        }
    }
}
