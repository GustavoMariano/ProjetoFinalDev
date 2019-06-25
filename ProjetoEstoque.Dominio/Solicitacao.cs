using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Dominio
{
    class Solicitacao
    {
        public int Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public StatusEnum Status { get; set; }

        public DateTime DataFinalizacao { get; set; }

        public Usuario Usuario { get; set; }

        public List<Item> Items { get; set; }

        public Solicitacao()
        {
            Usuario = new Usuario();
            Items = new List<Item>();
        }
    }
}
