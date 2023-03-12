﻿using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbMedicoPaciente
{
    public int IdMedicoPaciente { get; set; }

    public int IdPaciente { get; set; }

    public int IdProfissional { get; set; }

    public string? InformacaoResumida { get; set; }

    public virtual TbPaciente IdPacienteNavigation { get; set; } = null!;

    public virtual TbProfissional IdProfissionalNavigation { get; set; } = null!;
}
