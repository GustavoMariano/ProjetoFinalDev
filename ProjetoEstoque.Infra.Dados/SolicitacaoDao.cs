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
                ,[itens])
            VALUES
                ({0}datacriacao
                ,{0}StatusEnum.Pendente
                ,{0}datafinalizacao
                ,{0}usuario
                ,{0}prioridade
                ,{0}item)";

        private const string _sqlBuscaTodosSolicitacao =
            @"SELECT 
            FROM [dbo].[tb_solicitacao]";
        #endregion

        public int Solicitar(Solicitacao novaSolicitacao)
        {
            return Db.Insert(_sqlAdicionarSolicitacao, BuscarParametros(novaSolicitacao));
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
                {"itens",solicitacao.Item},
            };
        }
    }
        
}
