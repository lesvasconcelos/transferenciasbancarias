using System.Linq;
using Microsoft.AspNet.Mvc;
using TransferenciasBancarias.Data.DTO;
using TransferenciasBancarias.Data.Repositorio;
using TransferenciasBancarias.Lib.Exceptions;
using TransferenciasBancarias.Lib.Extensions;

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
        public IActionResult Get(int page = 1, int pageSize = 50)
        {
            try
            {
                var dto = new ListaTransferenciaDTO();
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

                dto.TotalDeRegistros = lista.TotalDeRegistros;
                dto.SomatorioValor = lista.Dados.Sum(s => s.Valor);
                dto.Pagina = lista.PaginaAtual;
                dto.TamanhoDaPagina = lista.TamanhoDaPagina;

                return Ok(dto);
            }
            catch(ClientException e)
            {
                return HttpBadRequest(e);
            }
            catch(ServerException e)
            {
                return this.HttpInternalServerError(e);
            }
        }

        // POST: api/transferencias
        [HttpPost]
        [Route("[action]")]
        public IActionResult Filter(int page, int pageSize, [FromBody]FiltroTransferenciaDTO filtro)
        {
            try
            {
                var result = new ListaTransferenciaDTO();
                var lista = TransferenciaRepositorio.List(filtro.DataInicial, filtro.DataFinal, filtro.NomePagador, filtro.NomeBeneficiario, page, pageSize);

                result.TotalDeRegistros = lista.TotalDeRegistros;
                result.Dados = lista.Dados.Select(s => new TransferenciaDTO
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
                result.SomatorioValor = lista.Dados.Sum(s => s.Valor);
                result.Pagina = lista.PaginaAtual;
                result.TamanhoDaPagina = lista.TamanhoDaPagina;

                return Ok(result);
            }
            catch (ClientException e)
            {
                return HttpBadRequest(e);
            }
            catch (ServerException e)
            {
                return this.HttpInternalServerError(e);
            }
        }

        // GET api/transferencias/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var entity = TransferenciaRepositorio.Get(id);

                var result = new TransferenciaDTO
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

                return Ok(result);
            }
            catch (ClientException e)
            {
                return HttpBadRequest(e);
            }
            catch (ServerException e)
            {
                return this.HttpInternalServerError(e);
            }
        }

        // POST api/transferencias
        [HttpPost]
        public IActionResult Post([FromBody]TransferenciaDTO model)
        {
            try
            {
                var usuario = UsuarioRepositorio.Get(model.IdUsuario);

                var id = TransferenciaRepositorio.Create(new Data.Model.Transferencia
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

                return Created(Url.Action("Get"), new { id = id });
            }
            catch (ClientException e)
            {
                return HttpBadRequest(e);
            }
            catch (ServerException e)
            {
                return this.HttpInternalServerError(e);
            }
        }
                
        // DELETE api/transferencias/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var entity = TransferenciaRepositorio.Get(id);
                
                TransferenciaRepositorio.Delete(entity);

                return Ok();
            }
            catch (ClientException e)
            {
                return HttpBadRequest(e);
            }
            catch (ServerException e)
            {
                return this.HttpInternalServerError(e);
            }
        }
    }
}
