﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace semana_2.Models;

public partial class DbIfContext : IdentityDbContext
{
    public DbIfContext()
    {
    }

    public DbIfContext(DbContextOptions<DbIfContext> options)
        : base(options)
    {
    }

    // public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    // public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    // public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    // public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    // public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    // public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<TbAlimento> TbAlimentos { get; set; }

    public virtual DbSet<TbAntropometrium> TbAntropometria { get; set; }

    public virtual DbSet<TbCategoriaMedicamento> TbCategoriaMedicamentos { get; set; }

    public virtual DbSet<TbCidade> TbCidades { get; set; }

    public virtual DbSet<TbContrato> TbContratos { get; set; }

    public virtual DbSet<TbEscalaBristol> TbEscalaBristols { get; set; }

    public virtual DbSet<TbEscalaBristolPacienteConsultum> TbEscalaBristolPacienteConsulta { get; set; }

    public virtual DbSet<TbEstado> TbEstados { get; set; }

    public virtual DbSet<TbExame> TbExames { get; set; }

    public virtual DbSet<TbExameFisico> TbExameFisicos { get; set; }

    public virtual DbSet<TbExameXPaciente> TbExameXPacientes { get; set; }

    public virtual DbSet<TbGrupoPatologico> TbGrupoPatologicos { get; set; }

    public virtual DbSet<TbGrupoPatologicoXPatologium> TbGrupoPatologicoXPatologia { get; set; }

    public virtual DbSet<TbGruposReceitasDespesa> TbGruposReceitasDespesas { get; set; }

    public virtual DbSet<TbHistoriaPatologica> TbHistoriaPatologicas { get; set; }

    public virtual DbSet<TbHistoricoAlimentarNutricional> TbHistoricoAlimentarNutricionals { get; set; }

    public virtual DbSet<TbHistoricoDoencaAtual> TbHistoricoDoencaAtuals { get; set; }

    public virtual DbSet<TbHistoricoSocialAlimentar> TbHistoricoSocialAlimentars { get; set; }

    public virtual DbSet<TbHoraPacienteProfissional> TbHoraPacienteProfissionals { get; set; }

    public virtual DbSet<TbLancarReceitasDespesa> TbLancarReceitasDespesas { get; set; }

    public virtual DbSet<TbMedicamento> TbMedicamentos { get; set; }

    public virtual DbSet<TbMedicoPaciente> TbMedicoPacientes { get; set; }

    public virtual DbSet<TbPaciente> TbPacientes { get; set; }

    public virtual DbSet<TbPai> TbPais { get; set; }

    public virtual DbSet<TbPatologium> TbPatologia { get; set; }

    public virtual DbSet<TbPerguntum> TbPergunta { get; set; }

    public virtual DbSet<TbPlano> TbPlanos { get; set; }

    public virtual DbSet<TbProfissional> TbProfissionals { get; set; }

    public virtual DbSet<TbRastreamentoMetabolico> TbRastreamentoMetabolicos { get; set; }

    public virtual DbSet<TbRastreamentoRespostum> TbRastreamentoResposta { get; set; }

    public virtual DbSet<TbReceitaAlimentarPadrao> TbReceitaAlimentarPadraos { get; set; }

    public virtual DbSet<TbReceitaAlimentarPadraoXAlimento> TbReceitaAlimentarPadraoXAlimentos { get; set; }

    public virtual DbSet<TbReceitaMedicaPadrao> TbReceitaMedicaPadraos { get; set; }

    public virtual DbSet<TbSubstancium> TbSubstancia { get; set; }

    public virtual DbSet<TbSuplemento> TbSuplementos { get; set; }

    public virtual DbSet<TbTipoAcesso> TbTipoAcessos { get; set; }

    public virtual DbSet<TbTipoProfissional> TbTipoProfissionals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // modelBuilder.Entity<AspNetRole>(entity =>
        // {
        //     entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
        //         .IsUnique()
        //         .HasFilter("([NormalizedName] IS NOT NULL)");

        //     entity.Property(e => e.Name).HasMaxLength(256);
        //     entity.Property(e => e.NormalizedName).HasMaxLength(256);
        // });

        // modelBuilder.Entity<AspNetRoleClaim>(entity =>
        // {
        //     entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

        //     entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        // });

