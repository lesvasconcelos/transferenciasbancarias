using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using TransferenciasBancarias.Lib.Validacao;

namespace TransferenciasBancarias.Data.Repositorio.Base
{
    public class TIdentificador : Validacao
    {
        [BsonId]
        public ObjectId Id {get;set;}
    }
}
