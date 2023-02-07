using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MicroLibrary.Infrastructure.Context
{
    public partial class MicroLibraryContext : DbContext
    {
        public MicroLibraryContext()
        {
        }

        public MicroLibraryContext(DbContextOptions<MicroLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Library> Libraries { get; set; }
        public virtual DbSet<LibraryUser> LibraryUsers { get; set; }
        public virtual DbSet<LibraryUserContact> LibraryUserContacts { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.LibraryId).HasColumnName("LibraryID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Library)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.LibraryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Library");
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.ToTable("ContactType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.ToTable("Library");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LibraryUser>(entity =>
            {
                entity.ToTable("Library.User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.City).HasMaxLength(500);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LibraryId).HasColumnName("LibraryID");

                entity.Property(e => e.Oib)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("OIB");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Library)
                    .WithMany(p => p.LibraryUsers)
                    .HasForeignKey(d => d.LibraryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LibraryUser_Library");
            });

            modelBuilder.Entity<LibraryUserContact>(entity =>
            {
                entity.ToTable("Library.User.Contact");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.LibraryUserId).HasColumnName("LibraryUserID");

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.LibraryUserContacts)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LibraryUserContact_ContactType");

                entity.HasOne(d => d.LibraryUser)
                    .WithMany(p => p.LibraryUserContacts)
                    .HasForeignKey(d => d.LibraryUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LibraryUserContact_LibraryUser");
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.ToTable("Rent");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DateReturned).HasColumnType("datetime");

                entity.Property(e => e.DateStart)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LibraryUserId).HasColumnName("LibraryUserID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rent_Book");

                entity.HasOne(d => d.LibraryUser)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.LibraryUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rent_LibraryUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
