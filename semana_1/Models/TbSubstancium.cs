using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbSubstancium
{
    public int IdSubstancia { get; set; }

    public string Nome { get; set; } = null!;

    public string? InformacaoComplementar { get; set; }
}
