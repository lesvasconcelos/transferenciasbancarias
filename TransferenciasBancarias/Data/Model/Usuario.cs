using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TransferenciasBancarias.Data.Repositorio;
using TransferenciasBancarias.Lib.Validacao;

namespace TransferenciasBancarias.Data.Model
{
    public class Usuario: TIdentificador
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Cnpj é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo Cnpj aceita, no máximo, 14 dígitos.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "O campo Cnpj aceita somente números.")]
        public string Cnpj { get; set; }
    }
}
