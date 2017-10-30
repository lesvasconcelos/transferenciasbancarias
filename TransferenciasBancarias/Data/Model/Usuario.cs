using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TransferenciasBancarias.Data.Repositorio.Base;
using TransferenciasBancarias.Lib.Validacao;

namespace TransferenciasBancarias.Data.Model
{
    public class Usuario: TIdentificador
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }
    }
}
