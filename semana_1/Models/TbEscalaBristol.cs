using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbEscalaBristol
{
    public int IdEscalaBristol { get; set; }

    public string Nome { get; set; } = null!;

    public bool? Sangue { get; set; }

    public virtual ICollection<TbEscalaBristolPacienteConsultum> TbEscalaBristolPacienteConsulta { get; } = new List<TbEscalaBristolPacienteConsultum>();
}
