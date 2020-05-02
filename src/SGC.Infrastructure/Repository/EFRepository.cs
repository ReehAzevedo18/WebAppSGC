using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Interfaces.Repository;
using SGC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SGC.Infrastructure.Repository
{
    //Herdando a classe TEntity da camada Domain
    class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        //Crio uma variavel para representar a conexão do banco
        private readonly ClienteContext _dbContext;
        public EFRepository(ClienteContext dbContext) //crio um metodo construtor para usar a variavl anterior ligando a variavel dessa classe
        {
            _dbContext = dbContext;
        }

        //o virtual serve para aplicar polimorfismo, o método será sobescrito
        public virtual TEntity Adicionar(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity); //adicionando ao banco
            _dbContext.SaveChanges(); // salvando no banco
            return entity;

        }

        public virtual void Atualizar(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return _dbContext.Set<TEntity>().Where(predicado).AsEnumerable();
        }

        public virtual TEntity ObterPorId(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
            //return _dbContext.Set<TEntity>().Where(q => q.Id == id); //poderia ser feito assim, pegando o nome da chave primaria e comparando com a chave que será recebida
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public void Remover(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
            
        }
    }
}
