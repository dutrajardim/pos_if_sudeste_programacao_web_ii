using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbTipoAcesso
{
    public int IdTipoAcesso { get; set; }

    public string Nome { get; set; } = null!;

    public bool FlagAtivo { get; set; }

    public virtual ICollection<TbProfissional> TbProfissionals { get; } = new List<TbProfissional>();
}
