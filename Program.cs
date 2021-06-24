using ConsoleAula2.Model;
using System;

namespace ColecaoJogos
{
    class Program
    {
        static void Main(string[] args)
        {
            Jogo novo = new Jogo();
            novo.Nome = "Jogo6";
            novo.CodigoJogo = 0;
            novo.Tipo = "RPG";
            novo.DataLancamento = "2021/06/24";
            novo.Preco = 0;

            JogoDAO dao = new JogoDAO();
            dao.Incluir(novo);

        }


    }

    
}
