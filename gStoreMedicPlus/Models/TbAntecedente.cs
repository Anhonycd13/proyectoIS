using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbAntecedente
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public string? Tipo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int TbPersonasId { get; set; }

    public int TbTipoAntecedentesId { get; set; }

    public int TbUsuariosId { get; set; }

    public virtual TbTipoAntecedente TbTipoAntecedentes { get; set; } = null!;

    public virtual TbUsuario TbUsuarios { get; set; } = null!;
}
