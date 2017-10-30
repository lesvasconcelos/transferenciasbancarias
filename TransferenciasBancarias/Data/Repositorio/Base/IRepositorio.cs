using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TransferenciasBancarias.Lib;

namespace TransferenciasBancarias.Data.Repositorio.Base
{
    public interface IRepositorio<TEntity> where TEntity : TIdentificador
    {
        void Create(TEntity model);
        TEntity Get(string id);
        void Update(string id, TEntity model);
        void Delete(TEntity entity);
        IEnumerable<TEntity> List();
    }
}