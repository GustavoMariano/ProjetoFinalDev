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
            novoUsuario.Login = "gustavooo";
            novoUsuario.Setor = "Infraaa";
            novoUsuario.Senha = "gustavinhogameplays";
            novoUsuario.Nivel = 50;

            _usuarioDao.Adicionar(novoUsuario);

            int nivelValida = 50;
            int niveDoUsuarioAdicionado = novoUsuario.Nivel;

            var resultado = _usuarioDao.BuscarNivel(novoUsuario);

            //VERIFICAÇÃO        
            Assert.True(resultado == nivelValida);
            Assert.AreEqual(niveDoUsuarioAdicionado, resultado);
        }

        [Test]
        public void Teste_Deve_Buscar_Todos_Os_Usuarios()
        {
            int quantidadeUsuarios = 1;

            var resultado = _usuarioDao.BuscarTodos();

            Assert.AreEqual(quantidadeUsuarios, resultado.Count);
        }

        [Test]
        public void Teste_Deve_Editar_Um_Usuarios()
        {
            int idUsuarioEditado = 1; //ID DO CLIENTE QUE ESTA SENDO ALTERADO
            string nomeEditado = "Nome EDITADO"; //ALTERAÇÃO DO NOME
            Usuario usuarioEditado = _usuarioDao.BuscarPorId(idUsuarioEditado); //BUSCA DO CLIENTE A SER ALTERADO

            //AÇÃO
            usuarioEditado.Nome = nomeEditado;
            _usuarioDao.Editar(usuarioEditado);

            Usuario usuarioBuscado = _usuarioDao.BuscarPorId(idUsuarioEditado);
            Assert.AreEqual(nomeEditado, usuarioBuscado.Nome);
        }

        [Test]
        public void Teste_Deve_Deletar_Usuario_Por_Id()
        {
            int idUsuarioDeletado = 1;
            int quantidadeUsuarios = 0;

            _usuarioDao.Deletar(idUsuarioDeletado);

            var resultado = _usuarioDao.BuscarTodos();
            Assert.AreEqual(quantidadeUsuarios, resultado.Count);

        }
    }
}
