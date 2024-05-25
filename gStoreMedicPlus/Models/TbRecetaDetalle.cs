using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbRecetaDetalle
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreado { get; set; } = DateTime.Now; 

    public DateTime? FechaModificado { get; set; }

    public int TbRecetasId { get; set; }
}
