using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TransferenciasBancarias.Lib;
using TransferenciasBancarias.Lib.Configuracao;

namespace TransferenciasBancarias.Data.Repositorio.Base
{
    public class MongoDBRepositorio<TEntity> : IRepositorio<TEntity> where TEntity : TIdentificador
    {
        private readonly IMongoDatabase database;

        public MongoDBRepositorio()
        {
            var client = new MongoClient(Configuracoes.MongoDbConnection);
            database = client.GetDatabase(Configuracoes.MongoDbDatabase);
        }

        public void Create(TEntity entity)
        {
            var validacao = entity.Valida();

            if (validacao.Valido)
            {
                GetCollection().InsertOne(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            GetCollection().DeleteOneAsync(x => x.Id.Equals(entity.Id));
        }
        
        public TEntity Get(string id)
        {
            return GetCollection().Find(x => x.Id == new ObjectId(id)).First();
        }

        protected IMongoCollection<TEntity> GetCollection()
        {
            return database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public IEnumerable<TEntity> List()
        {
            return GetCollection().AsQueryable().ToList();
        }
                
        public void Update(string id, TEntity entity)
        {
            var validacao = entity.Valida();

            if (validacao.Valido)
            {
                GetCollection().ReplaceOne(x => x.Id == new ObjectId(id), entity);
            }
        }

    }
}
