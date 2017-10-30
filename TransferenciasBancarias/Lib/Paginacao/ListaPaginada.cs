using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransferenciasBancarias.Lib.Paginacao
{
    public class ListaPaginada<T> where T : class
    {
        public long TotalDeRegistros { get; set; }
        public int PaginaAtual { get; set; }
        public int TamanhoDaPagina { get; set; }
        public IEnumerable<T> Dados { get; set; }
    }
}
