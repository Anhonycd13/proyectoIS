using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbReceta
{
    public int Id { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaCreado { get; set; }

    public DateTime? FechaModificado { get; set; }

    public int TbConsultasId { get; set; }

    public int TbUsuariosId { get; set; }
}
