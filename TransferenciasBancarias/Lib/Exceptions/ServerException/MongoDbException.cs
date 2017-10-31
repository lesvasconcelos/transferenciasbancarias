using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransferenciasBancarias.Lib.Exceptions
{
    public class MongoDbException : ServerException
    {
        public MongoDbException(Exception e) : base("Ocorreu um erro interno no processamento da sua requisição.", e) { }
    }
}
