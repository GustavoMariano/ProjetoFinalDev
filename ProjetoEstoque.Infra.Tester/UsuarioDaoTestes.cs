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

            Db.Update("DELETE FROM tb_usuario");
            Db.Update("DBCC CHECKIDENT('[tb_usuario]', RESEED, 0)");

            Usuario novoUsuario = new Usuario();
            novoUsuario = new Usuario();
            novoUsuario.Nome = "Gustavo";
            novoUsuario.Login = "gustavo";
            novoUsuario.Setor = "Infra";
            novoUsuario.Senha = "abc123";
            novoUsuario.Nivel = 1;

            _usuarioDao.Adicionar(novoUsuario);
        }

        [Test]
        public void Teste_Deve_Adicionar_Um_Usuario_Que_Retorne_Um_Id_Valido()
        {
            Usuario novoUsuario = new Usuario();
            novoUsuario.Nome = "Gustavo";
            novoUsuario.Login = "gustavo";
            novoUsuario.Setor = "Infra";
            novoUsuario.Senha = "abc123";
            novoUsuario.Nivel = 1 ;

            int idUsuarioAdicionado = 2;
            int quantidadeValida = 0;

            var resultado = _usuarioDao.Adicionar(novoUsuario);

            Assert.True(resultado > quantidadeValida);
            Assert.AreEqual(idUsuarioAdicionado, resultado);
        }

        [Test]
        public void Teste_Deve_Buscar_O_Nivel_Pelo_Login_E_Senha()
        {
            //CENÁRIO

            Usuario novoUsuario = new Usuario();
            novoUsuario.Nome = "Gustavo";
            novoUsuario.Login = "gustavo";
            novoUsuario.Setor = "Infraaa";
            novoUsuario.Senha = "abc123";
            novoUsuario.Nivel = 0;

            int niveDoUsuarioAdicionado = 0;
            int nivelValida = 0;

            //Limpando do a tabela usuario
            Db.Update("DELETE FROM tb_usuario");

            

            //AÇÃO
            _usuarioDao.Adicionar(novoUsuario);
            var resultado = _usuarioDao.BuscarNivel(novoUsuario);

            //VERIFICAÇÃO        
            Assert.True(resultado == nivelValida);
            Assert.AreEqual(niveDoUsuarioAdicionado, resultado);
        }
    }
}
