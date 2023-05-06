using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbPai
{
    public int IdPais { get; set; }

    public string? Nome { get; set; }

    public string? Sigla { get; set; }

    public virtual ICollection<TbEstado> TbEstados { get; } = new List<TbEstado>();
}
