using System;
using System.Collections.Generic;

namespace semana_1.Models;

public partial class AspNetRole
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<AspNetUser> Users { get; } = new List<AspNetUser>();
}
