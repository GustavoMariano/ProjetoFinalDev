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
            _solicitacao.DataCriacao = DateTime.Now;
            _solicitacao.Status = 0;
            _solicitacao.DataFinalizacao = DateTime.Now;
            //_solicitacao.Usuario = "";
            //_solicitacao.Items = "";
        }

        [Test]
        public void Data_De_Criacao_Da_Solicitacao_Nao_Deve_Ser_Amanha()
        {
            //ARRANGE
            _solicitacao.DataCriacao = DateTime.Now.AddDays(1);

            //ACTION
            Action resultado = () => _solicitacao.ValidaSolicitacao();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("A data de criação não deve ser diferente de agora!");
        }

        [Test]
        public void Status_Da_Solicitacao_Nao_Deve_Ser_Um_Dos_Predefinidos()
        {
            //ARRANGE
            //_solicitacao.Status = 1;

            //ACTION
            Action resultado = () => _solicitacao.ValidaSolicitacao();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("O status da solicitação deve ser um dos valores predefinidos!");
        }

        [Test]
        public void Data_De_Finalizacao_Da_Solicitacao_Nao_Deve_Ser_Ontem()
        {
            //ARRANGE
            _solicitacao.DataFinalizacao = DateTime.Now.AddDays(-1);

            //ACTION
            Action resultado = () => _solicitacao.ValidaSolicitacao();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("A data de finalização da solicitação não deve ser antes de agora!");
        }
    }
}
