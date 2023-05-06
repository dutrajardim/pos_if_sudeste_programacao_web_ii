using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbRastreamentoRespostum
{
    public int IdRastreamentoResposta { get; set; }

    public int IdPergunta { get; set; }

    public int VlrRespota { get; set; }

    public int IdParteCorpo { get; set; }

    public string Obs { get; set; } = null!;

    public virtual TbPerguntum IdPerguntaNavigation { get; set; } = null!;

    public virtual ICollection<TbRastreamentoMetabolico> TbRastreamentoMetabolicos { get; } = new List<TbRastreamentoMetabolico>();
}
