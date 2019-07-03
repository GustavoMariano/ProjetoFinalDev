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

        public String Item1 { get; set; }

        public String Item2 { get; set; }

        public String Item3 { get; set; }

        public int Qtd1 { get; set; }

        public int Qtd2 { get; set; }

        public int Qtd3 { get; set; }

        public String Prioridade { get; set; }


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
            else if (String.IsNullOrEmpty(Status))
            {
                throw new Exception("O status da solicitação não deve estar vazia!");
            }
            
        }
    }
}
