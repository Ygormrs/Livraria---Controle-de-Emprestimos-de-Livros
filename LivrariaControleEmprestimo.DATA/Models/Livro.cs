using System;
using System.Collections.Generic;

namespace LivrariaControleEmprestimo.DATA.Models;

public partial class Livro
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string Editora { get; set; } = null!;

    public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; } = new List<LivroClienteEmprestimo>();
}
