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
            var viewModel = new DadosFuncionarioViewModel()
            {
                Estados = estados.ToList(),
                Funcionario = null
            };
            return View(viewModel);
        }

        public ActionResult DadosFuncionario(int funcionario)
        {
            if (funcionario == 0)
                return RedirectToAction("Index");

            ViewBag.Header = "Atualizar funcionário";
            var estados = _repository.ListarEstados();
            var dadosFuncionario = _repository.ObterFuncionarioPorId(funcionario);
            var viewModel = new FuncionarioAlteracaoViewModel()
            {
                Estados = estados.ToList(),
                Funcionario = dadosFuncionario
            };
            return View(viewModel);
        }

        public ActionResult AdicionarFuncionario(FuncionarioInclusao funcionario)
        {
            bool sucesso = _repository.CadastrarFuncionario(funcionario);
            if (sucesso)
                return RedirectToAction("Index");
            else
                throw new Exception("Falha ao cadastrar funcionário.");
        }

        public ActionResult AlterarFuncionario(FuncionarioAlteracao funcionario)
        {
            bool sucesso = _repository.AtualizarFuncionario(funcionario);
            if (sucesso)
                return RedirectToAction("Index");
            else
                throw new Exception("Falha ao atualizar funcionário.");
        }

        public ActionResult ExcluirFuncionario(int funcionario)
        {
            if (funcionario == 0)
                return RedirectToAction("Index");

            bool sucesso = _repository.ExcluirFuncionario(funcionario);
            if (sucesso)
                return RedirectToAction("Index");
            else
                throw new Exception("Falha ao excluir funcionário.");
        }
    }
}