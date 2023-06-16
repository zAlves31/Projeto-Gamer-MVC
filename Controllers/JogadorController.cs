using Microsoft.AspNetCore.Mvc;
using Projeto_Gamer_manha.Infra;
using Projeto_Gamer_manha.Models;

namespace Gamer_BancoDeDados.Controllers
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
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.Jogador = c.Jogador.ToList();
            ViewBag.Equipe = c.Equipe.ToList();

            return View();
        }


        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            ViewBag.Equipe = c.Equipe.ToList();

            Jogador novoJogador = new Jogador();


            novoJogador.Nome = form["Nome"].ToString();
            novoJogador.Email = form["Email"].ToString();
            novoJogador.Senha = form["Senha"].ToString();
            novoJogador.IdEquipe = int.Parse(form["IdEquipe"]);


            c.Jogador.Add(novoJogador);

            c.SaveChanges();

            // atualiza a lista 
            ViewBag.Jogador = c.Jogador.ToList();

            return LocalRedirect("~/Jogador/Listar");

        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            Jogador jogadorBuscado = c.Jogador.FirstOrDefault(e => e.IdJogador == id);

            c.Remove(jogadorBuscado);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            Jogador jogador = c.Jogador.First(x => x.IdJogador == id);

            ViewBag.Jogador = jogador;
            ViewBag.Equipe = c.Equipe.ToList();

            return View("Edit");

        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form)
        {
            Jogador jogador = new Jogador();

            jogador.IdJogador = int.Parse(form["IdJogador"].ToString());

            jogador.Nome = form["Nome"].ToString();
            jogador.Email = form["Email"].ToString();
            jogador.IdEquipe = int.Parse(form["IdEquipe"].ToString());


            Jogador jogadorBuscado = c.Jogador.First(x => x.IdJogador == jogador.IdJogador);


            jogadorBuscado.Nome = jogador.Nome;
            jogadorBuscado.Email = jogador.Email;
            jogadorBuscado.IdEquipe = jogador.IdEquipe;

            c.Jogador.Update(jogadorBuscado);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}