        // modelBuilder.Entity<AspNetUser>(entity =>
        // {
        //     entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

        //     entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
        //         .IsUnique()
        //         .HasFilter("([NormalizedUserName] IS NOT NULL)");

        //     entity.Property(e => e.Email).HasMaxLength(256);
        //     entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
        //     entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
        //     entity.Property(e => e.UserName).HasMaxLength(256);

        //     entity.HasMany(d => d.Roles).WithMany(p => p.Users)
        //         .UsingEntity<Dictionary<string, object>>(
        //             "AspNetUserRole",
        //             r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
        //             l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
        //             j =>
        //             {
        //                 j.HasKey("UserId", "RoleId");
        //                 j.ToTable("AspNetUserRoles");
        //                 j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
        //             });
        // });

        // modelBuilder.Entity<AspNetUserClaim>(entity =>
        // {
        //     entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

        //     entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        // });

        // modelBuilder.Entity<AspNetUserLogin>(entity =>
        // {
        //     entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

        //     entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

        //     entity.Property(e => e.LoginProvider).HasMaxLength(128);
        //     entity.Property(e => e.ProviderKey).HasMaxLength(128);

        //     entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        // });

        // modelBuilder.Entity<AspNetUserToken>(entity =>
        // {
        //     entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

        //     entity.Property(e => e.LoginProvider).HasMaxLength(128);
        //     entity.Property(e => e.Name).HasMaxLength(128);

        //     entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        // });

        modelBuilder.Entity<TbAlimento>(entity =>
        {
            entity.HasKey(e => e.IdAlimento).HasName("PK__tbAlimen__24065705F9637D45");

            entity.ToTable("tbAlimento");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbAntropometrium>(entity =>
        {
            entity.HasKey(e => e.IdAntropometria).HasName("PK__tbAntrop__53A9E5942AE268DA");

            entity.ToTable("tbAntropometria");

            entity.HasIndex(e => e.IdHoraPacienteProfissional, "IX_tbAntropometria_IdHoraPaciente_Profissional");

            entity.HasIndex(e => e.IdPaciente, "IX_tbAntropometria_IdPaciente");

            entity.Property(e => e.IdHoraPacienteProfissional).HasColumnName("IdHoraPaciente_Profissional");

            entity.HasOne(d => d.IdHoraPacienteProfissionalNavigation).WithMany(p => p.TbAntropometria)
                .HasForeignKey(d => d.IdHoraPacienteProfissional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbAntropo__IdHor__02FC7413");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TbAntropometria)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbAntropo__IdPac__03F0984C");
        });

        modelBuilder.Entity<TbCategoriaMedicamento>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaMedicamento).HasName("PK__tbCatego__14A80672E346B6AA");

            entity.ToTable("tbCategoriaMedicamento");

            entity.Property(e => e.InformacaoComplementar)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbCidade>(entity =>
        {
            entity.HasKey(e => e.IdCidade).HasName("PK__tbCidade__160879A3A746DC0A");

            entity.ToTable("tbCidade");

            entity.HasIndex(e => e.IdEstado, "IX_tbCidade_IdEstado");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.TbCidades)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__tbCidade__IdEsta__3C69FB99");
        });

        modelBuilder.Entity<TbContrato>(entity =>
        {
            entity.HasKey(e => e.IdContrato).HasName("PK__tbContra__8569F05ADE9FA311");

            entity.ToTable("tbContrato");

            entity.HasIndex(e => e.IdPlano, "IX_tbContrato_IdPlano");

            entity.Property(e => e.DataFim).HasColumnType("smalldatetime");
            entity.Property(e => e.DataInicio).HasColumnType("smalldatetime");

            entity.HasOne(d => d.IdPlanoNavigation).WithMany(p => p.TbContratos)
                .HasForeignKey(d => d.IdPlano)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbContrat__IdPla__412EB0B6");
        });

