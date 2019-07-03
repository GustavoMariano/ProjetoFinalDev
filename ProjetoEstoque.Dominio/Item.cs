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


        public void ValidaItem()
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("O nome não deve ser vazio!");
            }
            else if (Nome.Length < 3)
            {
                throw new Exception("O nome do item não pode ter menos de 3 caracteres!");
            }
            else if (Descricao.Length < 6)
            {
                throw new Exception("A descrição deve ter mais de cinco caracteres!");
            }
        }
    }
}
