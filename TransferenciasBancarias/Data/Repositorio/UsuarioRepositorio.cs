using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransferenciasBancarias.Data.DTO;
using TransferenciasBancarias.Data.Model;
using TransferenciasBancarias.Data.Repositorio;

namespace TransferenciasBancarias.Data.Repositorio
{
    public class UsuarioRepositorio : MongoDBRepositorio<Usuario>
    {
        private static UsuarioRepositorio _instance;
        public static UsuarioRepositorio Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsuarioRepositorio();
                }
                return _instance;
            }
        }
        
        private UsuarioRepositorio() : base() { }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            return Instance.List().Select(s => new UsuarioDTO
            {
                Id = s.Id.ToString(),
                Nome = s.Nome,
                Cnpj = s.Cnpj
            });
        }
    }
}
