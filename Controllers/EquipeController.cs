using Microsoft.AspNetCore.Mvc;
using Projeto_Gamer_manha.Infra;
using Projeto_Gamer_manha.Models;

namespace Projeto_Gamer_manha.Controllers
{
    [Route("[controller]")]
    public class EquipeController : Controller
    {
        private readonly ILogger<EquipeController> _logger;

        public EquipeController(ILogger<EquipeController> logger)
        {
            _logger = logger;
        }

        Context c = new Context();
        
        [Route("Listar")]

        public IActionResult Index()
        {
            // variavel que armazena as equipes listadas do banco de dados
            ViewBag.Equipe = c.Equipe.ToList();

            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            // instancia do objeto equipe
            Equipe novaEquipe = new Equipe();

            // atribuicao de valores recebidos do formulario 
            // novaEquipe.Nome = form["Nome"].ToString();

            // inicio da logica do upload de imagem
            if (form.Files.Count > 0)
            {
                
                var file = form.Files[0];

                var folder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/Equipes");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                // gerar o caminho completo ate o caminho do arquivo(imagem - nome com extensao)
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;

            }
            else
            {
                novaEquipe.Imagem = "padrao.png";
            }
            
            // aqui estava chegando como string (nao queremos assim)
            novaEquipe.Imagem = form["Imagem"].ToString();

            // adiciona objeto na tabela do BD
            c.Equipe.Add(novaEquipe);

            // salva alteracoes feitas no BD
            c.SaveChanges();

            return LocalRedirect("~/Equipe/Listar");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}