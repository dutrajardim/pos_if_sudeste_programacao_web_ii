using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbHoraPacienteProfissional
{
    public int IdHoraPacienteProfissional { get; set; }

    public int IdPaciente { get; set; }

    public int IdProfissional { get; set; }

    public DateTime? DataConsulta { get; set; }

    public TimeSpan HoraInicioIndividual { get; set; }

    public TimeSpan HoraFimIndividual { get; set; }

    public bool PrimeiraConculta { get; set; }

    public bool Compareceu { get; set; }

    public string? Motivo { get; set; }

    public string? Resumo { get; set; }

    public decimal? Valor { get; set; }

    public virtual TbPaciente IdPacienteNavigation { get; set; } = null!;

    public virtual TbProfissional IdProfissionalNavigation { get; set; } = null!;

    public virtual ICollection<TbAntropometrium> TbAntropometria { get; } = new List<TbAntropometrium>();

    public virtual ICollection<TbEscalaBristolPacienteConsultum> TbEscalaBristolPacienteConsulta { get; } = new List<TbEscalaBristolPacienteConsultum>();

    public virtual ICollection<TbExameFisico> TbExameFisicos { get; } = new List<TbExameFisico>();

    public virtual ICollection<TbRastreamentoMetabolico> TbRastreamentoMetabolicos { get; } = new List<TbRastreamentoMetabolico>();
}
