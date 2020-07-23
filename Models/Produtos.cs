using System;
using System.Collections.Generic;

namespace consoleApp.Models
{
    public partial class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double? Preco { get; set; }
    }
}
