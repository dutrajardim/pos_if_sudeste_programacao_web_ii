using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbPaciente
{
    public int IdPaciente { get; set; }

    public string Nome { get; set; } = null!;

    public string Rg { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public string? NomeResponsavel { get; set; }

    public string Sexo { get; set; } = null!;

    public int Etnia { get; set; }

    public string? Endereco { get; set; }

    public string? Bairro { get; set; }

    public int? IdCidade { get; set; }

    public string? TelResidencial { get; set; }

    public string? TelComercial { get; set; }

    public string? TelCelular { get; set; }

    public string? Profissao { get; set; }

    public bool? FlgAtleta { get; set; }

    public bool? FlgGestante { get; set; }

    public virtual TbCidade? IdCidadeNavigation { get; set; }

    public virtual ICollection<TbAntropometrium> TbAntropometria { get; } = new List<TbAntropometrium>();

    public virtual ICollection<TbEscalaBristolPacienteConsultum> TbEscalaBristolPacienteConsulta { get; } = new List<TbEscalaBristolPacienteConsultum>();

    public virtual ICollection<TbExameXPaciente> TbExameXPacientes { get; } = new List<TbExameXPaciente>();

    public virtual ICollection<TbHistoriaPatologica> TbHistoriaPatologicas { get; } = new List<TbHistoriaPatologica>();

    public virtual ICollection<TbHistoricoAlimentarNutricional> TbHistoricoAlimentarNutricionals { get; } = new List<TbHistoricoAlimentarNutricional>();

    public virtual ICollection<TbHistoricoDoencaAtual> TbHistoricoDoencaAtuals { get; } = new List<TbHistoricoDoencaAtual>();

    public virtual ICollection<TbHistoricoSocialAlimentar> TbHistoricoSocialAlimentars { get; } = new List<TbHistoricoSocialAlimentar>();

    public virtual ICollection<TbHoraPacienteProfissional> TbHoraPacienteProfissionals { get; } = new List<TbHoraPacienteProfissional>();

    public virtual ICollection<TbMedicoPaciente> TbMedicoPacientes { get; } = new List<TbMedicoPaciente>();
}
