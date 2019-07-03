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
    public class SolicitacaoDao
    {
        #region Scripts
        public const string _sqlAdicionarSolicitacao =
            @"INSERT INTO tb_solicitacao
                ([data_criacao]
                ,[status]
                ,[data_finalizacao]
                ,[usuario]
                ,[prioridade]
                ,[item1]
                ,[item2]
                ,[item3]
                ,[qtd1]
                ,[qtd2]
                ,[qtd3])
            VALUES
                ({0}datacriacao
                ,{0}status
                ,{0}dataFim
                ,{0}usuario
                ,{0}prioridade
                ,{0}item1
                ,{0}item2
                ,{0}item3
                ,{0}qtd1
                ,{0}qtd2
                ,{0}qtd3)";

        private const string _sqlBuscaTodos =
            @"SELECT *
              FROM [dbo].[tb_solicitacao]";

        private const string _sqlEditar =
            @"UPDATE [dbo].[tb_solicitacao]
               SET [status] = {0}status
             WHERE [Id] = {0}Id";

        private const string _sqlBuscaPorId =
            @"SELECT * FROM [dbo].[tb_solicitacao]
              WHERE [Id] = {0}Id";
        #endregion

        public int Solicitar(Solicitacao novaSolicitacao)
        {
            return Db.Insert(_sqlAdicionarSolicitacao, BuscarParametros(novaSolicitacao));
        }

        public Solicitacao BuscarPorId(int id)
        {
            var parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get(_sqlBuscaPorId, ConverterSolicitacao, parms);
        }

        public IList<Solicitacao> BuscarTodos()
        {
            return Db.GetAll(_sqlBuscaTodos, ConverterSolicitacao);
        }


        public void Editar(Solicitacao solicitacao)
        {
            Db.Update(_sqlEditar, BuscarParametros(solicitacao));
        }

        private Dictionary<string, object> BuscarParametros(Solicitacao solicitacao)
        {
            return new Dictionary<string, object>
            {
                {"id",solicitacao.Id},
                {"dataCriacao",solicitacao.DataCriacao},
                {"status",solicitacao.Status},
                {"dataFim",solicitacao.DataFinalizacao},
                {"usuario",solicitacao.Usuario},
                {"prioridade",solicitacao.Prioridade},
                {"item1",solicitacao.Item1},
                {"item2",solicitacao.Item2},
                {"item3",solicitacao.Item3},
                {"qtd1",solicitacao.Qtd1},
                {"qtd2",solicitacao.Qtd2},
                {"qtd3",solicitacao.Qtd3},
            };
        }

        #region métodos privados
        private Solicitacao ConverterSolicitacao(IDataReader reader)
        {
            Solicitacao solicitacao = new Solicitacao();
            solicitacao.Id = Convert.ToInt32(reader["Id"]);
            solicitacao.Status = Convert.ToString(reader["Status"]);


            return solicitacao;
        }

        #endregion
    }

}
