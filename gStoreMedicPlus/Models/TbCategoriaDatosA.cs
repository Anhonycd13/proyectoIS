using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbCategoriaDatosA
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreado { get; set; }

    public DateTime? FechaModificado { get; set; }

    public int TbUsuariosId { get; set; }

    public virtual ICollection<TbDato> TbDatos { get; } = new List<TbDato>();

    public virtual TbUsuario TbUsuarios { get; set; } = null!;
}
