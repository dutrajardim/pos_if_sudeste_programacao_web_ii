using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbProfissional
{
  public int IdProfissional { get; set; }

  public int? IdTipoProfissional { get; set; }

  public int IdContrato { get; set; }

  public int? IdTipoAcesso { get; set; }

  public int IdCidade { get; set; }

  public string IdUser { get; set; } = null!;

  public string Nome { get; set; } = null!;

  public string Cpf { get; set; } = null!;

  public string? CrmCrn { get; set; }

  public string? Especialidade { get; set; }

  public string? Logradouro { get; set; }

  public string Numero { get; set; } = null!;

  public string Bairro { get; set; } = null!;

  public string Cep { get; set; } = null!;

  public string? Cidade { get; set; }

  public string? Estado { get; set; }

  public string? Ddd1 { get; set; }

  public string? Ddd2 { get; set; }

  public string? Telefone1 { get; set; }

  public string? Telefone2 { get; set; }

  public decimal? Salario { get; set; }

  public virtual TbCidade? IdCidadeNavigation { get; set; }

  public virtual TbContrato? IdContratoNavigation { get; set; }

  public virtual TbTipoAcesso? IdTipoAcessoNavigation { get; set; }

  public virtual ICollection<TbHoraPacienteProfissional> TbHoraPacienteProfissionals { get; } = new List<TbHoraPacienteProfissional>();

  public virtual ICollection<TbMedicoPaciente> TbMedicoPacientes { get; } = new List<TbMedicoPaciente>();

  public virtual ICollection<TbPerguntum> TbPergunta { get; } = new List<TbPerguntum>();

  public virtual ICollection<TbReceitaAlimentarPadrao> TbReceitaAlimentarPadraos { get; } = new List<TbReceitaAlimentarPadrao>();

  public virtual ICollection<TbReceitaMedicaPadrao> TbReceitaMedicaPadraos { get; } = new List<TbReceitaMedicaPadrao>();
}
