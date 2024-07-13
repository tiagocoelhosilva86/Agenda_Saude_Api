using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSaude.Api.Domain.Validations
{
    public class DomainExceptionsValidation : Exception
    {
        public DomainExceptionsValidation(string error):base(error) 
        { 
        }

        public static void ValidateError(bool Error, string error) 
        { 
            if(Error)
            {
                throw new DomainExceptionsValidation(error);
            }
        }
    }
}
