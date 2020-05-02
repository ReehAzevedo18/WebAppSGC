using SGC.ApplicationCore.Enity;
using SGC.ApplicationCore.Interfaces.Repository;
using SGC.ApplicationCore.Interfaces.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGC.ApplicationCore.Services
{
    public class ClienteService : IClienteService
    {
        //é necessario criar uma variavel que alocará o repositorio
        private readonly IClienteRepository _clienteRepository;

        //cria-se um construtor com uma variavel, esse variavel receberá os dados do repositorios
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

   
        public Cliente Adicionar(Cliente entity)
        {
            //TODO: A regra de negocio do sistema deverá ficar nessa camada, dentro dos metodos
            return _clienteRepository.Adicionar(entity); //ao chamar o metodo é necessario apenas chamar o que deseja pela variavel de repositorio
        }

        public void Atualizar(Cliente entity)
        {
            _clienteRepository.Atualizar(entity);
        }

        public IEnumerable<Cliente> Buscar(Expression<Func<Cliente, bool>> predicado)
        {
            return _clienteRepository.Buscar(predicado);

        }

        public Cliente ObterPorId(int id)
        {
           return _clienteRepository.ObterPorId(id);

        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();

        }

        public void Remover(Cliente entity)
        {
            _clienteRepository.Remover(entity);

        }
    }
}
