using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SGC.ApplicationCore.Enity;

namespace SGC.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ClienteContext context)
        {
            //Se a tabela clientes já estiver preenchido o proceso não irá fazer nada
            if (context.Clientes.Any())
            {
                return;
            }

            var clientes = new Cliente[]
            {
                new Cliente
                {
                    Nome = "Fulano",
                    CPF = "11111111111"
                },

                new Cliente
                {
                    Nome = "Beltrano",
                    CPF = "22233311233"
                }
            };

            context.AddRange(clientes); // vai salvar os clientes escritos anteriormente

            var contatos = new Contato[]
            {
                new Contato
                {
                    Nome = "Contato1",
                    Telefone = "99999999",
                    Email = "emaildeteste@contato.com",
                    Cliente = clientes[0]
                },

                new Contato
                {
                    Nome = "Contato2",
                    Telefone = "12345567889",
                    Email = "emaildeteste@contato.com",
                    Cliente = clientes[1]
                }
            };

            context.AddRange(contatos); //add o range de contatos

            context.SaveChanges(); //salvando os dados
        }
    }
}
