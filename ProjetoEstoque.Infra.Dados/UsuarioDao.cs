using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Infra.Dados
{
    public class UsuarioDao
    {
        #region Scripts
        public const string _sqlAdicionar =
            @"INSERT INTO tb_usuario
                ([nome]
                ,[login]
                ,[senha]
                ,[nivel])
            VALUES
                ({0}nome
                ,{0}login
                ,{0}senha
                ,{0}nivel)";

        private const string _sqlBuscaTodos =
            @"SELECT [id]
                ,[nome]
                ,[login]
                ,[senha]
                ,[nivel]
                FROM [dbo].[tb_usuario]";

        private const string _sqlEditar =
            @"UPDATE [dbo].[tb_usuario]
             SET [nome] = {0}nome
                ,[login] = {0}login
                ,[senha] ={0}senha
                ,[nivel] ={0}nivel
             WHERE [id] = {0}id";

        private const string _sqlDeletar =
            @"DELETE FROM [dbo].[tb_usuario] WHERE [id] = {0}id";

        #endregion


    }


    public void Deletar(int id)
    {
        var parms = new Dictionary<string, object> { { "id", id } };

        Db.Delete(_sqlDeletar, parms);
    }
}
