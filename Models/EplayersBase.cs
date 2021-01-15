using System.IO;

namespace EPlayers_AspnetCore.Models
{
    public class EplayersBase
    {
        public void CreateFolderAndFile (string _path)
        {
            // Database/Equipe.csv
            string folder = _path.Split ("/") [0];
            
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(_path))
            {
                File.Create(_path);
            }

        }

    }
}