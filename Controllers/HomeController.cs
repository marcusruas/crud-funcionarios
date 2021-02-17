using Funcionarios.Models;
using Funcionarios.Repository.Interface;
using System;
using System.Linq;
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
            var estados = _repository.ListarEstados();
            var viewModel = new NovoFuncionarioViewModel()
            {
                Estados = estados.ToList(),
                Funcionario = null
            };
            return View(viewModel);
        }

        public ActionResult AddFuncionario(FuncionarioInclusao funcionario)
        {
            bool sucesso = _repository.CadastrarFuncionario(funcionario);
            if (sucesso)
                return RedirectToAction("Index");
            else
                throw new Exception("Falha ao cadastrar funcionário.");
        }

        public ActionResult ExcluirFuncionario(int funcionario)
        {
            bool sucesso = _repository.ExcluirFuncionario(funcionario);
            if (sucesso)
                return RedirectToAction("Index");
            else
                throw new Exception("Falha ao excluir funcionário.");
        }
    }
}