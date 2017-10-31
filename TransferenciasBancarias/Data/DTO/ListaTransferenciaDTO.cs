using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransferenciasBancarias.Data.DTO
{
    public class ListaTransferenciaDTO : ListaDTO
    {
        public decimal SomatorioValor { get; set; }
        public IEnumerable<TransferenciaDTO> Dados {get;set;}
    }
}
