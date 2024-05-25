using System;
using System.Collections.Generic;

namespace gStoreMedicPlus.Models;

public partial class TbConsulta
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreado { get; set; }

    public DateTime? FechaModificado { get; set; }

    public string? ProximaCita { get; set; }

    public string? MotivoConsulta { get; set; }

    public string? Tratamiento { get; set; }

    public string? ImpresionClinica { get; set; }

    public string? AntecedentesMedicos { get; set; }

    public string? AntecedentesQuirurgicos { get; set; }

    public string? AntecedentesFamiliares { get; set; }

    public string? AntecedentesOftalmicos { get; set; }

    public string? AntecedentesAlergicos { get; set; }

    public string? AntecedentesOtros { get; set; }

    public string? AvlScOd { get; set; }

    public string? AvlScOs { get; set; }

    public string? WOd { get; set; }

    public string? WOs { get; set; }

    public string? AvlCcOd { get; set; }

    public string? AvlCcOs { get; set; }

    public string? AvcScOd { get; set; }

    public string? AvcScOs { get; set; }

    public string? AddOd { get; set; }

    public string? AddOs { get; set; }

    public string? AvcCcOd { get; set; }

    public string? AvcCcOs { get; set; }

    public string? MsLejosOdEsf { get; set; }

    public string? MsLejosOdCil { get; set; }

    public string? MsLejosOdEje { get; set; }

    public string? MsLejosOdAdicion { get; set; }

    public string? MsLejosOdMateriales { get; set; }

    public string? MsLejosOsEsf { get; set; }

    public string? MsLejosOsCil { get; set; }

    public string? MsLejosOsEje { get; set; }

    public string? MsLejosOsAdicion { get; set; }

    public string? MsLejosOsMateriales { get; set; }

    public string? MsCercaOdEsf { get; set; }

    public string? MsCercaOdCil { get; set; }

    public string? MsCercaOdEje { get; set; }

    public string? MsCercaOdAdicion { get; set; }

    public string? MsCercaOdMateriales { get; set; }

    public string? MsCercaOsEsf { get; set; }

    public string? MsCercaOsCil { get; set; }

    public string? MsCercaOsEje { get; set; }

    public string? MsCercaOsAdicion { get; set; }

    public string? MsCercaOsMateriales { get; set; }

    public string? MrLejosOdEsf { get; set; }

    public string? MrLejosOdCil { get; set; }

    public string? MrLejosOdEje { get; set; }

    public string? MrLejosOdAdicion { get; set; }

    public string? MrLejosOdMateriales { get; set; }

    public string? MrLejosOsEsf { get; set; }

    public string? MrLejosOsCil { get; set; }

    public string? MrLejosOsEje { get; set; }

    public string? MrLejosOsAdicion { get; set; }

    public string? MrLejosOsMateriales { get; set; }

    public string? Dip { get; set; }

    public string? LhOd { get; set; }

    public string? LhOs { get; set; }

    public string? ButOd { get; set; }

    public string? ButOs { get; set; }

    public string? PioOd { get; set; }

    public string? PioOs { get; set; }

    public string? ExcOd { get; set; }

    public string? ExcOs { get; set; }

    public string? FoiOd { get; set; }

    public string? FoiOs { get; set; }

    public int TbPersonasId { get; set; }

    public int TbUsuariosId { get; set; }

    //public virtual ICollection<TbDato> TbDatos { get; } = new List<TbDato>();

    public virtual TbPersona TbPersonas { get; set; } = null!;

    public virtual TbUsuario TbUsuarios { get; set; } = null!;
}
