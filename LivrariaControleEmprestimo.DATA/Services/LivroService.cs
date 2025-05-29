using LivrariaControleEmprestimo.DATA.Repositories;

namespace LivrariaControleEmprestimo.DATA.Services
{
    public class LivroService
    {
        public RepositoryLivro _repositoryLivro {  get; set; }

        public LivroService()
        {
            _repositoryLivro = new RepositoryLivro();
        }
    }
}
