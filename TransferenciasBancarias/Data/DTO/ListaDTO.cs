using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransferenciasBancarias.Data.DTO
{
    public class ListaDTO<T> where T : class
    {
        public decimal Soma { get; set; }
        public long Contagem { get; set; }
        public IEnumerable<T> Dados {get;set;}
    }
}
