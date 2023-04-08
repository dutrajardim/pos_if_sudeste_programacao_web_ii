using System;
using System.Collections.Generic;

namespace semana_2.Models;

public partial class TbAlimento
{
    public int IdAlimento { get; set; }

    public int IdTipoQuantidade { get; set; }

    public string Nome { get; set; } = null!;

    public double Carboidrato { get; set; }

    public double VitaminaA { get; set; }

    public double VitaminaB { get; set; }

    public virtual ICollection<TbReceitaAlimentarPadraoXAlimento> TbReceitaAlimentarPadraoXAlimentos { get; } = new List<TbReceitaAlimentarPadraoXAlimento>();
}
