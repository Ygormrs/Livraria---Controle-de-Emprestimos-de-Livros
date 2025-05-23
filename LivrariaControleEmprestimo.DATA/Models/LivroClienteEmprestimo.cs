﻿using System;
using System.Collections.Generic;

namespace LivrariaControleEmprestimo.DATA.Models;

public partial class LivroClienteEmprestimo
{
    public int Id { get; set; }

    public int? LceIdCliente { get; set; }

    public int? LceIdLivro { get; set; }

    public DateTime? LceDataEmprestimo { get; set; }

    public DateTime? LceDataEntrega { get; set; }

    public bool? LceEntregue { get; set; }

    public virtual Cliente? LceIdClienteNavigation { get; set; }

    public virtual Livro? LceIdLivroNavigation { get; set; }
}
