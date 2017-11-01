using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TransferenciasBancarias.Data.Repositorio;

namespace TransferenciasBancarias.Data.Model
{
    public class Transferencia : TIdentificador
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo IdUsuario é obrigatório.")]
        public ObjectId IdUsuario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo NomePagador é obrigatório.")]
        [StringLength(128, ErrorMessage = "O campo NomePagador aceita, no máximo, 128 caracteres.")]
        public string NomePagador { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo BancoPagador é obrigatório.")]
        [StringLength(3, ErrorMessage = "O campo BancoPagador aceita, no máximo, 3 caracteres.")]
        public string BancoPagador { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo AgenciaPagador é obrigatório.")]
        [StringLength(4, ErrorMessage = "O campo AgenciaPagador aceita, no máximo, 4 caracteres.")]
        public string AgenciaPagador { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo ContaPagador é obrigatório.")]
        [StringLength(6, ErrorMessage = "O campo ContaPagador aceita, no máximo, 6 caracteres.")]
        public string ContaPagador { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo NomeBeneficiario é obrigatório.")]
        [StringLength(128, ErrorMessage = "O campo NomeBeneficiario aceita, no máximo, 128 caracteres.")]
        public string NomeBeneficiario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo BancoBeneficiario é obrigatório.")]
        [StringLength(3, ErrorMessage = "O campo BancoBeneficiario aceita, no máximo, 3 caracteres.")]
        public string BancoBeneficiario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo AgenciaBeneficiario é obrigatório.")]
        [StringLength(4, ErrorMessage = "O campo AgenciaBeneficiario aceita, no máximo, 4 caracteres.")]
        public string AgenciaBeneficiario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo ContaBeneficiario é obrigatório.")]
        [StringLength(6, ErrorMessage = "O campo ContaBeneficiario aceita, no máximo, 6 caracteres.")]
        public string ContaBeneficiario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Data é obrigatório.")]
        public DateTime Data { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Valor é obrigatório.")]
        [Range(0, 999999999999999.99, ErrorMessage = "O campo Valor precisa ser um número válido.")]
        public decimal Valor { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Tipo é obrigatório.")]
        [StringLength(4, ErrorMessage = "O campo Tipo aceita, no máximo, 4 caracteres.")]
        public string Tipo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Status é obrigatório.")]
        [StringLength(12, ErrorMessage = "O campo Status aceita, no máximo, 12 caracteres.")]
        public string Status { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Removido é obrigatório.")]
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
