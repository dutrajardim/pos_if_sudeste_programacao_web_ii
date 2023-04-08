﻿using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbGrupoPatologicoXPatologium
{
    public int IdPatologiaXGrupoPatologico { get; set; }

    public int IdGrupoPatologico { get; set; }

    public int IdPatologia { get; set; }

    public virtual TbGrupoPatologico IdGrupoPatologicoNavigation { get; set; } = null!;

    public virtual TbPatologium IdPatologiaNavigation { get; set; } = null!;
}