        modelBuilder.Entity<TbEscalaBristol>(entity =>
        {
            entity.HasKey(e => e.IdEscalaBristol).HasName("PK__tbEscala__A6FB417F76A6B4B3");

            entity.ToTable("tbEscalaBristol");

            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbEscalaBristolPacienteConsultum>(entity =>
        {
            entity.HasKey(e => e.IdEscalaBristolPacienteConsulta).HasName("PK__tbEscala__44B7B8967885A4AD");

            entity.ToTable("tbEscalaBristol_Paciente_Consulta");

            entity.HasIndex(e => e.IdEscalaBristol, "IX_tbEscalaBristol_Paciente_Consulta_IdEscalaBristol");

            entity.HasIndex(e => e.IdHoraPacienteProfissional, "IX_tbEscalaBristol_Paciente_Consulta_IdHora_Paciente_Profissional");

            entity.HasIndex(e => e.IdPaciente, "IX_tbEscalaBristol_Paciente_Consulta_IdPaciente");

            entity.Property(e => e.IdEscalaBristolPacienteConsulta).HasColumnName("IdEscalaBristol_Paciente_Consulta");
            entity.Property(e => e.IdHoraPacienteProfissional).HasColumnName("IdHora_Paciente_Profissional");

            entity.HasOne(d => d.IdEscalaBristolNavigation).WithMany(p => p.TbEscalaBristolPacienteConsulta)
                .HasForeignKey(d => d.IdEscalaBristol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbEscalaB__IdEsc__17F790F9");

            entity.HasOne(d => d.IdHoraPacienteProfissionalNavigation).WithMany(p => p.TbEscalaBristolPacienteConsulta)
                .HasForeignKey(d => d.IdHoraPacienteProfissional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbEscalaB__IdHor__19DFD96B");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TbEscalaBristolPacienteConsulta)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbEscalaB__IdPac__18EBB532");
        });

        modelBuilder.Entity<TbEstado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__tbEstado__FBB0EDC1CA882B96");

            entity.ToTable("tbEstado");

            entity.HasIndex(e => e.IdPais, "IX_tbEstado_IdPais");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("UF");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.TbEstados)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbEstado__IdPais__398D8EEE");
        });

        modelBuilder.Entity<TbExame>(entity =>
        {
            entity.HasKey(e => e.IdExame).HasName("PK__tbExame__0C2F360F2216CC85");

            entity.ToTable("tbExame");

            entity.Property(e => e.Descricao)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbExameFisico>(entity =>
        {
            entity.HasKey(e => e.IdExameFisico).HasName("PK__tbExameF__C8897518FB452A27");

            entity.ToTable("tbExameFisico");

            entity.HasIndex(e => e.IdHoraPacienteProfissional, "IX_tbExameFisico_IdHoraPaciente_Profissional");

            entity.Property(e => e.IdHoraPacienteProfissional).HasColumnName("IdHoraPaciente_Profissional");
            entity.Property(e => e.Obs)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Pa)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PA");
            entity.Property(e => e.Snc).HasColumnName("SNC");
            entity.Property(e => e.TipoAtividadeFisica)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdHoraPacienteProfissionalNavigation).WithMany(p => p.TbExameFisicos)
                .HasForeignKey(d => d.IdHoraPacienteProfissional)
                .HasConstraintName("FK__tbExameFi__IdHor__7A672E12");
        });

