using System.Collections.Generic;
using System.IO;

namespace EPlayers_AspnetCore.Models
{
    public class Jogador : EplayersBase , IJogador
    {
        public int IdJogador { get; set; }
        
        public string Nome { get; set; }
        
        public string Email { get; set; }

        public string Senha { get; set; }
        public int IdEquipe { get; set; }

        private const string PATH = "Database/Jogador.csv";

        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }

            /// <summary>
            /// Adiciona um Jogador ao CSV
            /// </summary>
            /// <param name="j">Jogador</param>

            public void Create(Jogador j)
            {
                string[] linha = {PrepararLinha(j) };
                File.AppendAllLines(PATH, linha);
            }

            /// <summary>
            /// Prepara a linha para a estrutura do objeto Jogador
            /// </summary>
            /// <param name="j">objeto "Jogador"</param>
            /// <returns> Retorna a linha em formato de .csv</returns>

            private string PrepararLinha(Jogador j)
            {
            return $"{j.IdJogador};{j.Nome};{j.Email};{j.Senha};{j.IdEquipe}";
            }

            ///<summary>
            /// Exclui um jogador
            ///</summary>
            ///<param name="idJogador"></param>

            public void Delete(int idJogador)
            {
                List<string> linhas = ReadAllLinesCSV(PATH);
                // 1;FLA;Fla.png
                linhas.RemoveAll(x => x.Split(";")[0] == idJogador.ToString());
                RewriteCSV(PATH, linhas);  
            }

            ///<summary>
            ///  Lê todas as linhas do csv
            ///</summary>
            ///<returns> Lista de Jogadores </returns>

            public List<Jogador> ReadAll()
            {
                List<Jogador> jogadores = new List<Jogador>();
                string[] linhas = File.ReadAllLines(PATH);

                foreach (var item in linhas)
                {
                    string[] linha = item.Split(";");
                    
                    Jogador jogador     = new Jogador();
                    jogador.IdJogador   = int.Parse(linha[0]);
                    jogador.Nome        = linha [1];
                    jogador.Email       = linha[2];
                    jogador.Senha       = linha[3];
                    jogador. IdEquipe   = int.Parse(linha[4]);

                    jogadores.Add(jogador);
                }
                return jogadores;
            }
            
            ///<summary>
            ///  Altera um jogador
            ///</summary>
            ///<param name="j">Jogador alterado</param>

            public void Update(Jogador j)
            {
                List<string> linhas = ReadAllLinesCSV(PATH);
                linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
                linhas.Add( PrepararLinha(j) );
                RewriteCSV(PATH, linhas);
            }
       
    }

    internal interface IJogador
    {
    }
}