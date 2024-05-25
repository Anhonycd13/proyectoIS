using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbUsuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Usuario { get; set; }

    public string? Password { get; set; }

    public DateTime? FechaCreado { get; set; }

    public DateTime? FechaModificado { get; set; }

    public DateTime? FechaUltimoAcceso { get; set; }

    public string? Tipo { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<TbAntecedente> TbAntecedentes { get; } = new List<TbAntecedente>();

    public virtual ICollection<TbCategoriaDatosA> TbCategoriaDatosAs { get; } = new List<TbCategoriaDatosA>();

    public virtual ICollection<TbCategoriaDatosB> TbCategoriaDatosBs { get; } = new List<TbCategoriaDatosB>();

    public virtual ICollection<TbConsulta> TbConsulta { get; } = new List<TbConsulta>();

    public virtual ICollection<TbPersona> TbPersonas { get; } = new List<TbPersona>();
}
