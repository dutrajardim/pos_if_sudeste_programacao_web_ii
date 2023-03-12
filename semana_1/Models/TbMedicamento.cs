using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbMedicamento
{
    public int IdMedicamento { get; set; }

    public int IdCategoriaMedicamento { get; set; }

    public string Nome { get; set; } = null!;

    public string? Bula { get; set; }

    public byte[]? BulaArquivo { get; set; }

    public virtual TbCategoriaMedicamento IdCategoriaMedicamentoNavigation { get; set; } = null!;
}
