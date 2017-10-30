using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransferenciasBancarias.Data.DTO
{
    public class FiltroTransferenciaDTO
    {
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string NomePagador { get; set; }
        public string NomeBeneficiario { get; set; }

    }
}
