using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LivrariaControleEmprestimo.DATA.Models;

public partial class Cliente
{
    public int Id { get; set; }

    [DisplayName("CPF")]
    public string CliCpf { get; set; } = null!;

    [DisplayName("Nome")]
    public string CliNome { get; set; } = null!;

    [DisplayName("Endereço")]
    public string CliEndereco { get; set; } = null!;

    [DisplayName("Cidade")]
    public string CliCidade { get; set; } = null!;

    [DisplayName("Bairro")]
    public string CliBairro { get; set; } = null!;

    [DisplayName("Numero")]
    public string CliNumero { get; set; } = null!;

    [DisplayName("Telefone Celular")]
    public string? CliTelefoneCelular { get; set; }

    [DisplayName("Telefone Fixo")]
    public string? CliTelefoneFixo { get; set; }

    public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; } = new List<LivroClienteEmprestimo>();
}
