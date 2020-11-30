using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DbFirst
{//questo viene creato automaticamente quando faccio lo scaffold
    public partial class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {
        }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        //Per ciascuna entità c'è un DbSet istanziato.
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Cast> Casts { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Prenotazione> Prenotaziones { get; set; }
        public virtual DbSet<Programmazione> Programmaziones { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        //Visto che abbiamo il costruttore che permette di iserire opzioni, viene anche ereditato questo metodo
        //che dice che se le opzioni non sono state configurate, si usa la stringa che viene indicata sotto.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=CinemaDb; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Cachet).HasColumnType("money");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cast>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.ActorId })
                    .HasName("PK_Cast");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.Casts)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull) /*Specifica qual è il comportamento nel caso in cui si elimini il riferimento, in questo caso mette a null il campo, senza cancellare righe in questa tabella
                    invece Cascade cancellerebbe le righe il cui riferimento è stato cancellato.*/
                    .HasConstraintName("FK_Actors_Cast");
               
                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Casts)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Cast");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Genere)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titolo).HasMaxLength(255);
            });

            modelBuilder.Entity<Prenotazione>(entity =>
            {
                entity.ToTable("Prenotazione");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Mail).HasMaxLength(255);

                entity.Property(e => e.NumeroPosti).HasColumnName("Numero_Posti");

                entity.Property(e => e.ProgrammazioneId).HasColumnName("ProgrammazioneID");

                entity.HasOne(d => d.Programmazione)
                    .WithMany(p => p.Prenotaziones)
                    .HasForeignKey(d => d.ProgrammazioneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prenotazi__Progr__3F466844");
            });

            modelBuilder.Entity<Programmazione>(entity =>
            {
                entity.ToTable("Programmazione");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.PostiDisponibili).HasColumnName("Posti_Disponibili");

                entity.Property(e => e.Prezzo).HasColumnType("money");

                entity.Property(e => e.SalaId).HasColumnName("SalaID");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Programmaziones)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Programma__Movie__3C69FB99");

                entity.HasOne(d => d.Sala)
                    .WithMany(p => p.Programmaziones)
                    .HasForeignKey(d => d.SalaId)
                    .HasConstraintName("FK_Programmazione_Sale");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
