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
            @"INSERT INTO tb_item
                ([nome]
                ,[descricao])
            VALUES
                ({0}nome
                ,{0}descricao";

        private const string _sqlBuscaTodos =
            @"SELECT [id]
                ,[nome]
                ,[descricao]
                FROM [dbo].[tb_item]";

        private const string _sqlEditar =
            @"UPDATE [dbo].[tb_item]
             SET [nome] = {0}nome
                ,[descricao] = {0}descricao
             WHERE [id] = {0}id";

        private const string _sqlDeletar =
            @"DELETE FROM [dbo].[tb_item] WHERE [id] = {0}id";

        #endregion

        public int Adicionar(Item novoItem)
        {
            return Db.Insert(_sqlAdicionarItem, BuscarParametros(novoItem));
        }

        public IList<Item> BuscarTodos()
        {
            return Db.GetAll(_sqlBuscaTodos, ConverterItem);
        }

        public void Editar(Item item)
        {
            Db.Update(_sqlEditar, BuscarParametros(item));
        }

        public void Deletar(int id)
        {
            var parms = new Dictionary<string, object> { { "id", id } };

            Db.Delete(_sqlDeletar, parms);
        }


        #region Metodos privados
        private Dictionary<string, object> BuscarParametros(Item item)
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
