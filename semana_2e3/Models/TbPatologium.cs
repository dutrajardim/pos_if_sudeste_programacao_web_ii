using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbPatologium
{
    public int IdPatologia { get; set; }

    public string Nome { get; set; } = null!;

    public string? InformacaoComplementar { get; set; }

    public virtual ICollection<TbGrupoPatologicoXPatologium> TbGrupoPatologicoXPatologia { get; } = new List<TbGrupoPatologicoXPatologium>();

    public virtual ICollection<TbHistoriaPatologica> TbHistoriaPatologicas { get; } = new List<TbHistoriaPatologica>();

    public virtual ICollection<TbHistoricoDoencaAtual> TbHistoricoDoencaAtuals { get; } = new List<TbHistoricoDoencaAtual>();
}