        modelBuilder.Entity<TbExameXPaciente>(entity =>
        {
            entity.HasKey(e => e.IdExameXPaciente).HasName("PK__tbExame___8F261547E55E544D");

            entity.ToTable("tbExame_X_Pacientes");

            entity.HasIndex(e => e.IdExame, "IX_tbExame_X_Pacientes_IdExame");

            entity.HasIndex(e => e.IdPaciente, "IX_tbExame_X_Pacientes_IdPaciente");

            entity.Property(e => e.IdExameXPaciente).HasColumnName("IdExame_X_Paciente");
            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.Resultado)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdExameNavigation).WithMany(p => p.TbExameXPacientes)
                .HasForeignKey(d => d.IdExame)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbExame_X__IdExa__08B54D69");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TbExameXPacientes)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbExame_X__IdPac__09A971A2");
        });

        modelBuilder.Entity<TbGrupoPatologico>(entity =>
        {
            entity.HasKey(e => e.IdGrupoPatologico).HasName("PK__tbGrupoP__A7D4244DF0B4C5B5");

            entity.ToTable("tbGrupoPatologico");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbGrupoPatologicoXPatologium>(entity =>
        {
            entity.HasKey(e => e.IdPatologiaXGrupoPatologico).HasName("PK__tbGrupoP__2BA30300F08B048B");

            entity.ToTable("tbGrupoPatologico_X_Patologia");

            entity.HasIndex(e => e.IdGrupoPatologico, "IX_tbGrupoPatologico_X_Patologia_IdGrupoPatologico");

            entity.HasIndex(e => e.IdPatologia, "IX_tbGrupoPatologico_X_Patologia_IdPatologia");

            entity.Property(e => e.IdPatologiaXGrupoPatologico).HasColumnName("IdPatologia_X_GrupoPatologico");

            entity.HasOne(d => d.IdGrupoPatologicoNavigation).WithMany(p => p.TbGrupoPatologicoXPatologia)
                .HasForeignKey(d => d.IdGrupoPatologico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbGrupoPa__IdGru__5070F446");

            entity.HasOne(d => d.IdPatologiaNavigation).WithMany(p => p.TbGrupoPatologicoXPatologia)
                .HasForeignKey(d => d.IdPatologia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbGrupoPa__IdPat__5165187F");
        });

        modelBuilder.Entity<TbGruposReceitasDespesa>(entity =>
        {
            entity.HasKey(e => e.IdReceitaDespesa).HasName("PK__tbGrupos__6D0EB540F61EA832");

            entity.ToTable("tbGruposReceitasDespesas");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbHistoriaPatologica>(entity =>
        {
            entity.HasKey(e => e.IdHistoriaPatologica).HasName("PK__tbHistor__86BDE8CFC9133092");

            entity.ToTable("tbHistoriaPatologica");

            entity.HasIndex(e => e.IdPaciente, "IX_tbHistoriaPatologica_IdPaciente");

            entity.HasIndex(e => e.IdPatologia, "IX_tbHistoriaPatologica_IdPatologia");

            entity.Property(e => e.FlgAvc).HasColumnName("FlgAVC");
            entity.Property(e => e.FlgHas).HasColumnName("FlgHAS");
            entity.Property(e => e.Obs)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TbHistoriaPatologicas)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbHistori__IdPac__76969D2E");

            entity.HasOne(d => d.IdPatologiaNavigation).WithMany(p => p.TbHistoriaPatologicas)
                .HasForeignKey(d => d.IdPatologia)
                .HasConstraintName("FK__tbHistori__IdPat__778AC167");
        });

        modelBuilder.Entity<TbHistoricoAlimentarNutricional>(entity =>
        {
            entity.HasKey(e => e.IdHistAlimentarNutricional).HasName("PK__tbHistor__43605910B3DA1AA4");

            entity.ToTable("tbHistoricoAlimentarNutricional");

            entity.HasIndex(e => e.IdPaciente, "IX_tbHistoricoAlimentarNutricional_IdPaciente");

            entity.Property(e => e.DescDietas)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DescExercicios)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DescIntoleranciaAlimentar)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DescMedicamentos)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DescOutros)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Obs)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TbHistoricoAlimentarNutricionals)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbHistori__IdPac__00200768");
        });

        modelBuilder.Entity<TbHistoricoDoencaAtual>(entity =>
        {
            entity.HasKey(e => e.IdHda).HasName("PK__tbHistor__0B5E79E28B52222F");

            entity.ToTable("tbHistoricoDoencaAtual");

            entity.HasIndex(e => e.IdPaciente, "IX_tbHistoricoDoencaAtual_IdPaciente");

            entity.HasIndex(e => e.IdPatologia, "IX_tbHistoricoDoencaAtual_IdPatologia");

            entity.Property(e => e.IdHda).HasColumnName("IdHDA");
            entity.Property(e => e.Historico)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ObsMetastase)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ObsNeoplasia)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ObsQueimadura)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Outros)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TbHistoricoDoencaAtuals)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbHistori__IdPac__72C60C4A");

            entity.HasOne(d => d.IdPatologiaNavigation).WithMany(p => p.TbHistoricoDoencaAtuals)
                .HasForeignKey(d => d.IdPatologia)
                .HasConstraintName("FK__tbHistori__IdPat__73BA3083");
        });

        modelBuilder.Entity<TbHistoricoSocialAlimentar>(entity =>
        {
            entity.HasKey(e => e.IdHistSocialAlimentar).HasName("PK__tbHistor__7735810F6011D5BE");

            entity.ToTable("tbHistoricoSocialAlimentar");

            entity.HasIndex(e => e.IdPaciente, "IX_tbHistoricoSocialAlimentar_IdPaciente");

            entity.Property(e => e.Escolaridade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NomeCompraAlimento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomeCozinhaAlimento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomeRealizaRefeicao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Profissao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RendaFamiliar).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TbHistoricoSocialAlimentars)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbHistori__IdPac__7D439ABD");
        });

        modelBuilder.Entity<TbHoraPacienteProfissional>(entity =>
        {
            entity.HasKey(e => e.IdHoraPacienteProfissional).HasName("PK__tbHoraPa__A67184267BAD11A4");

            entity.ToTable("tbHoraPaciente_Profissional");

            entity.HasIndex(e => e.IdPaciente, "IX_tbHoraPaciente_Profissional_IdPaciente");

            entity.HasIndex(e => e.IdProfissional, "IX_tbHoraPaciente_Profissional_IdProfissional");

            entity.Property(e => e.IdHoraPacienteProfissional).HasColumnName("IdHoraPaciente_Profissional");
            entity.Property(e => e.DataConsulta).HasColumnType("date");
            entity.Property(e => e.HoraFimIndividual).HasPrecision(0);
            entity.Property(e => e.HoraInicioIndividual).HasPrecision(0);
            entity.Property(e => e.Motivo)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Resumo)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TbHoraPacienteProfissionals)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbHoraPac__IdPac__6EF57B66");

            entity.HasOne(d => d.IdProfissionalNavigation).WithMany(p => p.TbHoraPacienteProfissionals)
                .HasForeignKey(d => d.IdProfissional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbHoraPac__IdPro__6FE99F9F");
        });

        modelBuilder.Entity<TbLancarReceitasDespesa>(entity =>
        {
            entity.HasKey(e => e.IdLancamento).HasName("PK__tbLancar__2E53154926286AD6");

            entity.ToTable("tbLancarReceitasDespesas");

            entity.HasIndex(e => e.IdReceitaDespesa, "IX_tbLancarReceitasDespesas_IdReceitaDespesa");

            entity.Property(e => e.Data).HasColumnType("datetime");

            entity.HasOne(d => d.IdReceitaDespesaNavigation).WithMany(p => p.TbLancarReceitasDespesas)
                .HasForeignKey(d => d.IdReceitaDespesa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbLancarR__IdRec__1EA48E88");
        });

        modelBuilder.Entity<TbMedicamento>(entity =>
        {
            entity.HasKey(e => e.IdMedicamento).HasName("PK__tbMedica__AC96376E52F14D42");

            entity.ToTable("tbMedicamento");

            entity.HasIndex(e => e.IdCategoriaMedicamento, "IX_tbMedicamento_IdCategoriaMedicamento");

            entity.Property(e => e.Bula).IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaMedicamentoNavigation).WithMany(p => p.TbMedicamentos)
                .HasForeignKey(d => d.IdCategoriaMedicamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbMedicam__IdCat__5812160E");
        });

        modelBuilder.Entity<TbMedicoPaciente>(entity =>
        {
            entity.HasKey(e => e.IdMedicoPaciente).HasName("PK__tbMedico__1F0BE44CA433BC34");

            entity.ToTable("tbMedico_Paciente");

            entity.HasIndex(e => e.IdPaciente, "IX_tbMedico_Paciente_IdPaciente");

            entity.HasIndex(e => e.IdProfissional, "IX_tbMedico_Paciente_IdProfissional");

            entity.Property(e => e.IdMedicoPaciente).HasColumnName("IdMedico_Paciente");
            entity.Property(e => e.InformacaoResumida)
                .HasMaxLength(5000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TbMedicoPacientes)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbMedico___IdPac__6B24EA82");

            entity.HasOne(d => d.IdProfissionalNavigation).WithMany(p => p.TbMedicoPacientes)
                .HasForeignKey(d => d.IdProfissional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbMedico___IdPro__6C190EBB");
        });

        modelBuilder.Entity<TbPaciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__tbPacien__C93DB49B03A2585E");

            entity.ToTable("tbPaciente");

            entity.HasIndex(e => e.IdCidade, "IX_tbPaciente_IdCidade");

            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cpf)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.DataNascimento).HasColumnType("date");
            entity.Property(e => e.Endereco)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomeResponsavel)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Profissao)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Rg)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("RG");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TelCelular)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.TelComercial)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.TelResidencial)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCidadeNavigation).WithMany(p => p.TbPacientes)
                .HasForeignKey(d => d.IdCidade)
                .HasConstraintName("FK__tbPacient__IdCid__68487DD7");
        });

        modelBuilder.Entity<TbPai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK__tbPais__FC850A7B43473BCC");

            entity.ToTable("tbPais");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbPatologium>(entity =>
        {
            entity.HasKey(e => e.IdPatologia).HasName("PK__tbPatolo__6D573A326AEEE3E4");

            entity.ToTable("tbPatologia");

            entity.Property(e => e.InformacaoComplementar)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbPerguntum>(entity =>
        {
            entity.HasKey(e => e.IdPergunta).HasName("PK__tbPergun__6DC6D9A74686F2EE");

            entity.ToTable("tbPergunta");

            entity.HasIndex(e => e.IdProfissional, "IX_tbPergunta_IdProfissional");

            entity.Property(e => e.Nome)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProfissionalNavigation).WithMany(p => p.TbPergunta)
                .HasForeignKey(d => d.IdProfissional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbPergunt__IdPro__0C85DE4D");
        });

        modelBuilder.Entity<TbPlano>(entity =>
        {
            entity.HasKey(e => e.IdPlano).HasName("PK__tbPlano__4C970C54B227DBD4");

            entity.ToTable("tbPlano");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<TbProfissional>(entity =>
        {
            entity.Ignore(e => e.IdPlano);
            entity.HasKey(e => e.IdProfissional).HasName("PK__tbProfis__B9503FBC93FEB044");

            entity.ToTable("tbProfissional");

            entity.HasIndex(e => e.IdCidade, "IX_tbProfissional_IdCidade");

            entity.HasIndex(e => e.IdContrato, "IX_tbProfissional_IdContrato");

            entity.HasIndex(e => e.IdTipoAcesso, "IX_tbProfissional_IdTipoAcesso");

            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cpf)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.CrmCrn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CRM_CRN");
            entity.Property(e => e.Ddd1)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("DDD1");
            entity.Property(e => e.Ddd2)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("DDD2");
            entity.Property(e => e.Especialidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.IdUser).HasMaxLength(128);
            entity.Property(e => e.Logradouro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Telefone1)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Telefone2)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCidadeNavigation).WithMany(p => p.TbProfissionals)
                .HasForeignKey(d => d.IdCidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbProfiss__IdCid__49C3F6B7");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.TbProfissionals)
                .HasForeignKey(d => d.IdContrato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbProfiss__IdCon__47DBAE45");

            entity.HasOne(d => d.IdTipoAcessoNavigation).WithMany(p => p.TbProfissionals)
                .HasForeignKey(d => d.IdTipoAcesso)
                .HasConstraintName("FK__tbProfiss__IdTip__48CFD27E");
        });

        modelBuilder.Entity<TbRastreamentoMetabolico>(entity =>
        {
            entity.HasKey(e => e.IdRastreamentoMetabolico).HasName("PK__tbRastre__E5AA062396329FF6");

            entity.ToTable("tbRastreamentoMetabolico");

            entity.HasIndex(e => e.IdHoraPacienteProfissional, "IX_tbRastreamentoMetabolico_IdHoraPaciente_Profissional");

            entity.HasIndex(e => e.IdRastreamentoResposta, "IX_tbRastreamentoMetabolico_IdRastreamentoResposta");

            entity.Property(e => e.IdHoraPacienteProfissional).HasColumnName("IdHoraPaciente_Profissional");
            entity.Property(e => e.ObsGeral)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdHoraPacienteProfissionalNavigation).WithMany(p => p.TbRastreamentoMetabolicos)
                .HasForeignKey(d => d.IdHoraPacienteProfissional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbRastrea__IdHor__1332DBDC");

            entity.HasOne(d => d.IdRastreamentoRespostaNavigation).WithMany(p => p.TbRastreamentoMetabolicos)
                .HasForeignKey(d => d.IdRastreamentoResposta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbRastrea__IdRas__123EB7A3");
        });

        modelBuilder.Entity<TbRastreamentoRespostum>(entity =>
        {
            entity.HasKey(e => e.IdRastreamentoResposta).HasName("PK__tbRastre__ABA70EB615D1F5DE");

            entity.ToTable("tbRastreamentoResposta");

            entity.HasIndex(e => e.IdPergunta, "IX_tbRastreamentoResposta_IdPergunta");

            entity.Property(e => e.Obs)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPerguntaNavigation).WithMany(p => p.TbRastreamentoResposta)
                .HasForeignKey(d => d.IdPergunta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbRastrea__IdPer__0F624AF8");
        });

        modelBuilder.Entity<TbReceitaAlimentarPadrao>(entity =>
        {
            entity.HasKey(e => e.IdReceitaAlimentarPadrao).HasName("PK__tbReceit__6386356134E3EECA");

            entity.ToTable("tbReceitaAlimentarPadrao");

            entity.HasIndex(e => e.IdProfissional, "IX_tbReceitaAlimentarPadrao_IdProfissional");

            entity.Property(e => e.InformacaoComplementar)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProfissionalNavigation).WithMany(p => p.TbReceitaAlimentarPadraos)
                .HasForeignKey(d => d.IdProfissional)
                .HasConstraintName("FK__tbReceita__IdPro__5EBF139D");
        });

        modelBuilder.Entity<TbReceitaAlimentarPadraoXAlimento>(entity =>
        {
            entity.HasKey(e => e.IdReceitaAlimentarPadraoXAlimentoXQuantidadeAlimento).HasName("PK__tbReceit__2843B293CFC3AE95");

            entity.ToTable("tbReceitaAlimentarPadrao_X_Alimento");

            entity.HasIndex(e => e.IdAlimento, "IX_tbReceitaAlimentarPadrao_X_Alimento_IdAlimento");

            entity.HasIndex(e => e.IdReceitaAlimentarPadrao, "IX_tbReceitaAlimentarPadrao_X_Alimento_IdReceitaAlimentarPadrao");

            entity.Property(e => e.IdReceitaAlimentarPadraoXAlimentoXQuantidadeAlimento).HasColumnName("IdReceitaAlimentarPadrao_X_Alimento_X_QuantidadeAlimento");
            entity.Property(e => e.Periodicidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QuantoTempo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAlimentoNavigation).WithMany(p => p.TbReceitaAlimentarPadraoXAlimentos)
                .HasForeignKey(d => d.IdAlimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbReceita__IdAli__656C112C");

            entity.HasOne(d => d.IdReceitaAlimentarPadraoNavigation).WithMany(p => p.TbReceitaAlimentarPadraoXAlimentos)
                .HasForeignKey(d => d.IdReceitaAlimentarPadrao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbReceita__IdRec__6477ECF3");
        });

        modelBuilder.Entity<TbReceitaMedicaPadrao>(entity =>
        {
            entity.HasKey(e => e.IdReceitaMedicaPadrao).HasName("PK__tbReceit__E6DF7D7799F5B7A8");

            entity.ToTable("tbReceitaMedicaPadrao");

            entity.HasIndex(e => e.IdProfissional, "IX_tbReceitaMedicaPadrao_IdProfissional");

            entity.Property(e => e.InformacaoComplementar)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProfissionalNavigation).WithMany(p => p.TbReceitaMedicaPadraos)
                .HasForeignKey(d => d.IdProfissional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbReceita__IdPro__619B8048");
        });

        modelBuilder.Entity<TbSubstancium>(entity =>
        {
            entity.HasKey(e => e.IdSubstancia).HasName("PK__tbSubsta__13276D32164DD309");

            entity.ToTable("tbSubstancia");

            entity.Property(e => e.InformacaoComplementar)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbSuplemento>(entity =>
        {
            entity.HasKey(e => e.IdSuplemento).HasName("PK__tbSuplem__EC3A6B1670079CD9");

            entity.ToTable("tbSuplemento");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbTipoAcesso>(entity =>
        {
            entity.HasKey(e => e.IdTipoAcesso).HasName("PK__tbTipoAc__FFC17AE5FD267F9A");

            entity.ToTable("tbTipoAcesso");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbTipoProfissional>(entity =>
        {
            entity.HasKey(e => e.IdTipoProfissional).HasName("PK__tbTipoPr__358F03BEB90F480F");

            entity.ToTable("tbTipoProfissional");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
