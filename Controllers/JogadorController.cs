using System;
using EPlayers_AspnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eplayers_Aspnetcore.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();
        
        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return View();
        }
        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador     = new Jogador();
            novoJogador.IdJogador   = Int32.Parse(form["IdJogador"]);
            novoJogador.IdEquipe    = Int32.Parse(form["IdEquipe"]);
            novoJogador.Nome        = form["Nome"];
            novoJogador.Email       = form["Email"];
            novoJogador.Senha       = form["Senha"];

            jogadorModel.Create(novoJogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();

            return LocalRedirect("~/Jogador");
        }
    }
}