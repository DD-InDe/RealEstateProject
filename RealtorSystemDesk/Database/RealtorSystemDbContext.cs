using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RealtorSystemDesk.Database;

public partial class RealtorSystemDbContext : DbContext
{
    public RealtorSystemDbContext()
    {
    }

    public RealtorSystemDbContext(DbContextOptions<RealtorSystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientFile> ClientFiles { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractType> ContractTypes { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Passport> Passports { get; set; }

    public virtual DbSet<RealEstateObject> RealEstateObjects { get; set; }

    public virtual DbSet<RealEstateObjectClass> RealEstateObjectClasses { get; set; }

    public virtual DbSet<RealEstateObjectDocument> RealEstateObjectDocuments { get; set; }

    public virtual DbSet<RealEstateObjectPhoto> RealEstateObjectPhotos { get; set; }

    public virtual DbSet<RealEstateObjectType> RealEstateObjectTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=realtor_system_db;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.PassportId).HasName("client_pkey");

            entity.ToTable("client");

            entity.Property(e => e.PassportId)
                .ValueGeneratedNever()
                .HasColumnName("passport_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.GenderId)
                .HasMaxLength(1)
                .HasColumnName("gender_id");
            entity.Property(e => e.IsArchive)
                .HasDefaultValue(false)
                .HasColumnName("is_archive");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middle_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("phone");

            entity.HasOne(d => d.Gender).WithMany(p => p.Clients)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("client_gender_id_fkey");

            entity.HasOne(d => d.Passport).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.PassportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_passport_id_fkey");
        });

        modelBuilder.Entity<ClientFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_file_pkey");

            entity.ToTable("client_file");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.FileData).HasColumnName("file_data");
            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .HasColumnName("file_name");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientFiles)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_file_client_id_fkey");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contract_pkey");

            entity.ToTable("contract");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateCreate).HasColumnName("date_create");
            entity.Property(e => e.IsArchive).HasColumnName("is_archive");
            entity.Property(e => e.RealtorReward)
                .HasMaxLength(150)
                .HasColumnName("realtor_reward");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ValidUntil).HasColumnName("valid_until");

            entity.HasOne(d => d.Client).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("contract_client_id_fkey");

            entity.HasOne(d => d.Type).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("contract_type_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("contract_user_id_fkey");
        });

        modelBuilder.Entity<ContractType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contract_type_pkey");

            entity.ToTable("contract_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gender_pkey");

            entity.ToTable("gender");

            entity.Property(e => e.Id)
                .HasMaxLength(1)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Passport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("passport_pkey");

            entity.ToTable("passport");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IssuedBy)
                .HasMaxLength(200)
                .HasColumnName("issued_by");
            entity.Property(e => e.IssuedDate).HasColumnName("issued_date");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Serial).HasColumnName("serial");
        });

        modelBuilder.Entity<RealEstateObject>(entity =>
        {
            entity.HasKey(e => e.CadastralNumber).HasName("real_estate_object_pkey");

            entity.ToTable("real_estate_object");

            entity.HasIndex(e => e.ContractId, "real_estate_object_contract_id_key").IsUnique();

            entity.Property(e => e.CadastralNumber)
                .HasMaxLength(12)
                .HasColumnName("cadastral_number");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.FloorsCount).HasColumnName("floors_count");
            entity.Property(e => e.Material)
                .HasMaxLength(200)
                .HasColumnName("material");
            entity.Property(e => e.PlotSquare)
                .HasPrecision(10, 2)
                .HasColumnName("plot_square");
            entity.Property(e => e.Price)
                .HasPrecision(15, 2)
                .HasColumnName("price");
            entity.Property(e => e.RoomsCount).HasColumnName("rooms_count");
            entity.Property(e => e.Square)
                .HasPrecision(10, 2)
                .HasColumnName("square");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.YearOfBuilding).HasColumnName("year_of_building");

            entity.HasOne(d => d.Class).WithMany(p => p.RealEstateObjects)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("real_estate_object_class_id_fkey");

            entity.HasOne(d => d.Contract).WithOne(p => p.RealEstateObject)
                .HasForeignKey<RealEstateObject>(d => d.ContractId)
                .HasConstraintName("real_estate_object_contract_id_fkey");

            entity.HasOne(d => d.Type).WithMany(p => p.RealEstateObjects)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("real_estate_object_type_id_fkey");
        });

        modelBuilder.Entity<RealEstateObjectClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("real_estate_object_class_pkey");

            entity.ToTable("real_estate_object_class");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RealEstateObjectDocument>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("real_estate_object_document");

            entity.Property(e => e.BasisOfOwnership).HasColumnName("basis_of_ownership");
            entity.Property(e => e.CertificateOfNoDebt).HasColumnName("certificate_of_no_debt");
            entity.Property(e => e.ExtractFromEgrn).HasColumnName("extract_from_egrn");
            entity.Property(e => e.GuardianshipConsent).HasColumnName("guardianship_consent");
            entity.Property(e => e.ObjectNumber)
                .HasMaxLength(16)
                .HasColumnName("object_number");
            entity.Property(e => e.OwnersPassports).HasColumnName("owners_passports");
            entity.Property(e => e.SpousesConsent).HasColumnName("spouses_consent");

            entity.HasOne(d => d.ObjectNumberNavigation).WithMany()
                .HasForeignKey(d => d.ObjectNumber)
                .HasConstraintName("real_estate_object_document_object_number_fkey");
        });

        modelBuilder.Entity<RealEstateObjectPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("real_estate_object_photo_pkey");

            entity.ToTable("real_estate_object_photo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ObjectNumber)
                .HasMaxLength(16)
                .HasColumnName("object_number");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.ObjectNumberNavigation).WithMany(p => p.RealEstateObjectPhotos)
                .HasForeignKey(d => d.ObjectNumber)
                .HasConstraintName("real_estate_object_photo_cadastral_number_fkey");
        });

        modelBuilder.Entity<RealEstateObjectType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("real_estate_object_type_pkey");

            entity.ToTable("real_estate_object_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(150)
                .HasColumnName("company_name");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middle_name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
