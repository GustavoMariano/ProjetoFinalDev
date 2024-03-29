﻿using System;
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

        public int Nivel { get; set; }

        public string Setor { get; set; }

        public void ValidaUsuario()
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("O nome não deve ser vazio!");
            }
            else if (String.IsNullOrEmpty(Login))
            {
                throw new Exception("O login não deve ser vazio!");
            }
            else if (String.IsNullOrEmpty(Senha))
            {
                throw new Exception("A senha não deve ser vazia!");
            }
            else if (Senha.Length < 6)
            {
                throw new Exception("A senha deve conter mais de 6 caracteres!");
            }
            else if (String.IsNullOrEmpty(Setor))
            {
                throw new Exception("O usuario deve ter setor!");
            }
            else if (Nivel == 0)
            {
                throw new Exception("O usuario deve ter nivel de permissão!");
            }
            
        }

    }
}
