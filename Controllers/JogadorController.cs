using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Gamer_manha.Infra;
using Projeto_Gamer_manha.Models;

namespace Projeto_Gamer_manha.Controllers
{
    [Route("[controller]")]
    public class JogadorController : Controller
    {
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
        {
            _logger = logger;
        }

        Context c = new Context();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogador = c.Jogador.ToList();
            ViewBag.Equipe = c.Equipe.ToList();

            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar (IFormCollection form)
        {
            // instancia do objeto equipe
            Jogador novoJogador = new Jogador();

            //atribuicao de valores recebidos do formulario 
            novoJogador.Nome = form["Nome"].ToString();

            novoJogador.Nome = form["Email"].ToString();

            novoJogador.Nome = form["Senha"].ToString();

            return LocalRedirect("~/Jogador");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

         [Route("Exluir/{id}")]
        public IActionResult Excluir(int id)
        {
            Jogador jogadorBuscado = c.Jogador.FirstOrDefault(e => e.IdJogador == id);

            c.Remove(jogadorBuscado);

            c.SaveChanges();

            return LocalRedirect("~/Jogador");
        }

        [Route("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            Jogador jogador = c.Jogador.First(x => x.IdJogador == id);

            ViewBag.Jogador = jogador;

            return View("Edit");
        } 

        
    }
}