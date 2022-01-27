using BankKataOCR.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankKataOCR.Business
{
    public class Mod11CheckSumCalculator : ICheckSumCalculator
    {
        public bool IsCheckSumValid( string accountNumber )
        {
            char[] charArray = accountNumber.ToCharArray();

            int total = 0;
            int counter = 9;
            foreach ( var c in charArray )
            {
                int value = int.Parse( c.ToString() );
                total += ( value * counter );
                counter = counter - 1;
            }

            return total % 11 == 0;
        }
    }
}
