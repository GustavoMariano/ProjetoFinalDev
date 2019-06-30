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
    public class SolicitacaoDaoTestes
    {
        private SolicitacaoDao _solicitacaoDao;
        private UsuarioDao _usuarioDao;

        [SetUp]
        public void Inicializador()
        {
            _solicitacaoDao = new SolicitacaoDao();
            _usuarioDao = new UsuarioDao();

            //Limpando do a tabela solicitacao
            Db.Update("DELETE FROM tb_solicitacao");
            //Zerando o Id
            Db.Update("DBCC CHECKIDENT('[tb_solicitacao]', RESEED, 0)");

            //Criando solicitacao inicial
            Solicitacao novaSolicitacao = new Solicitacao();
            novaSolicitacao = new Solicitacao();
            novaSolicitacao.DataCriacao = System.DateTime.Now;
            novaSolicitacao.Status = StatusEnum.Pendente;
            novaSolicitacao.DataFinalizacao = System.DateTime.Now;
            novaSolicitacao.Usuario = null;
            novaSolicitacao.Prioridade = 1;
            novaSolicitacao.Item = "ITEM";

            //Adicionando a solicitacao no banco
            _solicitacaoDao.Solicitar(novaSolicitacao);
        }

        [Test]
        public void Teste_Deve_Adicionar_Solicitacao()
        {
            //ARRANGE
            int idSolicitacaoAdicionado = 2;
            int idEsperado = 1;

            Solicitacao novaSolicitacao = new Solicitacao();
            novaSolicitacao.DataCriacao = System.DateTime.Now;
            novaSolicitacao.Status = StatusEnum.Aprovado;
            novaSolicitacao.DataFinalizacao = System.DateTime.Now;
            novaSolicitacao.Usuario = "comum";
            novaSolicitacao.Prioridade = 1;
            novaSolicitacao.Item = "Item aleatorio";

            //ACTION
            var resultado = _solicitacaoDao.Solicitar(novaSolicitacao);

            //ASSERT
            Assert.True(resultado > idEsperado);
            Assert.AreEqual(idSolicitacaoAdicionado, resultado);
        }
    }
}
