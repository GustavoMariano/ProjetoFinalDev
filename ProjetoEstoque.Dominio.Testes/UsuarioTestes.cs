// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
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
            _usuario.Senha = "abc123";
        }

        [Test]
        public void Nome_De_Usuario_Nao_Pode_Ser_Vazio()
        {
            _usuario.Nome = string.Empty;

        }
    }
}
