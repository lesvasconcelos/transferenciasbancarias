using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransferenciasBancarias.Data.Model;
using TransferenciasBancarias.Data.Repositorio.Base;
using TransferenciasBancarias.Lib.Paginacao;

namespace TransferenciasBancarias.Data.Repositorio
{
    public class TransferenciaRepositorio : MongoDBRepositorio<Transferencia>
    {
        private static TransferenciaRepositorio _instance;
        public static TransferenciaRepositorio Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TransferenciaRepositorio();
                }
                return _instance;
            }
        }

        public TransferenciaRepositorio() : base() { }

        public new void Create(Transferencia entity)
        {
            entity.Removido = false;
            entity.Data = DateTime.UtcNow;

            if (entity.BancoBeneficiario == entity.BancoPagador)
            {
                entity.Tipo = Transferencia.Tipos.CC;
            }
            else if(entity.Data.Hour >= 10 && entity.Data.Hour < 16 && entity.Valor <= 5000)
            {
                entity.Tipo = Transferencia.Tipos.TED;
            }
            else
            {
                entity.Tipo = Transferencia.Tipos.DOC;
            }

            if (entity.Valor > 100000)
            {
                entity.Status = Transferencia.Statuses.ERRO;
            }
            else
            {
                entity.Status = Transferencia.Statuses.OK;
            }

            base.Create(entity);
        }

        public void Delete(string id)
        {
            var entity = Get(id);

            entity.Removido = true;

            Update(id, entity);
        }

        public new Transferencia Get(string id)
        {
            var entity = base.Get(id);

            if (entity.Removido)
            {
                return null;
            }

            return entity;
        }

        public ListaPaginada<Transferencia> List(DateTime? dataInicial = null, DateTime? dataFinal = null, string nomePagador = "", string nomeBeneficiario = "", int page = 1, int pageSize = 50)
        {
            var builder = Builders<Transferencia>.Filter;
            var filter = builder.Eq(x => x.Removido, false);
             
            if (dataInicial.HasValue)
            {
                filter &= builder.Gte(x => x.Data, dataInicial.Value);
            }

            if (dataFinal.HasValue)
            {
                filter &= builder.Lte(x => x.Data, dataFinal.Value);
            }

            if (!string.IsNullOrEmpty(nomePagador))
            {
                filter &= builder.Eq(x => x.NomePagador, nomePagador);
            }

            if (!string.IsNullOrEmpty(nomeBeneficiario))
            {
                filter &= builder.Eq(x => x.NomeBeneficiario, nomeBeneficiario);
            }

            var query = GetCollection().Find(filter)
                .SortBy(s => s.Data);

            var total = query.Count();
            var dados = query
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToList();

            return new ListaPaginada<Transferencia>
            {
                Dados = dados,
                PaginaAtual = page,
                TamanhoDaPagina = pageSize,
                TotalDeRegistros = total
            };
        }
    }
}
