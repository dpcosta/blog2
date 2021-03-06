﻿using System.Configuration;
using System.Data.SqlClient;

namespace BlogTeste2.Infra
{
    public class ConnectionFactory
    {

        public static SqlConnection CriaConexaoAberta()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["blog"].ConnectionString;
            SqlConnection conexao = new SqlConnection(stringConexao);
            conexao.Open();
            return conexao;
        }
    }
}