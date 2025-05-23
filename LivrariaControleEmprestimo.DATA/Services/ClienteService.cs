using LivrariaControleEmprestimo.DATA.Repositories;

namespace LivrariaControleEmprestimo.DATA.Services
{
    public class ClienteService
    {
        public RepositoryCliente _repositoryCliente { get; set; }

        public ClienteService()
        {
            _repositoryCliente = new RepositoryCliente();
        }
    }
}
