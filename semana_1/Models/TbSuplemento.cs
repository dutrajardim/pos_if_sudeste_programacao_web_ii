﻿using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class TbSuplemento
{
    public int IdSuplemento { get; set; }

    public int IdTipoQuantidade { get; set; }

    public int Tipo { get; set; }

    public string? Nome { get; set; }

    public double DoseMinima { get; set; }

    public double DoseMaxima { get; set; }

    public double Carboidrato { get; set; }

    public double VitaminaA { get; set; }

    public double VitaminaB { get; set; }
}
