﻿using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbAntropometrium
{
    public int IdAntropometria { get; set; }

    public int IdHoraPacienteProfissional { get; set; }

    public int IdPaciente { get; set; }

    public int? Estatura { get; set; }

    public int? AlturaJoelho { get; set; }

    public int? PesoAtual { get; set; }

    public int? PesoUsual { get; set; }

    public int? TipoProtocolo { get; set; }

    public int? Tricipal { get; set; }

    public int? Subescap { get; set; }

    public int? AuxiliarMed { get; set; }

    public int? SupraIliaca { get; set; }

    public int? Abdomen { get; set; }

    public int? Peitoral { get; set; }

    public int? Coxa { get; set; }

    public int? Biceps { get; set; }

    public int? Panturrilha { get; set; }

    public int? PercGordura { get; set; }

    public int? CircunfBraco { get; set; }

    public int? CircunfAbdomen { get; set; }

    public int? CircunfCintura { get; set; }

    public int? CircunfQuadril { get; set; }

    public virtual TbHoraPacienteProfissional IdHoraPacienteProfissionalNavigation { get; set; } = null!;

    public virtual TbPaciente IdPacienteNavigation { get; set; } = null!;
}
