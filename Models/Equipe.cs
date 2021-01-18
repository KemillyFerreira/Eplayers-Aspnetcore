using System.Collections.Generic;
using System.IO;
using EPlayers_AspnetCore.Interfaces;

namespace EPlayers_AspnetCore.Models
{
    //da pra herdar de duas classes colocando vírgula
    //primeiro herda a superclasse e a interface por ultimo

    public class Equipe : EplayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        
        public string Nome { get; set; }
        
        //é string porque vai salvar o caminho da imagem
        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";

        public Equipe(){

            CreateFolderAndFile(PATH);
        }

        //criamos o método para preparar a linha do CSV
        public string Prepare(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }
        public void Create(Equipe e)
        {
                //preparamos u array de string para o método AppendAllLines
            string [] linhas = {Prepare(e) };
                //acrescentamos a nova linha
            File.AppendAllLines(PATH, linhas);
        }   

        public void Delete(int id)
        {
          List<string> linhas = ReadAllLinesCSV(PATH);
            
            //2;SNK; snk.jpg
            //removemos as linhas com o código comparado
            //toString converte para texo (string)
            linhas.RemoveAll(x => x.Split (";")[0] == id.ToString());
           
            //reescreve o csv com a lista alterada
            RewriteCSV(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();

            //lemos todas as linhas do CSV
            string[] linhas = File.ReadAllLines(PATH);

            foreach(string item in linhas)
            {
                //1;VivoKeyd; vivo.jpg
                //[1] = 1
                //[2] = VivoKeyd
                //[3] = vivo.jpg

                string[] linha = item.Split(";");

                Equipe novaEquipe = new Equipe();
                novaEquipe.IdEquipe = int.Parse( linha [0] );
                novaEquipe.Nome = linha[1];
                novaEquipe.Imagem = linha[2];
                
                equipes.Add(novaEquipe);
            }

            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            
            //2;SNK; snk.jpg
            //removemos as linhas com o código comparado
            linhas.RemoveAll(x => x.Split (";")[0] == e.IdEquipe.ToString);
           
            //adicionamos na lista a equipe alterada
            linhas.Add( Prepare (e) );

            //reescreve o csv com a lista alterada
            RewriteCSV(PATH, linhas);
        }
    }
}