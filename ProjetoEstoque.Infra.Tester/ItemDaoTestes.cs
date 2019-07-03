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
    public class ItemDaoTestes
    {
        private ItemDao _itemDao;

        [SetUp]
        public void Inicializar()
        {
            _itemDao = new ItemDao();

            Db.Update("DELETE FROM tb_item");
            Db.Update("DBCC CHECKIDENT('[tb_item]', RESEED, 0)");

            Item novoItem = new Item();
            novoItem = new Item();
            novoItem.Nome = "Item 1";
            novoItem.Descricao = "Desc 1";

            _itemDao.Adicionar(novoItem);
        }

        [Test]
        public void Teste_Deve_Adicionar_Um_Item()
        {
            Item novoItem = new Item();
            novoItem.Nome = "Item2";
            novoItem.Descricao = "Desc2";

            int QuantidadeItemAdicionado = 2;
            int quantidadeValida = 0;

            var resultado = _itemDao.Adicionar(novoItem);

            Assert.True(resultado > quantidadeValida);
            Assert.AreEqual(QuantidadeItemAdicionado, resultado);
        }

        //[Test]
        //public void Teste_Deve_Deletar_Um_Item()
        //{
        //    Item novoItem = new Item();
        //    novoItem.Nome = "Item2";
        //    novoItem.Descricao = "Desc2";

        //    int QuantidadeItemAMostrar = 1;
        //    int quantidadeValida = 0;

        //    var resultado = _itemDao.Deletar(novoItem);

        //    Assert.True(resultado > quantidadeValida);
        //    Assert.AreEqual(QuantidadeItemAMostrar, resultado);
        //}
    }
}

