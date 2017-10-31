using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TransferenciasBancarias.Lib;

namespace TransferenciasBancarias.Data.Repositorio
{
    public interface IRepositorio<TEntity> where TEntity : TIdentificador
    {
        string Create(TEntity model);
        TEntity Get(string id);
        TEntity Update(string id, TEntity model);
        void Delete(TEntity entity);
        IEnumerable<TEntity> List();
    }
}