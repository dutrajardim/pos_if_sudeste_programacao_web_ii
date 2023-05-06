using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbCategoriaMedicamento
{
    public int IdCategoriaMedicamento { get; set; }

    public string Nome { get; set; } = null!;

    public string? InformacaoComplementar { get; set; }

    public virtual ICollection<TbMedicamento> TbMedicamentos { get; } = new List<TbMedicamento>();
}
