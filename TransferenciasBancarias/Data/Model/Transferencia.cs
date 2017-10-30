using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TransferenciasBancarias.Data.Repositorio.Base;

namespace TransferenciasBancarias.Data.Model
{
    public class Transferencia : TIdentificador
    {
        [Required]
        public ObjectId IdUsuario { get; set; }

        [Required]
        [StringLength(128)]
        public string NomePagador { get; set; }

        [Required]
        [StringLength(3)]
        public string BancoPagador { get; set; }

        [Required]
        [StringLength(4)]
        public string AgenciaPagador { get; set; }

        [Required]
        [StringLength(6)]
        public string ContaPagador { get; set; }

        [Required]
        [StringLength(128)]
        public string NomeBeneficiario { get; set; }

        [Required]
        [StringLength(3)]
        public string BancoBeneficiario { get; set; }

        [Required]
        [StringLength(4)]
        public string AgenciaBeneficiario { get; set; }

        [Required]
        [StringLength(6)]
        public string ContaBeneficiario { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999999999999.99)]
        public decimal Valor { get; set; }

        [Required]
        [StringLength(4)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(12)]
        public string Status { get; set; }

        [Required]
        public bool Removido { get; set; }

        #region Definição de constantes
        public class Tipos {
            public const string CC = "CC";
            public const string DOC = "DOC";
            public const string TED = "TED";
        }

        public class Statuses {
            public const string OK = "OK";
            public const string ERRO = "ERRO";
        }
        #endregion


    }
}
