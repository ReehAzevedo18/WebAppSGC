using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGC.ApplicationCore.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

        IEnumerable<TEntity> ObterTodos(); //retornando uma coleção

        TEntity ObterPorId(int id);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado); //cria buscas especificas

        void Remover(TEntity entity);
        
    }
}
