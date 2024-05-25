using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gStoreMedicPlus.Models;

public partial class DbGstoreMedic2Context : DbContext
{
    public DbGstoreMedic2Context()
    {
    }

    public DbGstoreMedic2Context(DbContextOptions<DbGstoreMedic2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAntecedente> TbAntecedentes { get; set; }

    public virtual DbSet<TbCategoriaDatosA> TbCategoriaDatosAs { get; set; }

    public virtual DbSet<TbCategoriaDatosB> TbCategoriaDatosBs { get; set; }

    public virtual DbSet<TbCita> TbCitas { get; set; }

    public virtual DbSet<TbConfiguracione> TbConfiguraciones { get; set; }

    public virtual DbSet<TbConsulta> TbConsultas { get; set; }

    public virtual DbSet<TbDato> TbDatos { get; set; }

    public virtual DbSet<TbHorariosDisponible> TbHorariosDisponibles { get; set; }

    public virtual DbSet<TbPersona> TbPersonas { get; set; }

    public virtual DbSet<TbPersonasRole> TbPersonasRoles { get; set; }

    public virtual DbSet<TbProducto> TbProductos { get; set; }

    public virtual DbSet<TbReceta> TbRecetas { get; set; }

    public virtual DbSet<TbRecetasDetalle> TbRecetasDetalles { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbTipoAntecedente> TbTipoAntecedentes { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=MSI\\SQLEXPRESS;database=db_gstore_medic_2;Integrated Security=True;Trust Server Certificate=true;");

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //=> optionsBuilder.UseSqlServer("server=localhost;database=db_gstore_medic_2;Integrated Security=True;Trust Server Certificate=true;");

    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("server=localhost;database=db_gstore_medic_2;Integrated Security=True;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAntecedente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_antec__3213E83F2729DA4D");

            entity.ToTable("tb_antecedentes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.TbPersonasId).HasColumnName("tb_personas_id");
            entity.Property(e => e.TbTipoAntecedentesId).HasColumnName("tb_tipo_antecedentes_id");
            entity.Property(e => e.TbUsuariosId).HasColumnName("tb_usuarios_id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.TbTipoAntecedentes).WithMany(p => p.TbAntecedentes)
                .HasForeignKey(d => d.TbTipoAntecedentesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_antecedentes_tb_tipo_antecedentes");

            entity.HasOne(d => d.TbUsuarios).WithMany(p => p.TbAntecedentes)
                .HasForeignKey(d => d.TbUsuariosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_antecedentes_tb_usuarios");
        });

        modelBuilder.Entity<TbCategoriaDatosA>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_categ__3213E83FFB20CD57");

            entity.ToTable("tb_categoria_datos_a");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FechaCreado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creado");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TbUsuariosId).HasColumnName("tb_usuarios_id");

            entity.HasOne(d => d.TbUsuarios).WithMany(p => p.TbCategoriaDatosAs)
                .HasForeignKey(d => d.TbUsuariosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_categoria_datos_a_tb_usuarios");
        });

        modelBuilder.Entity<TbCategoriaDatosB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_categ__3213E83F2E246392");

            entity.ToTable("tb_categoria_datos_b");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FechaCreado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creado");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TbUsuariosId).HasColumnName("tb_usuarios_id");

            entity.HasOne(d => d.TbUsuarios).WithMany(p => p.TbCategoriaDatosBs)
                .HasForeignKey(d => d.TbUsuariosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_categoria_datos_b_tb_usuarios");
        });

        modelBuilder.Entity<TbCita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_citas__3213E83F5621CCA0");

            entity.ToTable("tb_citas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Dpi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("dpi");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCancelada)
                .HasColumnType("datetime")
                .HasColumnName("fecha_cancelada");
            entity.Property(e => e.FechaCita)
                .HasColumnType("datetime")
                .HasColumnName("fecha_cita");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaRealizada)
                .HasColumnType("datetime")
                .HasColumnName("fecha_realizada");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
        });

        modelBuilder.Entity<TbConfiguracione>(entity =>
        {
            entity.HasKey(e => e.Tipo).HasName("PK__tb_confi__E7F956485D8C9ED0");

            entity.ToTable("tb_configuraciones");

            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.Valor).HasColumnName("valor");
        });

        modelBuilder.Entity<TbConsulta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_consu__3213E83F81E872AB");

