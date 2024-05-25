using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbRecetasDetalle
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreado { get; set; }

    public DateTime? FechaModificado { get; set; }

    public int TbRecetasId { get; set; }
}
