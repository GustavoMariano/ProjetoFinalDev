using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Sartor.Pizzaria.Infra.Dados.Comum
{
    public static class Db
    {
        #region Attributes

        private static readonly string connectionStringName = System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionStringName");

        private static readonly string providerName = ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName;

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

        #endregion Attributes

        #region Properties

        public static string PrefixoParametro
        {
            get
            {
                switch (providerName)
                {
                    // Microsoft Access não tem suporte a esse tipo de comando
                    case "System.Data.OleDb": return "@";
                    case "System.Data.SqlClient": return "@";
                    case "System.Data.OracleClient": return ":";
                    case "MySql.Data.MySqlClient": return "?";

                    default:
                        return "@";
                }
            }
        }

        #endregion Properties
        
        public static int Insert(string sql, Dictionary<string, object> parms = null, bool identitySelect = true)
        {
            sql = string.Format(sql, PrefixoParametro);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.SetParameters(parms);                     // Extension method
                    command.CommandText = identitySelect ? sql.AppendIdentitySelect() : sql; // Extension method

                    connection.Open();

                    int id = 0;

                    if (identitySelect)
                        id = Convert.ToInt32(command.ExecuteScalar());
                    else
                        command.ExecuteNonQuery();

                    return id;
                }
            }
        }

        public static void Update(string sql, Dictionary<string, object> parms = null)
        {
            sql = string.Format(sql, PrefixoParametro);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(string sql, Dictionary<string, object> parms = null)
        {
            Update(sql, parms);
        }

        public static List<T> GetAll<T>(string sql, Func<IDataReader, T> make, Dictionary<string, object> parms = null)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);

                    connection.Open();

                    var list = new List<T>();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var obj = make(reader);
                        list.Add(obj);
                    }

                    return list;
                }
            }
        }

        public static T Get<T>(string sql, Func<IDataReader, T> make, Dictionary<string, object> parms = null)
        {
            sql = string.Format(sql, PrefixoParametro);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);  // Extension method

                    connection.Open();

                    T t = default(T);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                        t = make(reader);

                    return t;
                }
            }
        }

        #region Private methods

        private static void SetParameters(this DbCommand command, Dictionary<string, object> parms)
        {
            if (parms != null)
            {
                foreach (var item in parms)
                {
                    object value = item.Value ?? DBNull.Value;
                    string name = PrefixoParametro + item.Key;

                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = name;
                    dbParameter.Value = value;

                    command.Parameters.Add(dbParameter);
                }
            }
        }


        private static string AppendIdentitySelect(this string sql)
        {
            switch (providerName)
            {
                // Microsoft Access não tem suporte a esse tipo de comando
                case "System.Data.OleDb": return sql;
                case "System.Data.SqlClient": return sql + ";SELECT SCOPE_IDENTITY()";
                case "System.Data.OracleClient": return sql + ";SELECT MySequence.NEXTVAL FROM DUAL";
                case "Firebird.Data.FbClient": return sql + ";GENERATOR(SEILAÁ)";
                default: return sql + ";SELECT @@IDENTITY";
            }
        }

        #endregion Private methods
    }
}
