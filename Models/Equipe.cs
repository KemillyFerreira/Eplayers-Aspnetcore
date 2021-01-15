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
            throw new System.NotImplementedException();
        }

        public List<Equipe> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Equipe e)
        {
            throw new System.NotImplementedException();
        }
    }
}