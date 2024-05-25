using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gStoreMedicPlus.Models;

public partial class DbGstoreMedicContext : DbContext
{
    public DbGstoreMedicContext()
    {
    }

    public DbGstoreMedicContext(DbContextOptions<DbGstoreMedicContext> options)
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
                => optionsBuilder.UseSqlServer("server=localhost;database=db_gstore_medic;Integrated Security=True;Trust Server Certificate=true;");
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAntecedente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_antec__3213E83F5C2C5B0C");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_categ__3213E83FDEB7AB3A");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_categ__3213E83FBCECAAC8");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_citas__3213E83F3FBCF5E4");

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
            entity.HasKey(e => e.Tipo).HasName("PK__tb_confi__E7F9564805CD45B8");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_consu__3213E83FFD1950C0");

            entity.ToTable("tb_consultas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaCreado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creado");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.TbPersonasId).HasColumnName("tb_personas_id");
            entity.Property(e => e.TbUsuariosId).HasColumnName("tb_usuarios_id");

            entity.HasOne(d => d.TbUsuarios).WithMany(p => p.TbConsulta)
                .HasForeignKey(d => d.TbUsuariosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_consultas_tb_usuarios");
        });

        modelBuilder.Entity<TbDato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_datos__3213E83F5AADD8E6");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_horar__3213E83F6D0D780D");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_perso__3213E83F8DC5922B");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_perso__3213E83F06287D2E");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_produ__3213E83FC2F31A46");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_recet__3213E83F2FB976C7");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_recet__3213E83F915FF39E");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_roles__3213E83F8AA4E8F2");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_tipo___3213E83F9CBA75F5");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_usuar__3213E83F14DE0861");

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
            entity.Property(e => e.Password)
                .HasColumnType("text")
                .HasColumnName("password");
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
