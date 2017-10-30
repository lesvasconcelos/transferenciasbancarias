using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TransferenciasBancarias.Data.DTO;
using TransferenciasBancarias.Data.Repositorio;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TransferenciasBancarias.Controllers
{
    [Route("api/[controller]")]
    public class TransferenciasController : Controller
    {
        private TransferenciaRepositorio TransferenciaRepositorio => TransferenciaRepositorio.Instance;
        private UsuarioRepositorio UsuarioRepositorio => UsuarioRepositorio.Instance;

        // GET: api/transferencias
        [HttpGet]
        public ListaDTO<TransferenciaDTO> Get(int page = 1, int pageSize = 50)
        {
            var dto = new ListaDTO<TransferenciaDTO>();
            var lista = TransferenciaRepositorio.List(page: page, pageSize: pageSize);

            dto.Dados = lista.Dados.Select(s => new TransferenciaDTO
            {
                AgenciaBeneficiario = s.AgenciaBeneficiario,
                AgenciaPagador = s.AgenciaPagador,
                BancoBeneficiario = s.BancoBeneficiario,
                BancoPagador = s.BancoPagador,
                ContaBeneficiario = s.ContaBeneficiario,
                ContaPagador = s.ContaPagador,
                Data = s.Data,
                Id = s.Id.ToString(),
                IdUsuario = s.IdUsuario.ToString(),
                NomeBeneficiario = s.NomeBeneficiario,
                NomePagador = s.NomePagador,
                Status = s.Status,
                Tipo = s.Tipo,
                Valor = s.Valor
            });

            dto.Contagem = lista.TotalDeRegistros;
            dto.Soma = lista.Dados.Sum(s => s.Valor);

            return dto;
        }

        // POST: api/transferencias
        [HttpPost]
        [Route("[action]")]
        public ListaDTO<TransferenciaDTO> Filter(int page, int pageSize, [FromBody]FiltroTransferenciaDTO filtro)
        {
            var lista = TransferenciaRepositorio.List(filtro.DataInicial, filtro.DataFinal, filtro.NomePagador, filtro.NomeBeneficiario, page, pageSize);

            return new ListaDTO<TransferenciaDTO>
            {
                Contagem = lista.TotalDeRegistros,
                Dados = lista.Dados.Select(s => new TransferenciaDTO
                {
                    AgenciaBeneficiario = s.AgenciaBeneficiario,
                    AgenciaPagador = s.AgenciaPagador,
                    BancoBeneficiario = s.BancoBeneficiario,
                    BancoPagador = s.BancoPagador,
                    ContaBeneficiario = s.ContaBeneficiario,
                    ContaPagador = s.ContaPagador,
                    Data = s.Data,
                    Id = s.Id.ToString(),
                    IdUsuario = s.IdUsuario.ToString(),
                    NomeBeneficiario = s.NomeBeneficiario,
                    NomePagador = s.NomePagador,
                    Status = s.Status,
                    Tipo = s.Tipo,
                    Valor = s.Valor
                }),
                Soma = lista.Dados.Sum(s => s.Valor)
            };
        }

        // GET api/transferencias/5
        [HttpGet("{id}")]
        public TransferenciaDTO Get(string id)
        {
            var entity = TransferenciaRepositorio.Get(id);

            return new TransferenciaDTO
            {
                AgenciaBeneficiario = entity.AgenciaBeneficiario,
                AgenciaPagador = entity.AgenciaPagador,
                BancoBeneficiario = entity.BancoBeneficiario,
                BancoPagador = entity.BancoPagador,
                ContaBeneficiario = entity.ContaBeneficiario,
                ContaPagador = entity.ContaPagador,
                Id = entity.Id.ToString(),
                IdUsuario = entity.IdUsuario.ToString(),
                NomeBeneficiario = entity.NomeBeneficiario,
                NomePagador = entity.NomePagador,
                Status = entity.Status,
                Tipo = entity.Tipo,
                Valor = entity.Valor
            };
        }

        // POST api/transferencias
        [HttpPost]
        public void Post([FromBody]TransferenciaDTO model)
        {
            var usuario = UsuarioRepositorio.Get(model.IdUsuario);

            TransferenciaRepositorio.Create(new Data.Model.Transferencia
            {
                AgenciaBeneficiario = model.AgenciaBeneficiario,
                AgenciaPagador = model.AgenciaPagador,
                BancoBeneficiario = model.BancoBeneficiario,
                BancoPagador = model.BancoPagador,
                ContaBeneficiario = model.ContaBeneficiario,
                ContaPagador = model.ContaPagador,
                IdUsuario = usuario.Id,
                NomeBeneficiario = model.NomeBeneficiario,
                NomePagador = model.NomePagador,
                Valor = model.Valor
            });
        }
                
        // DELETE api/transferencias/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var entity = TransferenciaRepositorio.Get(id);

            TransferenciaRepositorio.Delete(entity);
        }
    }
}
