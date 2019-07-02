﻿using ProjetoEstoque.Dominio;
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
                ,{0}status
                ,{0}dataFim
                ,{0}usuario
                ,{0}prioridade
                ,{0}itens)";

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


        public void AlterarStatus(Solicitacao solicitacao)
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
                {"itens",solicitacao.Itens},
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
