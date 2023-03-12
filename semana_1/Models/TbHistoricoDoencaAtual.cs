﻿using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbHistoricoDoencaAtual
{
    public int IdHda { get; set; }

    public int IdPaciente { get; set; }

    public int? IdPatologia { get; set; }

    public string? Historico { get; set; }

    public int? Cirurgia { get; set; }

    public int? Trauma { get; set; }

    public int? Infeccao { get; set; }

    public int? Neoplasia { get; set; }

    public int? Metastase { get; set; }

    public int? Queimadura { get; set; }

    public string? ObsNeoplasia { get; set; }

    public string? ObsMetastase { get; set; }

    public string? ObsQueimadura { get; set; }

    public string? Outros { get; set; }

    public virtual TbPaciente IdPacienteNavigation { get; set; } = null!;

    public virtual TbPatologium? IdPatologiaNavigation { get; set; }
}
