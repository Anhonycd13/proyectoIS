using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbCita
{
    public int Id { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaCita { get; set; }

    public DateTime? FechaRealizada { get; set; }

    public DateTime? FechaCancelada { get; set; }

    public string? Nombre { get; set; }

    public string? Dpi { get; set; }

    public string? Descripcion { get; set; }

    public int? Tipo { get; set; }

    public int? Estado { get; set; }
}
