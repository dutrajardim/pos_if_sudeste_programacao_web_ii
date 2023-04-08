using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbLancarReceitasDespesa
{
    public int IdLancamento { get; set; }

    public int IdReceitaDespesa { get; set; }

    public DateTime Data { get; set; }

    public virtual TbGruposReceitasDespesa IdReceitaDespesaNavigation { get; set; } = null!;
}
