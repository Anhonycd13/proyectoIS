using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbPersonasRole
{
    public int Id { get; set; }

    public int TbPersonasId { get; set; }

    public int TbRolesId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual TbPersona TbPersonas { get; set; } = null!;

    public virtual TbRole TbRoles { get; set; } = null!;
}
