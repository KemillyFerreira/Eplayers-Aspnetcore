using System.Collections.Generic;
using EPlayers_AspnetCore.Models;

namespace EPlayers_AspnetCore.Interfaces
{
    public interface IEquipe
    {
        //métodos de CRUD - contrato
        void Create(Equipe e);

        List<Equipe> ReadAll();

        void Update(Equipe e);

        void Delete(int id);
    

    }
}