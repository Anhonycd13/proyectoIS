using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbProducto
{
    public int Id { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Unidades { get; set; }

    public string? Estado { get; set; }

    public string? Tipo { get; set; }
}
