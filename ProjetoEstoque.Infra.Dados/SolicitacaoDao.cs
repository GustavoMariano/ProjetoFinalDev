using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Infra.Dados
{
    public class SolicitacaoDao
    {
        #region Scripts
        public const string _sqlAdicionar =
            @"INSERT INTO tb_usuario
                ([data_cricacao]
                ,[status]
                ,[data_finalizacao]
                ,[usuario]
                ,[itens])
            VALUES
                (DATETIME.NOW
                ,{0}enum
                ,{0}DATETIME.NOW...
                ,{0}usuario
                ,{0}itens)";

        private const string _sqlBuscaTodos =
            @"SELECT [id]
                ,[nome]
                ,[login]
                ,[senha]
                ,[nivel]
                FROM [dbo].[tb_usuario]";
        #endregion
    }
}
