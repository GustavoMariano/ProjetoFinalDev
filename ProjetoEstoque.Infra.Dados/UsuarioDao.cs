using ProjetoEstoque.Dominio;
using ProjetoEstoque.Infra.Dados.Comum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
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
                ,[setor]
                ,[login]
                ,[senha]
                ,[nivel])
            VALUES
                ({0}nome
                ,{0}setor
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

        public int Adicionar(Usuario novoUsuario)
        {
            return Db.Insert(_sqlAdicionar, BuscarParametros(novoUsuario));
        }

        public IList<Usuario> BuscarTodos()
        {
            return Db.GetAll(_sqlBuscaTodos, ConverterUsuario);
        }

        public void Editar(Usuario usuario)
        {
            Db.Update(_sqlEditar, BuscarParametros(usuario));
        }

        public void Deletar(int id)
        {
            var parms = new Dictionary<string, object> { { "id", id } };

            Db.Delete(_sqlDeletar, parms);
        }

        #region Métodos Privados

        private Usuario ConverterUsuario(IDataReader reader)
        {
            Usuario usuario = new Usuario();
            usuario.Id = Convert.ToInt32(reader["Id"]);
            usuario.Nome = Convert.ToString(reader["Nome"]);
            usuario.Setor = Convert.ToString(reader["Setor"]);
            usuario.Login = Convert.ToString(reader["Login"]);
            usuario.Senha = Convert.ToString(reader["Senha"]);
            usuario.Nivel = Convert.ToInt32(reader["Nivel"]);

            return usuario;
        }

        private Dictionary<string, object> BuscarParametros(Usuario usuario)
        {
            return new Dictionary<string, object>
            {
                {"id",usuario.Id},
                {"nome",usuario.Nome},
                {"setor",usuario.Setor},
                {"login",usuario.Login},
                {"senha",usuario.Senha},
                {"nivel",usuario.Nivel},

            };
        }

        #endregion
    }
}
