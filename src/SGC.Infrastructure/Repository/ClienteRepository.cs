using SGC.ApplicationCore.Enity;
using SGC.ApplicationCore.Interfaces.Repository;
using SGC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SGC.Infrastructure.Repository
{
    //essa classe herda todos os metodos padroes do EFRepository + IClienteRepository que tem um metodo especifico
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        //nesse caso é necessário ter um construtor
        public ClienteRepository(ClienteContext dbContext) : base(dbContext)
        {

        }
        public Cliente ObterPorProfissao(int clienteId)
        {
            //Buscando a profissao do cliente a primeira cadastrada
            return Buscar(x => x.ProfissoesClientes.Any(p => p.ClienteId == clienteId))
                .FirstOrDefault();
        }
    }
}
