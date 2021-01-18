using System;
using EPlayers_AspnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_AspnetCore.Controllers
{
    [Route("Equipe")]
    //http://localhost:5000/Equipe


    public class EquipeController : Controller
    {
        //criamos uma instância de equipeModel
        Equipe equipeModel = new Equipe();
        
        public IActionResult Index()
        {
            //pega as informações, compacta e envia para a view
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }
        
        [Route("Cadsatrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome     = form["Nome"];
            novaEquipe.Imagem   = form["Imagem"];

            //chamamos o método create para salvar a novaEquipe no csv
            equipeModel.Create(novaEquipe);
            //atualiza a lista de equipes na view
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe");

        }
    }
}