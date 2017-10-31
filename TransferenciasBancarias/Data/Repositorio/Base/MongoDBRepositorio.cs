using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TransferenciasBancarias.Lib;
using TransferenciasBancarias.Lib.Configuracao;
using TransferenciasBancarias.Lib.Exceptions;

namespace TransferenciasBancarias.Data.Repositorio
{
    public class MongoDBRepositorio<TEntity> : IRepositorio<TEntity> where TEntity : TIdentificador
    {
        private readonly IMongoDatabase database;

        public MongoDBRepositorio()
        {
            var client = new MongoClient(Configuracoes.MongoDbConnection);
            database = client.GetDatabase(Configuracoes.MongoDbDatabase);
        }

        public string Create(TEntity entity)
        {
            var validacao = entity.Valida();

            if (!validacao.Valido)
            {
                throw new ValidationException(validacao.Erros);
            }

            try
            {
                GetCollection().InsertOne(entity);

                return entity.Id.ToString();
            }
            catch(Exception e)
            {
                throw new MongoDbException(e);
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                GetCollection().DeleteOneAsync(x => x.Id.Equals(entity.Id));
            }
            catch (Exception e)
            {
                throw new MongoDbException(e);
            }
        }
        
        public TEntity Get(string id)
        {
            try
            {
                return GetCollection().Find(x => x.Id == new ObjectId(id)).First();
            }
            catch (Exception e)
            {
                throw new MongoDbException(e);
            }
        }

        protected IMongoCollection<TEntity> GetCollection()
        {
            return database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public IEnumerable<TEntity> List()
        {
            try
            {
                return GetCollection().AsQueryable().ToList();
            }
            catch (Exception e)
            {
                throw new MongoDbException(e);
            }
        }
                
        public TEntity Update(string id, TEntity entity)
        {
            var validacao = entity.Valida();

            if (!validacao.Valido)
            {
                throw new ValidationException(validacao.Erros);
            }

            try
            {
                GetCollection().ReplaceOne(x => x.Id == new ObjectId(id), entity);

                return entity;
            }
            catch (Exception e)
            {
                throw new MongoDbException(e);
            }
        }

    }
}
