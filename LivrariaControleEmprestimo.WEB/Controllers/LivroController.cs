using LivrariaControleEmprestimo.DATA.Models;
using LivrariaControleEmprestimo.DATA.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaControleEmprestimo.WEB.Controllers
{
    public class LivroController : Controller
    {
        private LivroService _livroService = new LivroService();

        public IActionResult Index()
        {
            List<Livro> ListLivro = _livroService._repositoryLivro.SelecionarTodos();
            return View(ListLivro);
        }

        public IActionResult Create() 
        {
            return View();
        }
    }
}