            entity.ToTable("tb_consultas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddOd).HasColumnName("add_od");
            entity.Property(e => e.AddOs).HasColumnName("add_os");
            entity.Property(e => e.AntecedentesAlergicos).HasColumnName("antecedentes_alergicos");
            entity.Property(e => e.AntecedentesFamiliares).HasColumnName("antecedentes_familiares");
            entity.Property(e => e.AntecedentesMedicos).HasColumnName("antecedentes_medicos");
            entity.Property(e => e.AntecedentesOftalmicos).HasColumnName("antecedentes_oftalmicos");
            entity.Property(e => e.AntecedentesOtros).HasColumnName("antecedentes_otros");
            entity.Property(e => e.AntecedentesQuirurgicos).HasColumnName("antecedentes_quirurgicos");
            entity.Property(e => e.AvcCcOd).HasColumnName("avc_cc_od");
            entity.Property(e => e.AvcCcOs).HasColumnName("avc_cc_os");
            entity.Property(e => e.AvcScOd).HasColumnName("avc_sc_od");
            entity.Property(e => e.AvcScOs).HasColumnName("avc_sc_os");
            entity.Property(e => e.AvlCcOd).HasColumnName("avl_cc_od");
            entity.Property(e => e.AvlCcOs).HasColumnName("avl_cc_os");
            entity.Property(e => e.AvlScOd).HasColumnName("avl_sc_od");
            entity.Property(e => e.AvlScOs).HasColumnName("avl_sc_os");
            entity.Property(e => e.ButOd).HasColumnName("but_od");
            entity.Property(e => e.ButOs).HasColumnName("but_os");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Dip).HasColumnName("dip");
            entity.Property(e => e.ExcOd).HasColumnName("exc_od");
            entity.Property(e => e.ExcOs).HasColumnName("exc_os");
            entity.Property(e => e.FechaCreado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creado");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.FoiOd).HasColumnName("foi_od");
            entity.Property(e => e.FoiOs).HasColumnName("foi_os");
            entity.Property(e => e.ImpresionClinica).HasColumnName("impresion_clinica");
            entity.Property(e => e.LhOd).HasColumnName("lh_od");
            entity.Property(e => e.LhOs).HasColumnName("lh_os");
            entity.Property(e => e.MotivoConsulta).HasColumnName("motivo_consulta");
            entity.Property(e => e.MrLejosOdAdicion).HasColumnName("mr_lejos_od_adicion");
            entity.Property(e => e.MrLejosOdCil).HasColumnName("mr_lejos_od_cil");
            entity.Property(e => e.MrLejosOdEje).HasColumnName("mr_lejos_od_eje");
            entity.Property(e => e.MrLejosOdEsf).HasColumnName("mr_lejos_od_esf");
            entity.Property(e => e.MrLejosOdMateriales).HasColumnName("mr_lejos_od_materiales");
            entity.Property(e => e.MrLejosOsAdicion).HasColumnName("mr_lejos_os_adicion");
            entity.Property(e => e.MrLejosOsCil).HasColumnName("mr_lejos_os_cil");
            entity.Property(e => e.MrLejosOsEje).HasColumnName("mr_lejos_os_eje");
            entity.Property(e => e.MrLejosOsEsf).HasColumnName("mr_lejos_os_esf");
            entity.Property(e => e.MrLejosOsMateriales).HasColumnName("mr_lejos_os_materiales");
            entity.Property(e => e.MsCercaOdAdicion).HasColumnName("ms_cerca_od_adicion");
            entity.Property(e => e.MsCercaOdCil).HasColumnName("ms_cerca_od_cil");
            entity.Property(e => e.MsCercaOdEje).HasColumnName("ms_cerca_od_eje");
            entity.Property(e => e.MsCercaOdEsf).HasColumnName("ms_cerca_od_esf");
            entity.Property(e => e.MsCercaOdMateriales).HasColumnName("ms_cerca_od_materiales");
            entity.Property(e => e.MsCercaOsAdicion).HasColumnName("ms_cerca_os_adicion");
            entity.Property(e => e.MsCercaOsCil).HasColumnName("ms_cerca_os_cil");
            entity.Property(e => e.MsCercaOsEje).HasColumnName("ms_cerca_os_eje");
            entity.Property(e => e.MsCercaOsEsf).HasColumnName("ms_cerca_os_esf");
            entity.Property(e => e.MsCercaOsMateriales).HasColumnName("ms_cerca_os_materiales");
            entity.Property(e => e.MsLejosOdAdicion).HasColumnName("ms_lejos_od_adicion");
            entity.Property(e => e.MsLejosOdCil).HasColumnName("ms_lejos_od_cil");
            entity.Property(e => e.MsLejosOdEje).HasColumnName("ms_lejos_od_eje");
            entity.Property(e => e.MsLejosOdEsf).HasColumnName("ms_lejos_od_esf");
            entity.Property(e => e.MsLejosOdMateriales).HasColumnName("ms_lejos_od_materiales");
            entity.Property(e => e.MsLejosOsAdicion).HasColumnName("ms_lejos_os_adicion");
            entity.Property(e => e.MsLejosOsCil).HasColumnName("ms_lejos_os_cil");
            entity.Property(e => e.MsLejosOsEje).HasColumnName("ms_lejos_os_eje");
            entity.Property(e => e.MsLejosOsEsf).HasColumnName("ms_lejos_os_esf");
            entity.Property(e => e.MsLejosOsMateriales).HasColumnName("ms_lejos_os_materiales");
            entity.Property(e => e.PioOd).HasColumnName("pio_od");
            entity.Property(e => e.PioOs).HasColumnName("pio_os");
            entity.Property(e => e.ProximaCita).HasColumnName("proxima_cita");
            entity.Property(e => e.TbPersonasId).HasColumnName("tb_personas_id");
            entity.Property(e => e.TbUsuariosId).HasColumnName("tb_usuarios_id");
            entity.Property(e => e.Tratamiento).HasColumnName("tratamiento");
            entity.Property(e => e.WOd).HasColumnName("w_od");
            entity.Property(e => e.WOs).HasColumnName("w_os");

            entity.HasOne(d => d.TbPersonas).WithMany(p => p.TbConsulta)
                .HasForeignKey(d => d.TbPersonasId)
                .HasConstraintName("FK_tb_consultas_tb_personas");

            entity.HasOne(d => d.TbUsuarios).WithMany(p => p.TbConsulta)
                .HasForeignKey(d => d.TbUsuariosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_consultas_tb_usuarios");
        });

