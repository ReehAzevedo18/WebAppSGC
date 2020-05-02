using SGC.ApplicationCore.Enity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGC.ApplicationCore.Interfaces.Repository.Services
{
    public interface IClienteService
    {
        Cliente Adicionar(Cliente entity);

        void Atualizar(Cliente entity);

        IEnumerable<Cliente> ObterTodos(); //retornando uma coleção

        Cliente ObterPorId(int id);

        IEnumerable<Cliente> Buscar(Expression<Func<Cliente, bool>> predicado); //cria buscas especificas

        void Remover(Cliente entity);

    }
}
