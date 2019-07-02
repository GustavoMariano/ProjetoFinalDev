﻿// NUnit 3 tests
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
            Db.Update("DBCC CHECKIDENT('[tb_solicitacao]', RESEED, 0)");

            //Criando solicitacao inicial
            Solicitacao novaSolicitacao = new Solicitacao();
            //novaSolicitacao = new Solicitacao();
            novaSolicitacao.DataCriacao = System.DateTime.Today;
            novaSolicitacao.Status = "Pendente";
            novaSolicitacao.DataFinalizacao = System.DateTime.Today;
            novaSolicitacao.Usuario = "USER";
            novaSolicitacao.Prioridade = "1";
            novaSolicitacao.Item1 = "aa";
            novaSolicitacao.Item2 = "aa";
            novaSolicitacao.Item3 = "aa";
            novaSolicitacao.Qtd1 = 3;
            novaSolicitacao.Qtd2 = 1;
            novaSolicitacao.Qtd3 = 6;

            //Adicionando a solicitacao no banco
            _solicitacaoDao.Solicitar(novaSolicitacao);
        }

        [Test]

        public void Teste_Deve_Adicionar_Solicitacao()
        {
            Db.Update("DELETE FROM tb_solicitacao");
            Db.Update("DBCC CHECKIDENT('[tb_solicitacao]', RESEED, 0)");

            //ARRANGE
            int idSolicitacaoAdicionado = 2;
            int idEsperado = 2;

            //Criando solicitacao inicial
            Solicitacao novaSolicitacao = new Solicitacao();
            novaSolicitacao.DataCriacao = System.DateTime.Today;
            novaSolicitacao.Status = "Pendente";
            novaSolicitacao.DataFinalizacao = System.DateTime.Today;
            novaSolicitacao.Usuario = null;
            novaSolicitacao.Prioridade = "1";
            novaSolicitacao.Item1 = "aa";
            novaSolicitacao.Item2 = "aa";
            novaSolicitacao.Item3 = "aa";
            novaSolicitacao.Qtd1 = 3;
            novaSolicitacao.Qtd2 = 1;
            novaSolicitacao.Qtd3 = 6;

            //Adicionando a solicitacao no banco
            _solicitacaoDao.Solicitar(novaSolicitacao);


            //ACTION
            var resultado = _solicitacaoDao.Solicitar(novaSolicitacao);

            //ASSERT
            Assert.True(resultado == idEsperado);
            Assert.AreEqual(idSolicitacaoAdicionado, resultado);
        }


        [Test]
        public void Teste_Deve_Alterar_Status_Da_Solicitacao()
        {

            Db.Update("DELETE FROM tb_solicitacao");
            Db.Update("DBCC CHECKIDENT('[tb_solicitacao]', RESEED, 0)");

            //CENÁRIO
            Solicitacao novaSolicitacao = new Solicitacao();
            novaSolicitacao.DataCriacao = System.DateTime.Today;
            novaSolicitacao.Status = "Pendente";
            novaSolicitacao.DataFinalizacao = System.DateTime.Today;
            novaSolicitacao.Usuario = null;
            novaSolicitacao.Prioridade = "1";
            novaSolicitacao.Item1 = "aa";
            novaSolicitacao.Item2 = "aa";
            novaSolicitacao.Item3 = "aa";
            novaSolicitacao.Qtd1 = 3;
            novaSolicitacao.Qtd2 = 1;
            novaSolicitacao.Qtd3 = 6;

            _solicitacaoDao.Solicitar(novaSolicitacao);


            int idSolicitacaoEditado = 1; //ID DA SOLICITACAO QUE ESTA SENDO ALTERADO
            string statusEditado = "REPROVADO"; //ALTERAÇÃO DO STATUS
            Solicitacao solicitacaoEditado = _solicitacaoDao.BuscarPorId(idSolicitacaoEditado); //BUSCA DA SOLICITACAO A SER ALTERADO

            //AÇÃO
            solicitacaoEditado.Status = statusEditado;
            _solicitacaoDao.AlterarStatus(solicitacaoEditado);

            Solicitacao solicitacaoBuscado = _solicitacaoDao.BuscarPorId(idSolicitacaoEditado);
            Assert.AreEqual(statusEditado, solicitacaoBuscado.Status);
        }

        [Test]
        public void Teste_Deve_Buscar_Todas_As_Solicitacoes()
        {

            Db.Update("DELETE FROM tb_solicitacao");
            Db.Update("DBCC CHECKIDENT('[tb_solicitacao]', RESEED, 0)");

            //CENÁRIO
            Solicitacao novaSolicitacao = new Solicitacao();
            novaSolicitacao.DataCriacao = System.DateTime.Today;
            novaSolicitacao.Status = "Pendente";
            novaSolicitacao.DataFinalizacao = System.DateTime.Today;
            novaSolicitacao.Usuario = "Testi";
            novaSolicitacao.Prioridade = "1";
            novaSolicitacao.Item1 = "aa";
            novaSolicitacao.Item2 = "aa";
            novaSolicitacao.Item3 = "aa";
            novaSolicitacao.Qtd1 = 3;
            novaSolicitacao.Qtd2 = 1;
            novaSolicitacao.Qtd3 = 6;

            _solicitacaoDao.Solicitar(novaSolicitacao);
            _solicitacaoDao.Solicitar(novaSolicitacao);


            int quantidadeSolicitacoes = 2;

            var resultado = _solicitacaoDao.BuscarTodos();

            Assert.AreEqual(quantidadeSolicitacoes, resultado.Count);


        }
    }
}
