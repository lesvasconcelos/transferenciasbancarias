using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransferenciasBancarias.Data.DTO
{
    public class TransferenciaDTO
    {
        public string Id { get; set; }
        public string IdUsuario { get; set; }
        public DateTime Data { get; set; }
        public string NomePagador { get; set; }
        public string BancoPagador { get; set; }
        public string AgenciaPagador { get; set; }
        public string ContaPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string BancoBeneficiario { get; set; }
        public string AgenciaBeneficiario { get; set; }
        public string ContaBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
    }
}
