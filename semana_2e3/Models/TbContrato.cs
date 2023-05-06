using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbContrato
{
  public int IdContrato { get; set; }

  public int IdPlano { get; set; }

  public DateTime? DataInicio { get; set; }

  public DateTime? DataFim { get; set; }

  public virtual TbPlano? IdPlanoNavigation { get; set; }

  public virtual ICollection<TbProfissional> TbProfissionals { get; } = new List<TbProfissional>();
}
