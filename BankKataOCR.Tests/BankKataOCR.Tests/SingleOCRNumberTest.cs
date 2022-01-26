using BankKataOCR.Business.Data;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankKataOCR.Tests
{
    public class SingleOCRNumberTest
    {
        [Test]
        public void SingleOCRNumber_Zero_Test()
        {
            SingleOCRNumber.Builder builder = new SingleOCRNumber.Builder( new List<Business.NumberSpecification>() { Constants.NumberSpecifications.ZeroSpecification } );

            builder.SetLetter( Constants.Space );
            builder.SetLetter( Constants.Underscore );
            builder.SetLetter( Constants.Space );

            builder.SetLetter( Constants.Pipe );
            builder.SetLetter( Constants.Space );
            builder.SetLetter( Constants.Pipe );

            builder.SetLetter( Constants.Pipe );
            builder.SetLetter( Constants.Underscore );
            builder.SetLetter( Constants.Pipe );

            var number = builder.Build();

            number.Number.Should().Be( 0 );
        }
    }
}
