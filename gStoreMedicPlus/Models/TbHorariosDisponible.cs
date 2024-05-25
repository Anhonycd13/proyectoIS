using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbHorariosDisponible
{
    public int Id { get; set; }

    public DateTime? FechaCreado { get; set; }

    public DateTime? Fecha { get; set; }

    public string? HoraInicio { get; set; }

    public string? HoraFinal { get; set; }
}
