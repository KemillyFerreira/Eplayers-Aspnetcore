using System;
using EPlayers_AspnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO; 

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

        //http://localhost:5000/Equipe/Cadastrar
        [Route("Cadsatrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome     = form["Nome"];

            //upload inicio
            //verificamos se o usuário selecionou um arquivo
                if (form.Files.Count > 0)
                {
                    //recebemos o arquivo que o usuário enviou e amarzenamos na variável file
                    var file    = form.Files[0];
                    var folder  = Path.Combine(Directory.GetCurrentDirectory(),"wwwwroote/imgEquipes" );

                    //verificamos se o diretório (pasta) já existe
                    //se não, a criamos
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                                            //localhost:5001                                   Equipes  imagem.jpg
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwwroot/img/", folder, file.FileName);
                    using(var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    novaEquipe.Imagem = file.FileName;
                }
                else
                {
                    novaEquipe.Imagem = "padrao.png";
                }


            //upload final

            //chamamos o método create para salvar a novaEquipe no csv
            equipeModel.Create(novaEquipe);
            //atualiza a lista de equipes na view
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe");
        }

        //http://localhost:5000/Equipe/Cadastrar
        [Route ("{id}")]
        public IActionResult Excluir(int id)
        {
            equipeModel.Delete(id);
            ViewBag.Equipes = equipeModel.ReadAll();
            
            return LocalRedirect("~/Equipe/Listar");
        }
    }
}