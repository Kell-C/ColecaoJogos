using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace $safeprojectname$
{
    class Conexao
    {
        public String StringConexao { get; set; }
        public SqlConnection ServidorTreino { get; set; }


        public Conexao()
        {
            this.StringConexao = "User ID=treinamento; Password=senha;Initial Catalog=colecaodejogos;Server=srvtrn01";
        }

        public void Conectar()
        {
            try
            {
                this.ServidorTreino = new SqlConnection(this.StringConexao);

                ServidorTreino.Open();
                Console.WriteLine("Conexao Bem Sucedida!");
                ServidorTreino.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Servidor não acessível. Erro: " + ex.Message);
            }
        }
        public void Desconectar()
        {
            try
            {
                if (ServidorTreino != null)
                    ServidorTreino.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao fechar a conexao com o banco de dados: " + ex.Message);
            }
            ServidorTreino.Close();
        }

        public void QueryComando(String sql)
        {

            try
            {
                SqlCommand mensagem = new SqlCommand(sql, this.ServidorTreino);
                if (this.ServidorTreino.State == System.Data.ConnectionState.Open)
                {
                    mensagem.ExecuteNonQuery();
                }
                Console.WriteLine("Mesagem enviada ao servidor...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar a query: " + sql);
                Console.WriteLine("Mesagem de erro:" + ex.Message);
            }
        }
        public SqlDataReader QueryConsulta(String sql)
        {
            try
            {
                if (this.ServidorTreino.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand mensagem = new SqlCommand(sql, this.ServidorTreino);
                    SqlDataReader dados = mensagem.ExecuteReader();
                    return dados;
                }
                Console.WriteLine("Consulta bem sucedida...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
                
            }
            return null;

        }
    }
}