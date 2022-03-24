using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_oneUp_webApi.Domain;

#nullable disable

namespace senai_oneUp_webApi.Contexts
{
    public partial class OneUpContext : DbContext
    {
        public OneUpContext()
        {
        }

        public OneUpContext(DbContextOptions<OneUpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamento> Agendamentos { get; set; }
        public virtual DbSet<Arquivo> Arquivos { get; set; }
        public virtual DbSet<Presenca> Presencas { get; set; }
        public virtual DbSet<Representante> Representantes { get; set; }
        public virtual DbSet<Varejistum> Varejista { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=aa1rkwleda6gl6r.c8lp4wmw1myz.us-east-1.rds.amazonaws.com; Initial Catalog= oneUp_Db; user id=userrds; pwd=3IgQludX");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.HasKey(e => e.IdAgendamento)
                    .HasName("PK__agendame__943BE63E8692DD0A");

                entity.ToTable("agendamento");

                entity.Property(e => e.IdAgendamento).HasColumnName("idAgendamento");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdArquivo).HasColumnName("idArquivo");

                entity.Property(e => e.IdRepresentante).HasColumnName("idRepresentante");

                entity.Property(e => e.IdVarejista).HasColumnName("idVarejista");

                entity.Property(e => e.Link)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.HasOne(d => d.IdArquivoNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdArquivo)
                    .HasConstraintName("FK__agendamen__idArq__3E52440B");

                entity.HasOne(d => d.IdRepresentanteNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdRepresentante)
                    .HasConstraintName("FK__agendamen__idRep__3C69FB99");

                entity.HasOne(d => d.IdVarejistaNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdVarejista)
                    .HasConstraintName("FK__agendamen__idVar__3D5E1FD2");
            });

            modelBuilder.Entity<Arquivo>(entity =>
            {
                entity.HasKey(e => e.IdArquivo)
                    .HasName("PK__arquivo__C91FC4C2C8781B48");

                entity.ToTable("arquivo");

                entity.Property(e => e.IdArquivo).HasColumnName("idArquivo");

                entity.Property(e => e.CaminhoArquivo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("caminhoArquivo");
            });

            modelBuilder.Entity<Presenca>(entity =>
            {
                entity.HasKey(e => e.IdPresenca)
                    .HasName("PK__presenca__44CEA42706477255");

                entity.ToTable("presenca");

                entity.Property(e => e.IdPresenca).HasColumnName("idPresenca");

                entity.Property(e => e.IdAgendamento).HasColumnName("idAgendamento");

                entity.Property(e => e.IdRepresentante).HasColumnName("idRepresentante");

                entity.Property(e => e.IdVarejista).HasColumnName("idVarejista");

                entity.Property(e => e.Situacao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("situacao");

                entity.HasOne(d => d.IdAgendamentoNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdAgendamento)
                    .HasConstraintName("FK__presenca__idAgen__412EB0B6");

                entity.HasOne(d => d.IdRepresentanteNavigation)
                    .WithMany(p => p.Presenca)
                    .HasForeignKey(d => d.IdRepresentante)
                    .HasConstraintName("FK__presenca__idRepr__4222D4EF");

                entity.HasOne(d => d.IdVarejistaNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdVarejista)
                    .HasConstraintName("FK__presenca__idVare__4316F928");
            });

            modelBuilder.Entity<Representante>(entity =>
            {
                entity.HasKey(e => e.IdRepresentante)
                    .HasName("PK__represen__119773E327ECA2A6");

                entity.ToTable("representantes");

                entity.Property(e => e.IdRepresentante).HasColumnName("idRepresentante");

                entity.Property(e => e.Permissao).HasColumnName("permissao");

                entity.Property(e => e.Contato)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contato");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Produto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("produto");

                entity.Property(e => e.Senha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("senha");

            });

            modelBuilder.Entity<Varejistum>(entity =>
            {
                entity.HasKey(e => e.IdVarejista)
                    .HasName("PK__varejist__33A5C7C0BD47527D");

                entity.ToTable("varejista");

                entity.Property(e => e.IdVarejista).HasColumnName("idVarejista");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.Permissao).HasColumnName("permissao");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
