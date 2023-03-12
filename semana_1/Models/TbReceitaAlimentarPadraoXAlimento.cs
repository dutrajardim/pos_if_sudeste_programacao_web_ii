﻿using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbReceitaAlimentarPadraoXAlimento
{
    public int IdReceitaAlimentarPadraoXAlimentoXQuantidadeAlimento { get; set; }

    public int IdReceitaAlimentarPadrao { get; set; }

    public int IdAlimento { get; set; }

    public int IdQuantidadeAlimento { get; set; }

    public string? Periodicidade { get; set; }

    public string? QuantoTempo { get; set; }

    public virtual TbAlimento IdAlimentoNavigation { get; set; } = null!;

    public virtual TbReceitaAlimentarPadrao IdReceitaAlimentarPadraoNavigation { get; set; } = null!;
}
