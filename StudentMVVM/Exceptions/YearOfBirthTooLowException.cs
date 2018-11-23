using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMVVM.Exceptions
{
    class YearOfBirthTooLowException : Exception
    {
        public YearOfBirthTooLowException(string message) : base(message)
        {

        }
    }
}
