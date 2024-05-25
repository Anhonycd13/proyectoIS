using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbConfiguracione
{
    public string Tipo { get; set; } = null!;

    public string? Valor { get; set; }

    public DateTime? FechaModificado { get; set; }
}
