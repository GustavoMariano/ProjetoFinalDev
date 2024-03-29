﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Dominio.Testes
{
    [TestFixture]
    public class ItemTestes
    {
        private Item _item;

        [SetUp]
        public void Inicializador()
        {
            _item = new Item();
            _item.Nome = "Item";
            _item.Descricao = "Desc";
        }

        [Test]
        public void Nome_Do_Item_Nao_Pode_Ser_Vazio()
        {
            //ARRANGE
            _item.Nome = string.Empty;

            //ACTION
            Action resultado = () => _item.ValidaItem();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("O nome não deve ser vazio!");
        }

        [Test]
        public void Nome_Do_Item_Nao_Ter_Menos_Que_3_Caracteres()
        {
            //ARRANGE
            _item.Nome = "ab";

            //ACTION
            Action resultado = () => _item.ValidaItem();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("O nome do item não pode ter menos de 3 caracteres!");
        }

        [Test]
        public void Descricao_Do_Item_Deve_Ter_Mais_De_Cinco_Caracteres()
        {
            //ARRANGE
            _item.Descricao = "ABCDE";

            //ACTION
            Action resultado = () => _item.ValidaItem();

            //ASSERT
            resultado.Should()
                .Throw<Exception>()
                .WithMessage("A descrição deve ter mais de cinco caracteres!");
        }
    }
}
