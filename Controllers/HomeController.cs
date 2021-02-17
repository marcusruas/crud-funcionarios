using Funcionarios.Repository.Interface;
using System.Web.Mvc;

namespace Funcionarios.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFuncionarioRepository _repository;
        public HomeController(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Header = "Funcionários cadastrados";
            var funcionarios = _repository.ListarFuncionarios();
            return View(funcionarios);
        }

        public ActionResult NovoFuncionario()
        {
            ViewBag.Header = "Novo funcionário";
            return View();
        }
    }
}