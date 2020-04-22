using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.ApplicationCore.Enity
{
    public class Cliente
    {
        public Cliente()
        {

        }

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public ICollection<Contato> Contatos { get; set; } //ICollection uma pessoa pode ter um ou varios contatos, então ele pode ter uma coleção de contatos
        public Endereco Endereco { get; set; } //chave estrangeira
        public ICollection<ProfissaoCliente> ProfissoesClientes { get; set; }


    }
}
