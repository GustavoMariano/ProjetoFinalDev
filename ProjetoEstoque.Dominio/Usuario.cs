using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public void Validacao()
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("O nome não deve ser vazio!");
            }
        }

    }
}
