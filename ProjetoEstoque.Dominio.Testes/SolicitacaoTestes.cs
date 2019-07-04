using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Dominio.Testes
{
    public class SolicitacaoTestes
    {
        private Solicitacao _solicitacao;

        [SetUp]
        public void Inicializador()
        {
            _solicitacao = new Solicitacao();
            _solicitacao.DataCriacao = DateTime.Today;
            _solicitacao.Status = "Pendente";
            _solicitacao.DataFinalizacao = DateTime.Today;
            _solicitacao.Item1 = "ITEM 1";
            _solicitacao.Item2 = "ITME 2";
            _solicitacao.Item3 = "Item 3";
            _solicitacao.Qtd1 = "1";
            _solicitacao.Qtd2 = "2";
            _solicitacao.Qtd3 = "3";
            _solicitacao.Usuario = "Gustavo";
        }

        [Test]
        public void Usuario_Nao_Deve_Ser_Vazio()
        {
            //ARRANGE
            _solicitacao.Usuario = "";

            //ACTION
            Action resultado = () => _solicitacao.ValidaSolicitacao();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("O usuario da solicitação não deve ser vazio!");
        }

        
        [Test]
        public void Status_Nao_Deve_Ser_Vazio()
        {
            //ARRANGE
            _solicitacao.Status = "";

            //ACTION
            Action resultado = () => _solicitacao.ValidaSolicitacao();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("O status da solicitação não deve estar vazia!");
        }

        [Test]
        public void Item1_Nao_Deve_Ser_Vazio()
        {
            //ARRANGE
            _solicitacao.Item1 = "";

            //ACTION
            Action resultado = () => _solicitacao.ValidaSolicitacao();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("O item 1 da solicitação não deve ser vazio!");
        }

        [Test]
        public void Data_De_Criacao_Da_Solicitacao_Nao_Deve_Ser_Amanha()
        {
            //ARRANGE
            _solicitacao.DataCriacao = DateTime.Today.AddDays(1);

            //ACTION
            Action resultado = () => _solicitacao.ValidaSolicitacao();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("A data de criação não deve ser diferente de agora!");
        }

        [Test]
        public void Data_De_Finalizacao_Não_Pode_Ser_Diferente_De_Hoje()
        {
            //ARRANGE
            _solicitacao.DataFinalizacao = DateTime.Today.AddDays(1);

            //ACTION
            Action resultado = () => _solicitacao.ValidaSolicitacao();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("A data de finalização da solicitação deve ser hoje!");
        }
    }
}
