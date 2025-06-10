using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LivrariaControleEmprestimo.DATA.Models;

public partial class VwLivroClienteEmprestimo
{
    [DisplayName("CPF")]
    public string CliCpf { get; set; } = null!;

    [DisplayName("Nome do Cliente")]
    public string CliNome { get; set; } = null!;

    [DisplayName("Nome do Livro")]
    public string LivroNome { get; set; } = null!;

    public int Id { get; set; }

    public int? LceIdCliente { get; set; }

    public int? LceIdLivro { get; set; }

    [DisplayName("Data de Empréstimo")]
    public DateTime? LceDataEmprestimo { get; set; }

    [DisplayName("Data de Entrega")]
    public DateTime? LceDataEntrega { get; set; }

    [DisplayName("Devolvido?")]
    public bool? LceEntregue { get; set; }
}
