using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMVVM.Exceptions
{
    class EmailDoesNotContainQuickAException : Exception
    {
        public EmailDoesNotContainQuickAException(string message) : base(message)
        {

        }
    }
}
