using System.IO;
using System.Collections.Generic;

namespace EPlayers_AspnetCore.Models
{
    public class EplayersBase
    {
        public void CreateFolderAndFile (string _path)
        {
            // Database/Equipe.csv
            string folder = _path.Split ("/")[0];
            string file   = _path.Split("/")[1];
            
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }
        public List<string> ReadAllLinesCSV (string PATH)
        {
            List<string> linhas = new List<string>();

            //Using responsável por abrir e fechar o arquivo automaticamente
            //streamreader > ler os dados de um arquivo

            using (StreamReader file = new StreamReader(PATH))
            {
                string linha;

                //percorrer as linhas com um laço while
                while( (linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }

        public void RewriteCSV(string PATH, List<string> linhas)
        {
            //streamWriter > escreve dados em um arquivo
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + '\n');
                }
            }
        }

    }
}
