using DevIO.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevIO.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var model = new ErrorViewModel();
            if (id == 500)
            {
                model.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                model.Titulo = "Ocorreu um erro!";
                model.ErrorCode = id;
            }
            else if (id == 404)
            {
                model.Mensagem = "A página que está procurando não existe! <br/>Em caso de dúvidas entre em contato com nosso suporte";
                model.Titulo = "Ops! Página não encontrada";
                model.ErrorCode = id;
            }
            else if (id == 403)
            {
                model.Mensagem = "Você não tem permissão para fazer isto.";
                model.Titulo = "Acesso negado";
                model.ErrorCode = id;
            }
            else
            {
                return StatusCode(404);
            }
            return View("Error", model);
        }
    }
}
