using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TransferenciasBancarias.Data.DTO;
using TransferenciasBancarias.Data.Repositorio;
using TransferenciasBancarias.Lib.Exceptions;
using TransferenciasBancarias.Lib.Extensions;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TransferenciasBancarias.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private UsuarioRepositorio UsuarioRepositorio => UsuarioRepositorio.Instance;

        // GET: api/usuarios
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(UsuarioRepositorio.GetAll());
            }
            catch (ClientException e)
            {
                return HttpBadRequest(new { e.Message });
            }
            catch (ServerException e)
            {
                return this.HttpInternalServerError(e);
            }
        }

        // GET api/usuarios/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var entity = UsuarioRepositorio.Get(id);

                var result = new UsuarioDTO
                {
                    Id = entity.Id.ToString(),
                    Cnpj = entity.Cnpj,
                    Nome = entity.Nome
                };

                return Ok(result);
            }
            catch (ClientException e)
            {
                return HttpBadRequest(new { e.Message });
            }
            catch (ServerException e)
            {
                return this.HttpInternalServerError(e);
            }
        }

        // POST api/usuarios
        [HttpPost]
        public IActionResult Post([FromBody]UsuarioDTO model)
        {
            try
            {
                var id = UsuarioRepositorio.Create(new Data.Model.Usuario
                {
                    Cnpj = model.Cnpj,
                    Nome = model.Nome
                });

                return Created(Url.Action("get","usuarios"), new { id = id });
            }
            catch (ClientException e)
            {
                return HttpBadRequest(new { e.Message });
            }
            catch (ServerException e)
            {
                return this.HttpInternalServerError(e);
            }
        }

        // PUT api/usuarios/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]UsuarioDTO model)
        {
            try
            {
                var entity = UsuarioRepositorio.Get(id);

                entity.Nome = model.Nome;
                entity.Cnpj = model.Cnpj;

                UsuarioRepositorio.Update(id, entity);

                return Ok(entity);
            }
            catch (ClientException e)
            {
                return HttpBadRequest(new { e.Message });
            }
            catch (ServerException e)
            {
                return this.HttpInternalServerError(e);
            }

        }

        // DELETE api/usuarios/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var entity = UsuarioRepositorio.Get(id);

                UsuarioRepositorio.Delete(entity);

                return Ok();
            }
            catch (ClientException e)
            {
                return HttpBadRequest(new { e.Message });
            }
            catch (ServerException e)
            {
                return this.HttpInternalServerError(e);
            }
        }
    }
}
