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

        public StatusEnum Status { get; set; }

        public DateTime DataFinalizacao { get; set; }

        public String Usuario { get; set; }

        public int Prioridade { get; set; }

        public String Item { get; set; }

        public void ValidaSolicitacao()
        {
            if (DataCriacao != DateTime.Now)
            {
                throw new Exception("A data de criação não deve ser diferente de agora!");
            }
            else if (DataFinalizacao != DateTime.Now)
            {
                throw new Exception("A data de finalização da solicitação não deve ser diferente de agora!");
            }
        }
    }
}