        modelBuilder.Entity<TbDato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_datos__3213E83FC6FE0DB2");

            entity.ToTable("tb_datos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creado");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.FechaUltimaImpresion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ultima_impresion");
            entity.Property(e => e.TbCategoriaDatosAId).HasColumnName("tb_categoria_datos_a_id");
            entity.Property(e => e.TbCategoriaDatosBId).HasColumnName("tb_categoria_datos_b_id");
            entity.Property(e => e.TbConsultasId).HasColumnName("tb_consultas_id");
            entity.Property(e => e.TbPersonasId).HasColumnName("tb_personas_id");

            entity.HasOne(d => d.TbCategoriaDatosA).WithMany(p => p.TbDatos)
                .HasForeignKey(d => d.TbCategoriaDatosAId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_datos_tb_categoria_datos_a1");

            entity.HasOne(d => d.TbCategoriaDatosB).WithMany(p => p.TbDatos)
                .HasForeignKey(d => d.TbCategoriaDatosBId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_datos_tb_categoria_datos_b");

            //entity.HasOne(d => d.TbConsultas).WithMany(p => p.TbDatos)
            //    .HasForeignKey(d => d.TbConsultasId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_tb_datos_tb_consultas");

            entity.HasOne(d => d.TbPersonas).WithMany(p => p.TbDatos)
                .HasForeignKey(d => d.TbPersonasId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_datos_tb_personas");
        });

        modelBuilder.Entity<TbHorariosDisponible>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_horar__3213E83F90A4EE96");

            entity.ToTable("tb_horarios_disponibles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaCreado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creado");
            entity.Property(e => e.HoraFinal)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("hora_final");
            entity.Property(e => e.HoraInicio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("hora_inicio");
        });

        modelBuilder.Entity<TbPersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_perso__3213E83FA2CE2998");

            entity.ToTable("tb_personas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Dpi)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dpi");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaUltimaVisita)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ultima_visita");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TbUsuariosId).HasColumnName("tb_usuarios_id");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono_1");
            entity.Property(e => e.Telefono2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono_2");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.TbUsuarios).WithMany(p => p.TbPersonas)
                .HasForeignKey(d => d.TbUsuariosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_personas_tb_usuarios");
        });

        modelBuilder.Entity<TbPersonasRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_perso__3213E83FC98D2953");

            entity.ToTable("tb_personas_roles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.TbPersonasId).HasColumnName("tb_personas_id");
            entity.Property(e => e.TbRolesId).HasColumnName("tb_roles_id");

            entity.HasOne(d => d.TbPersonas).WithMany(p => p.TbPersonasRoles)
                .HasForeignKey(d => d.TbPersonasId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_personas_roles_tb_personas");

            entity.HasOne(d => d.TbRoles).WithMany(p => p.TbPersonasRoles)
                .HasForeignKey(d => d.TbRolesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_personas_roles_tb_roles");
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_produ__3213E83F01E7451D");

            entity.ToTable("tb_productos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Unidades)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("unidades");
        });

        modelBuilder.Entity<TbReceta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_recet__3213E83FAE7E8AE4");

            entity.ToTable("tb_recetas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FechaCreado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creado");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.Observaciones)
                .HasColumnType("text")
                .HasColumnName("observaciones");
            entity.Property(e => e.TbConsultasId).HasColumnName("tb_consultas_id");
            entity.Property(e => e.TbUsuariosId).HasColumnName("tb_usuarios_id");
        });

        modelBuilder.Entity<TbRecetasDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_recet__3213E83FD9399702");

            entity.ToTable("tb_recetas_detalle");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creado");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.TbRecetasId).HasColumnName("tb_recetas_id");
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_roles__3213E83F395A5D54");

            entity.ToTable("tb_roles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creado");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TbTipoAntecedente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_tipo___3213E83F6B7223ED");

            entity.ToTable("tb_tipo_antecedentes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creado");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_usuar__3213E83FB85F93A7");

            entity.ToTable("tb_usuarios");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creado");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.FechaUltimoAcceso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ultimo_acceso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Usuario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
