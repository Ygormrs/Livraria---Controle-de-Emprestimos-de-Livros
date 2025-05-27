using LivrariaControleEmprestimo.DATA.Models;
using LivrariaControleEmprestimo.DATA.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaControleEmprestimo.WEB.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteService _clienteService = new ClienteService();
        public IActionResult Index()
        {
            List<Cliente> ListCliente = _clienteService._repositoryCliente.SelecionarTodos();
            return View(ListCliente);
        }

        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _clienteService._repositoryCliente.Incluir(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Cliente oCliente = _clienteService._repositoryCliente.SelecionarPk(id);
            return View(oCliente);
        }
    }
}
