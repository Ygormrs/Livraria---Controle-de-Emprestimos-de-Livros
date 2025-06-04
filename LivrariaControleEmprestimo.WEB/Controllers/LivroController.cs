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

        [HttpPost]
        public IActionResult Create(Livro model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _livroService._repositoryLivro.Incluir(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Livro oLivro = _livroService._repositoryLivro.SelecionarPk(id);
            return View(oLivro);
        }

        public IActionResult Edit(int id)
        {
            Livro oLivro = _livroService._repositoryLivro.SelecionarPk(id);
            return View(oLivro);
        }

        [HttpPost]
        public IActionResult Edit(Livro model)
        {
            Livro oLivro = _livroService._repositoryLivro.Alterar(model);
            int id = oLivro.Id;

            return RedirectToAction("Details", new { id });
        }
    }
}
