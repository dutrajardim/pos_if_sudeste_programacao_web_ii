using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbGrupoPatologico
{
    public int IdGrupoPatologico { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<TbGrupoPatologicoXPatologium> TbGrupoPatologicoXPatologia { get; } = new List<TbGrupoPatologicoXPatologium>();
}
