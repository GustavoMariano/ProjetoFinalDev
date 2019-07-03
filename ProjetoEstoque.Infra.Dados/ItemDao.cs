using ProjetoEstoque.Dominio;
using ProjetoEstoque.Infra.Dados.Comum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Infra.Dados
{
    public class ItemDao
    {
        #region Scripts
        public const string _sqlAdicionarItem =
            @"INSERT INTO [dbo].[tb_item]
                ([nome]
                ,[descricao])
            VALUES
                ({0}Nome
                ,{0}Descricao)";

        private const string _sqlBuscaTodosItem =
            @"SELECT [id]
                ,[Nome]
                ,[Descricao]
                FROM [dbo].[tb_item]";

        private const string _sqlEditarItem =
            @"UPDATE [dbo].[tb_item]
             SET [nome] = {0}Nome
                ,[descricao] = {0}Descricao
             WHERE [id] = {0}id";

        private const string _sqlDeletar =
            @"DELETE FROM [dbo].[tb_item] WHERE [id] = {0}Id";

        private const string _sqlBuscaPorId =
            @"SELECT [Id]
                  ,[Nome]
                  ,[Descricao]
              FROM [dbo].[tb_item]
              WHERE [Id] = {0}Id";

        #endregion

        public Item BuscarPorId(int id)
        {
            var parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get(_sqlBuscaPorId, ConverterItem, parms);
        }

        public int Adicionar(Item novoItem)
        {
            return Db.Insert(_sqlAdicionarItem, BuscarParametrosItem(novoItem));
        }

        public IList<Item> BuscarTodos()
        {
            return Db.GetAll(_sqlBuscaTodosItem, ConverterItem);
        }

        public void Editar(Item item)
        {
            Db.Update(_sqlEditarItem, BuscarParametrosItem(item));
        }

        public void Deletar(int id)
        {
            var parms = new Dictionary<string, object> { { "Id", id } };

            Db.Delete(_sqlDeletar, parms);
        }


        #region Metodos privados
        private Dictionary<string, object> BuscarParametrosItem(Item item)
        {
            return new Dictionary<string, object>
            {
                {"id",item.Id},
                {"nome",item.Nome},
                {"descricao",item.Descricao},
            };
        }

        private Item ConverterItem(IDataReader reader)
        {
            Item item = new Item();
            item.Id = Convert.ToInt32(reader["Id"]);
            item.Nome = Convert.ToString(reader["Nome"]);
            item.Descricao = Convert.ToString(reader["Descricao"]);

            return item;
        }
        #endregion
    }
}
