using FluentAssertions;
using NUnit.Framework;

namespace BankOcrKata
{
    [TestFixture]
    public class UserStory2
    {
        [TestCase( "711111111", true )]
        [TestCase( "123456789", true )]
        [TestCase( "490867715", true )]
        [TestCase( "888888888", false )]
        [TestCase( "490067715", false )]
        [TestCase( "012345678", false )]
        public void Tests( string accountNumber, bool isValid )
        {
            DoCheckSome( accountNumber.ToCharArray(), isValid );
        }

        private static void DoCheckSome( char[] charArray, bool result )
        {
            int total = 0;
            int counter = 9;
            foreach ( var c in charArray )
            {
                int value = int.Parse( c.ToString() );
                total += ( value * counter );
                counter = counter - 1;
            }

            int modulus = total % 11;

            modulus.Equals( 0 ).Should().Be( result );
        }
    }
}