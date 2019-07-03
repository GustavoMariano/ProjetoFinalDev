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
            novoItem.Nome = "Item SetUp";
            novoItem.Descricao = "Desc SetUp";

            _itemDao.Adicionar(novoItem);
        }

        [Test]
        public void Teste_Deve_Adicionar_Um_Item()
        {
            Item novoItem = new Item();
            novoItem.Nome = "Item Teste";
            novoItem.Descricao = "Desc Teste";

            int QuantidadeItemAdicionado = 2;
            int quantidadeValida = 0;

            var resultado = _itemDao.Adicionar(novoItem);

            Assert.True(resultado > quantidadeValida);
            Assert.AreEqual(QuantidadeItemAdicionado, resultado);
        }

        [Test]
        public void Teste_Deve_Buscar_Todos_Os_Itens()
        {
            int quantidadeItens = 1;

            var resultado = _itemDao.BuscarTodos();

            Assert.AreEqual(quantidadeItens, resultado.Count);
        }

        [Test]
        public void Teste_Deve_Deletar_Um_Item_Por_Id()
        {
            int idItemDeletado = 1;
            int quantidadeItens = 0;

            _itemDao.Deletar(idItemDeletado);

            var resultado = _itemDao.BuscarTodos();
            Assert.AreEqual(quantidadeItens, resultado.Count);
        }

        [Test]
        public void Teste_Deve_Editar_Um_Item_Por_Id()
        {
            int idClienteEditado = 1; 
            string nomeEditado = "TESTE UPDATE";
            Item itemEditado = _itemDao.BuscarPorId(idClienteEditado);

            //AÇÃO
            itemEditado.Nome = nomeEditado;
            _itemDao.Editar(itemEditado);

            Item itemBuscado = _itemDao.BuscarPorId(idClienteEditado);
            Assert.AreEqual(nomeEditado, itemBuscado.Nome);
        }
    }
}

