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
    }
}
