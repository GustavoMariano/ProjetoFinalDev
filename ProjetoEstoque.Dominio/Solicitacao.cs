using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Dominio
{
    public class Solicitacao
    {
        public int Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public String Status { get; set; }

        public DateTime DataFinalizacao { get; set; }

        public String Usuario { get; set; }

        public List<Item> Items { get; set; }

        public String Prioridade { get; set; }

        public Solicitacao()
        {
            Items = new List<Item>();
        }

        public void ValidaSolicitacao()
        {
            if (DataFinalizacao != DateTime.Today)
            {
                throw new Exception("A data de finalização da solicitação deve ser hoje!");
            }
            else if (DataCriacao != DateTime.Today)
            {
                throw new Exception("A data de criação não deve ser diferente de agora!");
            }
        }
    }
}
