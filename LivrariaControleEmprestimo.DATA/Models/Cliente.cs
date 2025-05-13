using System;
using System.Collections.Generic;

namespace LivrariaControleEmprestimo.DATA.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Cpf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; } = new List<LivroClienteEmprestimo>();
}
