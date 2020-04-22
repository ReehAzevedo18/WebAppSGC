using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.ApplicationCore.Enity
{
    public class Menu
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public int? MenuId { get; set; } //chave estrangeira
        
        public ICollection<Menu> SubMenu { get; set; } //Auto relacionamento: a classe menu está associada a ela mesmo
    }
}
