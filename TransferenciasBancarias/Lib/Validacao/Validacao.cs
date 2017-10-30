using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransferenciasBancarias.Lib.Validacao
{
    public abstract class Validacao
    {
        public ResultadoValidacao Valida()
        {
            var valido = false;
            var context = new ValidationContext(this, null, null);
            var results = new List<ValidationResult>();
            if (Validator.TryValidateObject(this, context, results, true))
            {
                valido = true;
            }

            return new ResultadoValidacao(valido, results);
        }
    }
}
