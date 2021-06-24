using $safeprojectname$;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAula2.Model
{
    class JogosDAO
    {
        public List<Jogo> Jogos { set; get; }
        private Conexao Banco { set; get; }

        //contrutora para inicializar os atributos
        public JogosDAO()
        {
            Jogos = new List<Jogo>();
            Banco = new Conexao();
            Banco.Conectar();
        }
        public void Incluir(Jogo novoJogo)
        {
            try
            {
                String Sql = "insert into Jogo(nome, tipo, datalancamento, preco) values ('@nome', '@tipo', '@datalacamento', '@preco' )";
                Sql = Sql.Replace("@nome", novoJogo.Nome).Replace("@tipo", novoJogo.Tipo).Replace("@datalancamento", novoJogo.DataLancamento).Replace("@preco", novoJogo.Preco.ToString());
                Banco.QueryComando(Sql);
                Console.WriteLine("Jogo gravado com sucesso");
            }
            catch (Exception)
            {
                Console.WriteLine("Erro ao inserir Jogo");
            }
        }
        public void Alterar(Jogo jogo)
        {
            try
            {
                String Sql = "update jogo set nome = '@nome' where codigo = @codigo";
                Sql = Sql.Replace("@nome", jogo.Nome).Replace("@codigo", jogo.CodigoJogo.ToString());
                Banco.QueryComando(Sql);
                Console.WriteLine("Jogo alterado com sucesso");
            }
            catch (Exception)
            {
                Console.WriteLine("Erro ao alterar Jogo");
            }
        }
        public void Excluir(Int32 Codigo)
        {
            try
            {
                String Sql = "delete from jogo where codg = @codigo";
                Sql = Sql.Replace("@codigo", Codigo.ToString());
                Banco.QueryComando(Sql);
                Console.WriteLine("Jogo excluido com sucesso");
            }
            catch (Exception)
            {
                Console.WriteLine("Erro ao excluir Jogo");
            }
        }
        public List<Jogo> Consultar()
        {
            try
            {
                List<Jogo> lista = new List<Jogo>();
                String Sql = "select top 10 * from proprietario order by nome";
                SqlDataReader dados = Banco.QueryConsulta(Sql);

                while (dados.Read())
                {
                    Jogo jogo = new Jogo();
                    jogo.CodigoJogo = (int)dados["codigo"];
                    jogo.Nome = dados["nome"].ToString();

                    lista.Add(jogo);
                }

                return lista;
            }

            catch (Exception)
            {
                Console.WriteLine("Erro ao consultar jogo");
                return null;
            }
        }
    }
}
