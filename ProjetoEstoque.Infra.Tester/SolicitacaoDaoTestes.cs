// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
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

            //Criando solicitacao inicial
            Solicitacao novaSolicitacao = new Solicitacao();
            novaSolicitacao = new Solicitacao();
            novaSolicitacao.DataCriacao = System.DateTime.Now;
            novaSolicitacao.Status = "Pendente";
            novaSolicitacao.DataFinalizacao = System.DateTime.Now;
            novaSolicitacao.Usuario = null;
            novaSolicitacao.Prioridade = "1";
            novaSolicitacao.Items = new Items
            {
                nome = "dasd",
                descricao = "alalala",
                quantidade = 2,
            };
            

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
            novaSolicitacao.Status = "Aprovado";
            novaSolicitacao.DataFinalizacao = System.DateTime.Now;
            novaSolicitacao.Usuario = "comum";
            novaSolicitacao.Prioridade = "Baixa";

            var Itens = new List<Item>();

            

            novaSolicitacao.Items = Itens;

            //ACTION
            var resultado = _solicitacaoDao.Solicitar(novaSolicitacao);

            //ASSERT
            Assert.True(resultado > idEsperado);
            Assert.AreEqual(idSolicitacaoAdicionado, resultado);
        }


        [Test]
        public void Teste_Deve_Alterar_Status_Da_Solicitacao()
        {
            //CENÁRIO
            int idSolicitacaoEditado = 1; //ID DA SOLICITACAO QUE ESTA SENDO ALTERADO
            string statusEditado = "REPROVADO"; //ALTERAÇÃO DO STATUS
            Solicitacao solicitacaoEditado = _solicitacaoDao.BuscarPorId(idSolicitacaoEditado); //BUSCA DA SOLICITACAO A SER ALTERADO

            //AÇÃO
            solicitacaoEditado.Status = statusEditado;
            _solicitacaoDao.AlterarStatus(solicitacaoEditado);

            Solicitacao solicitacaoBuscado = _solicitacaoDao.BuscarPorId(idSolicitacaoEditado);
            Assert.AreEqual(statusEditado, solicitacaoBuscado.Status);
        }

        private class Items : List<Item>
        {
            public string nome { get; set; }
            public string descricao { get; set; }
            public int quantidade { get; set; }
        }
    }
}
