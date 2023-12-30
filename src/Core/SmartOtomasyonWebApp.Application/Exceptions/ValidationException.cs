using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Exceptions
{
    public class ValidationException : Exception
    {
        //Custom Exception Bu Katmanda Verilir.
        public ValidationException(): this("Validation error ocurred")
        {

        }

        public ValidationException(String Message):base(Message)
        {

        }

        public ValidationException(Exception ex) : this(ex.Message)
        {

        }
    }
}
