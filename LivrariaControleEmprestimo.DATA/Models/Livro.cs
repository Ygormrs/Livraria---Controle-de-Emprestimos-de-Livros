using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LivrariaControleEmprestimo.DATA.Models;

public partial class Livro
{
    public int Id { get; set; }

    [DisplayName("Nome")]
    public string LivroNome { get; set; } = null!;

    [DisplayName("Autor")]
    public string LivroAutor { get; set; } = null!;

    [DisplayName("Editora")]
    public string LivroEditora { get; set; } = null!;

    [DisplayName("Ano de Puiblicação")]
    public DateTime LivroAnoPublicacao { get; set; }

    [DisplayName("Edição")]
    public string? LivroEdicao { get; set; }

    public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; } = new List<LivroClienteEmprestimo>();
}
