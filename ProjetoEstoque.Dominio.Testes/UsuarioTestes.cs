// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace ProjetoEstoque.Dominio.Testes
{
    [TestFixture]
    public class UsuarioTestes
    {
        private Usuario _usuario;

        [SetUp]
        public void Inicializador()
        {
            _usuario = new Usuario();
            _usuario.Nome = "Gustavo";
            _usuario.Login = "gustavo";
            _usuario.Setor = "Infra";
            _usuario.Senha = "abc123";
            _usuario.Nivel = 1;
        }

        [Test]
        public void Nome_De_Usuario_Nao_Pode_Ser_Vazio()
        {
            //ARRANGE
            _usuario.Nome = string.Empty;

            //ACTION
            Action resultado = () => _usuario.ValidaUsuario();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("O nome não deve ser vazio!");
        }

        [Test]
        public void Login_Do_Usuario_Nao_Pode_Ser_Vazio()
        {
            //ARRANGE
            _usuario.Login = string.Empty;

            //ACTION
            Action resultado = () => _usuario.ValidaUsuario();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("O login não deve ser vazio!");

        }

        [Test]
        public void Senha_Do_Usuario_Nao_Pode_Ser_Vazio()
        {
            //ARRANGE
            _usuario.Senha = string.Empty;

            //ACTION
            Action resultado = () => _usuario.ValidaUsuario();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("A senha não deve ser vazia!");

        }

        [Test]
        public void Senha_Do_Usuario_Deve_Ter_Mais_De_Cinco_Caracteres()
        {
            //ARRANGE
            _usuario.Senha = "1234";

            //ACTION
            Action resultado = () => _usuario.ValidaUsuario();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("A senha deve conter mais de 6 caracteres!");

        }

        [Test]
        public void Usuario_Deve_Ter_Setor()
        {
            //ARRANGE
            _usuario.Setor = string.Empty;

            //ACTION
            Action resultado = () => _usuario.ValidaUsuario();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("O usuario deve ter setor!");

        }

        [Test]
        public void Usuario_Deve_Ter_Nivel()
        {
            //ARRANGE
            _usuario.Nivel = 0;

            //ACTION
            Action resultado = () => _usuario.ValidaUsuario();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("O usuario deve ter nivel de permissão!");

        }

        
    }
}
