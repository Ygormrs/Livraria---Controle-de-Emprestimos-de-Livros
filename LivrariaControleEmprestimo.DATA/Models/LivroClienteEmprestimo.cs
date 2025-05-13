using System;
using System.Collections.Generic;

namespace LivrariaControleEmprestimo.DATA.Models;

public partial class LivroClienteEmprestimo
{
    public int Id { get; set; }

    public int IdLivro { get; set; }

    public int IdCliente { get; set; }

    public DateTime DataEmprestimo { get; set; }

    public DateTime DataDevolucao { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Livro IdLivroNavigation { get; set; } = null!;
}
