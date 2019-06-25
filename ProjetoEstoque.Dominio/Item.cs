using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Dominio
{
    public class Item
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }
    }
}
