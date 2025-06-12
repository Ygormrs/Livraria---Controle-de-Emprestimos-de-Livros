using LivrariaControleEmprestimo.DATA.Models;
using LivrariaControleEmprestimo.DATA.Services;
using LivrariaControleEmprestimo.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaControleEmprestimo.WEB.Controllers
{
    public class EmprestimosController : Controller
    {
        private LivroClienteEmprestimoService _serviceEmprestimo = new LivroClienteEmprestimoService();

        private LivroService _livroService = new LivroService();
        private ClienteService _clienteService = new ClienteService();

        public IActionResult Index()
        {
            List<VwLivroClienteEmprestimo> oListVwLivroClienteEmprestimo = _serviceEmprestimo.oRepositoryVwLivroClienteEmprestimo.SelecionarTodos();
            return View(oListVwLivroClienteEmprestimo);
        }

        public IActionResult Create()
        {
            EmprestimoViewModel oEmprestimoViewModel = new EmprestimoViewModel();
            List<Livro> oListLivro = _serviceEmprestimo.oRepositoryLivro.SelecionarTodos();
            List<Cliente> oListCliente = _serviceEmprestimo.oRepositoryCliente.SelecionarTodos();

            oEmprestimoViewModel.oListCliente = oListCliente;
            oEmprestimoViewModel.oListLivro = oListLivro;

            oEmprestimoViewModel.dataEmprestimo = DateTime.Now;
            oEmprestimoViewModel.dataEntrega = DateTime.Now.AddDays(7);

            return View(oEmprestimoViewModel);
        }

        [HttpPost]
        public IActionResult Create(EmprestimoViewModel oEmprestimoViewModel)
        {
            LivroClienteEmprestimo oLivroClienteEmprestimo = new LivroClienteEmprestimo();
            oLivroClienteEmprestimo.LceDataEmprestimo = oEmprestimoViewModel.dataEmprestimo;
            oLivroClienteEmprestimo.LceDataEntrega = oEmprestimoViewModel.dataEntrega;
            oLivroClienteEmprestimo.LceEntregue = false;
            oLivroClienteEmprestimo.LceIdCliente = oEmprestimoViewModel.idCliente;
            oLivroClienteEmprestimo.LceIdLivro = oEmprestimoViewModel.idLivro;

            if (!ModelState.IsValid)
            {
                return View();
            }

            _serviceEmprestimo.oRepositoryLivroClienteEmprestimo.Incluir(oLivroClienteEmprestimo);

            return RedirectToAction("Index");
        }
    }
}