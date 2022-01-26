using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankKataOCR.Business.Data
{
    //Really poor imitation of a Maybe/Option object, but could be converted
    //to a Scoring/Weighting class for part 4
    public sealed class Result<T>
    {
        public static Result<T> Failure() => new Result<T>();
        public static Result<T> Success( T value ) => new Result<T>( value );

        public bool IsSuccessful { get; }

        private Result()
        {
            IsSuccessful = false;
            Value = default( T );
        }

        public T Value { get; }

        private Result( T value )
        {
            Value = value;
            IsSuccessful = true;

        }
    }
}
