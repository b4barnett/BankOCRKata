using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankKataOCR.Business.Interfaces
{
    public interface IOcrResultsOutputer
    {
        void Output( string ocrValue );
    }
}
