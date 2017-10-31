using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransferenciasBancarias.Lib.Exceptions
{
    public class ValidationException : ClientException
    {
        public ValidationException(IEnumerable<ValidationResult> erros)
            : base(string.Join(";", erros?.Select(s => s.ErrorMessage).ToList()))
        { }
    }
}
