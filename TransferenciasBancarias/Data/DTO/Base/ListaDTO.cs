using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransferenciasBancarias.Data.DTO
{
    public class ListaDTO
    {
        public long TotalDeRegistros { get; set; }
        public long Pagina { get; set; }
        public long TamanhoDaPagina { get; set; }
    }
}
