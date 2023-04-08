using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbExameXPaciente
{
    public int IdExameXPaciente { get; set; }

    public int IdExame { get; set; }

    public int IdPaciente { get; set; }

    public DateTime? Data { get; set; }

    public string? Resultado { get; set; }

    public virtual TbExame IdExameNavigation { get; set; } = null!;

    public virtual TbPaciente IdPacienteNavigation { get; set; } = null!;
}
