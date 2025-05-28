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

        public IActionResult Edit(int id)
        {
            Cliente oCliente = _clienteService._repositoryCliente.SelecionarPk(id);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente model)
        {
            Cliente oCliente = _clienteService._repositoryCliente.Alterar(model);

            int id = oCliente.Id;

            return RedirectToAction("Details", new { id });
        }

        public IActionResult Delete(int id)
        {
            _clienteService._repositoryCliente.Excluir(id);
            return RedirectToAction("Index");
        }
        
    }
}
