using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbRole
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreado { get; set; }

    public DateTime? FechaModificado { get; set; }

    public virtual ICollection<TbPersonasRole> TbPersonasRoles { get; } = new List<TbPersonasRole>();
}
