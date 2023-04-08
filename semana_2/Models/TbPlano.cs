using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbPlano
{
    public int IdPlano { get; set; }

    public string Nome { get; set; } = null!;

    public int Validade { get; set; }

    public decimal Valor { get; set; }

    public virtual ICollection<TbContrato> TbContratos { get; } = new List<TbContrato>();
}
