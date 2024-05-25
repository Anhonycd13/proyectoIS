using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbDato
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreado { get; set; }

    public DateTime? FechaModificado { get; set; }

    public DateTime? FechaUltimaImpresion { get; set; }

    public int TbCategoriaDatosAId { get; set; }

    public int TbCategoriaDatosBId { get; set; }

    public int TbPersonasId { get; set; }

    public int TbConsultasId { get; set; }

    public virtual TbCategoriaDatosA TbCategoriaDatosA { get; set; } = null!;

    public virtual TbCategoriaDatosB TbCategoriaDatosB { get; set; } = null!;

    public virtual TbConsulta TbConsultas { get; set; } = null!;

    public virtual TbPersona TbPersonas { get; set; } = null!;
}
