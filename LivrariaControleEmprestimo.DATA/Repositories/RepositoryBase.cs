using LivrariaControleEmprestimo.DATA.Interfaces;
using LivrariaControleEmprestimo.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaControleEmprestimo.DATA.Repositories
{
    public class RepositoryBase<T> : IRepositoryModel<T>, IDisposable where T : class
    {
        protected ControleEmprestimoLivroContext _context;
        public bool _SaveChanges = true;

        public RepositoryBase(bool saveChanches = true)
        {
            _SaveChanges = saveChanches;
            _context = new ControleEmprestimoLivroContext();
        }

        public T Alterar(T objeto)
        {
            _context.Entry(objeto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            if (_SaveChanges)
            {
                _context.SaveChanges();
            }

            return objeto;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Excluir(T objeto)
        {
            _context.Set<T>().Remove(objeto);

            if (_SaveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void Excluir(params object[] variavel)
        {
            var obj = SelecionarPk(variavel);
            Excluir(obj);
        }

        public T Incluir(T objeto)
        {
            _context.Set<T>().Add(objeto);

            if (_SaveChanges)
            {
                _context.SaveChanges();
            }

            return objeto;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public T SelecionarPk(params object[] variavel)
        {
            return _context.Set<T>().Find(variavel);
        }

        public List<T> SelecionarTodos()
        {
            return _context.Set<T>().ToList();
        }
    }
}
