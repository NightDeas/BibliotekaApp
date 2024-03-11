﻿// <auto-generated />
using System;
using BibliotekaApp.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotekaApp.Migrations
{
    [DbContext(typeof(DbContextBiblioteka))]
    [Migration("20240311210038_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BibliotekaApp.Entites.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateOfDead")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("genreID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int")
                        .HasColumnName("PublisherID");

                    b.Property<int>("YearOfPublication")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_book");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PublisherId");

                    b.HasIndex(new[] { "Name" }, "UQ__book__737584F6C2001224")
                        .IsUnique();

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Note")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_genre");

                    b.HasIndex(new[] { "Name" }, "UQ__genre__737584F68625D04C")
                        .IsUnique();

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Duties")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id")
                        .HasName("PK_post");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.PublishingHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK_Publishing_house");

                    b.HasIndex(new[] { "Name" }, "UQ__publishi__649AECA47788D4FC")
                        .IsUnique();

                    b.ToTable("PublishingHouses");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Reader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id")
                        .HasName("PK_Reader");

                    b.HasIndex("GenderId");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("PostID");

                    b.HasKey("Id")
                        .HasName("PK_Staff");

                    b.HasIndex("PostId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.TakenBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BookReaderId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBack")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateOfGet")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsBack")
                        .HasColumnType("bit");

                    b.Property<int>("StaffId")
                        .HasColumnType("int")
                        .HasColumnName("StaffID");

                    b.HasKey("Id")
                        .HasName("PK_bookID");

                    b.HasIndex("BookId");

                    b.HasIndex("BookReaderId");

                    b.HasIndex("StaffId");

                    b.ToTable("TakenBooks");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Author", b =>
                {
                    b.HasOne("BibliotekaApp.Entites.Gender", "Gender")
                        .WithMany("Authors")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Authors_Genders");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Book", b =>
                {
                    b.HasOne("BibliotekaApp.Entites.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Books_Authors");

                    b.HasOne("BibliotekaApp.Entites.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_book_genre");

                    b.HasOne("BibliotekaApp.Entites.PublishingHouse", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_book_publishing_house");

                    b.Navigation("Author");

                    b.Navigation("Genre");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Reader", b =>
                {
                    b.HasOne("BibliotekaApp.Entites.Gender", "Gender")
                        .WithMany("Readers")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Readers_Genders");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Staff", b =>
                {
                    b.HasOne("BibliotekaApp.Entites.Post", "Post")
                        .WithMany("Staff")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_staff_post");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.TakenBook", b =>
                {
                    b.HasOne("BibliotekaApp.Entites.Book", "Book")
                        .WithMany("TakenBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_issued_book_book");

                    b.HasOne("BibliotekaApp.Entites.Reader", "BookReader")
                        .WithMany("TakenBooks")
                        .HasForeignKey("BookReaderId")
                        .IsRequired()
                        .HasConstraintName("FK_issued_book_readers");

                    b.HasOne("BibliotekaApp.Entites.Staff", "Staff")
                        .WithMany("TakenBooks")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_issued_book_staff");

                    b.Navigation("Book");

                    b.Navigation("BookReader");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Book", b =>
                {
                    b.Navigation("TakenBooks");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Gender", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Readers");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Post", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.PublishingHouse", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Reader", b =>
                {
                    b.Navigation("TakenBooks");
                });

            modelBuilder.Entity("BibliotekaApp.Entites.Staff", b =>
                {
                    b.Navigation("TakenBooks");
                });
#pragma warning restore 612, 618
        }
    }
}