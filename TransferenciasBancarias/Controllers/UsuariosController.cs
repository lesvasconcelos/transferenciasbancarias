using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TransferenciasBancarias.Data.DTO;
using TransferenciasBancarias.Data.Repositorio;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TransferenciasBancarias.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private UsuarioRepositorio UsuarioRepositorio => UsuarioRepositorio.Instance;

        // GET: api/usuarios
        [HttpGet]
        public IEnumerable<UsuarioDTO> Get()
        {
            var repositorio = UsuarioRepositorio.Instance;
            return repositorio.GetAll();            
        }

        // GET api/usuarios/5
        [HttpGet("{id}")]
        public UsuarioDTO Get(string id)
        {
            var entity = UsuarioRepositorio.Get(id);

            return new UsuarioDTO
            {
                Id = entity.Id.ToString(),
                Cnpj = entity.Cnpj,
                Nome = entity.Nome
            };
        }

        // POST api/usuarios
        [HttpPost]
        public void Post([FromBody]UsuarioDTO model)
        {
            UsuarioRepositorio.Create(new Data.Model.Usuario
            {
                Cnpj = model.Cnpj,
                Nome = model.Nome
            });
        }

        // PUT api/usuarios/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]UsuarioDTO model)
        {
            var entity = UsuarioRepositorio.Get(id);

            entity.Nome = model.Nome;
            entity.Cnpj = model.Cnpj;

            UsuarioRepositorio.Update(id, entity);

        }

        // DELETE api/usuarios/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var entity = UsuarioRepositorio.Get(id);
            UsuarioRepositorio.Delete(entity);
        }
    }
}
