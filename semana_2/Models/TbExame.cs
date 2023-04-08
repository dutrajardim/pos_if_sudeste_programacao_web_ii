using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbExame
{
    public int IdExame { get; set; }

    public int Grupo { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public virtual ICollection<TbExameXPaciente> TbExameXPacientes { get; } = new List<TbExameXPaciente>();
}
