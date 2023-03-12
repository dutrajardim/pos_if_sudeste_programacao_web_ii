using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbCidade
{
    public int IdCidade { get; set; }

    public int? IdEstado { get; set; }

    public string? Nome { get; set; }

    public virtual TbEstado? IdEstadoNavigation { get; set; }

    public virtual ICollection<TbPaciente> TbPacientes { get; } = new List<TbPaciente>();

    public virtual ICollection<TbProfissional> TbProfissionals { get; } = new List<TbProfissional>();
}
