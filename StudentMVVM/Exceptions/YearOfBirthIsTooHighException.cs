using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMVVM.Exceptions
{
    class YearOfBirthIsTooHighException : Exception
    {
        public YearOfBirthIsTooHighException(string message) : base(message)
        {

        }
    }
}
