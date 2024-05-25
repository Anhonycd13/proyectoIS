using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbPersona
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono1 { get; set; }

    public string? Telefono2 { get; set; }

    public string? Correo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime? FechaUltimaVisita { get; set; }

    public string? Estado { get; set; }

    public string? Tipo { get; set; }

    public string? Dpi { get; set; }

    public int TbUsuariosId { get; set; }

    public virtual ICollection<TbConsulta> TbConsulta { get; } = new List<TbConsulta>();

    public virtual ICollection<TbDato> TbDatos { get; } = new List<TbDato>();

    public virtual ICollection<TbPersonasRole> TbPersonasRoles { get; } = new List<TbPersonasRole>();

    public virtual TbUsuario TbUsuarios { get; set; } = null!;
}
