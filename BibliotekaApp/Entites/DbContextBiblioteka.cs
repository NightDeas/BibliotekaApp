using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaApp.Entites;

public partial class DbContextBiblioteka : DbContext
{
    public DbContextBiblioteka()
    {
    }

    public DbContextBiblioteka(DbContextOptions<DbContextBiblioteka> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PublishingHouse> PublishingHouses { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<TakenBook> TakenBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-NM4JG25\\TEST;Initial Catalog=113-PR-Burnasov-Biblioteka1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DateOfDead).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Patronymic).HasMaxLength(255);

            entity.HasOne(d => d.Gender).WithMany(p => p.Authors)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Authors_Genders");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_book");

            entity.HasIndex(e => e.Name, "UQ__book__737584F6C2001224").IsUnique();

            entity.Property(e => e.GenreId).HasColumnName("genreID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_Authors");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_book_genre");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("FK_book_publishing_house");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_genre");

            entity.HasIndex(e => e.Name, "UQ__genre__737584F68625D04C").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Note).IsUnicode(false);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_post");

            entity.Property(e => e.Duties).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Requirements).IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<PublishingHouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Publishing_house");

            entity.HasIndex(e => e.Name, "UQ__publishi__649AECA47788D4FC").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Town).HasMaxLength(255);
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Reader");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Passport).IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Gender).WithMany(p => p.Readers)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Readers_Genders");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Staff");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Passport).IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PostId).HasColumnName("PostID");

            entity.HasOne(d => d.Post).WithMany(p => p.Staff)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_staff_post");
        });

        modelBuilder.Entity<TakenBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_bookID");

            entity.Property(e => e.DateOfBack).HasColumnType("datetime");
            entity.Property(e => e.DateOfGet).HasColumnType("datetime");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");

            entity.HasOne(d => d.Book).WithMany(p => p.TakenBooks)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_issued_book_book");

            entity.HasOne(d => d.BookReader).WithMany(p => p.TakenBooks)
                .HasForeignKey(d => d.BookReaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_issued_book_readers");

            entity.HasOne(d => d.Staff).WithMany(p => p.TakenBooks)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_issued_book_staff");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
