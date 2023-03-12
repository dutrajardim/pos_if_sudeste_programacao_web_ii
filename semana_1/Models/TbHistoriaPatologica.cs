﻿using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbHistoriaPatologica
{
    public int IdHistoriaPatologica { get; set; }

    public int IdPaciente { get; set; }

    public int? IdPatologia { get; set; }

    public bool? FlgHas { get; set; }

    public bool? FlgAvc { get; set; }

    public bool? FlgDoencasPulmonares { get; set; }

    public bool? FlgDoencasCardiacas { get; set; }

    public bool? FlgDoencaRenal { get; set; }

    public bool? FlgDoencaHepatica { get; set; }

    public bool? FlgNeoplasia { get; set; }

    public bool? FlgHipercolesterolemia { get; set; }

    public bool? FlgHipertrigliciridemia { get; set; }

    public bool? FlgHiperuricemia { get; set; }

    public bool? FlgAnemias { get; set; }

    public bool? FlgCirurgias { get; set; }

    public bool? FlgDoencasAutoImunes { get; set; }

    public bool? FlgDiabetes { get; set; }

    public string? Obs { get; set; }

    public virtual TbPaciente IdPacienteNavigation { get; set; } = null!;

    public virtual TbPatologium? IdPatologiaNavigation { get; set; }
}
