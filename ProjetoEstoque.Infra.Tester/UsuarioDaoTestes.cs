// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ProjetoEstoque.Dominio;
using ProjetoEstoque.Infra.Dados;
using ProjetoEstoque.Infra.Dados.Comum;

namespace ProjetoEstoque.Infra.Testes
{
    [TestFixture]
    public class UsuarioDaoTestes
    {
        private UsuarioDao _usuarioDao;

        [SetUp]
        public void Inicializar()
        {
            _usuarioDao = new UsuarioDao();

            //Limpando do a tabela usuario
            Db.Update("DELETE FROM tb_usuario");
            //Zerando o Id
            Db.Update("DBCC CHECKIDENT('[tb_usuario]', RESEED, 0)");

            //Criando cliente inicial
            Usuario novoUsuario = new Usuario();
            novoUsuario = new Usuario();
            novoUsuario.Nome = "Gustavo";
            novoUsuario.Login = "gustavo";
            novoUsuario.Setor = "Infra";
            novoUsuario.Senha = "abc123";
            novoUsuario.Nivel = "Admin";

            //Adicionando o cliente no banco
            _usuarioDao.Adicionar(novoUsuario);
        }

        [Test]
        public void Teste_Deve_Adicionar_Um_Usuario_Que_Retorne_Um_Id_Valido()
        {
            //CENÁRIO

            Usuario novoUsuario = new Usuario();
            novoUsuario.Nome = "Gustavo";
            novoUsuario.Login = "gustavo";
            novoUsuario.Setor = "Infra";
            novoUsuario.Senha = "abc123";
            novoUsuario.Nivel = "Admin";

            int idUsuarioAdicionado = 2;
            int quantidadeValida = 0;

            //AÇÃO

            var resultado = _usuarioDao.Adicionar(novoUsuario);

            //VERIFICAÇÃO        
            Assert.True(resultado > quantidadeValida);
            Assert.AreEqual(idUsuarioAdicionado, resultado);
        }
    }
}
