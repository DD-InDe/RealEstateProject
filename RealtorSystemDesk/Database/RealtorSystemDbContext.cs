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

    public virtual DbSet<ClientDocument> ClientDocuments { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractDocument> ContractDocuments { get; set; }

    public virtual DbSet<ContractType> ContractTypes { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Passport> Passports { get; set; }

    public virtual DbSet<RealEstateObject> RealEstateObjects { get; set; }

    public virtual DbSet<RealEstateObjectDocument> RealEstateObjectDocuments { get; set; }

    public virtual DbSet<RealEstateObjectPhoto> RealEstateObjectPhotos { get; set; }

    public virtual DbSet<RealEstateObjectType> RealEstateObjectTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Database=realtor_system_db;Username=postgres;Password=123");

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
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.GenderId)
                .HasMaxLength(1)
                .HasColumnName("gender_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middle_name");

            entity.HasOne(d => d.Gender).WithMany(p => p.Clients)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("client_gender_id_fkey");

            entity.HasOne(d => d.Passport).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.PassportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_passport_id_fkey");
        });

        modelBuilder.Entity<ClientDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_document_pkey");

            entity.ToTable("client_document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientDocuments)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_document_client_id_fkey");

            entity.HasOne(d => d.Document).WithMany(p => p.ClientDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("client_document_document_id_fkey");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contract_pkey");

            entity.ToTable("contract");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateCreate).HasColumnName("date_create");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.IsArchive)
                .HasColumnType("bit(1)")
                .HasColumnName("is_archive");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.ValidUntil).HasColumnName("valid_until");

            entity.HasOne(d => d.Client).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("contract_client_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("contract_employee_id_fkey");

            entity.HasOne(d => d.Type).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("contract_type_id_fkey");
        });

        modelBuilder.Entity<ContractDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contract_document_pkey");

            entity.ToTable("contract_document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");

            entity.HasOne(d => d.Contract).WithMany(p => p.ContractDocuments)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("contract_document_contract_id_fkey");

            entity.HasOne(d => d.Document).WithMany(p => p.ContractDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("contract_document_document_id_fkey");
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

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("document_pkey");

            entity.ToTable("document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.FileName)
                .HasMaxLength(300)
                .HasColumnName("file_name");
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

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("material_pkey");

            entity.ToTable("material");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Passport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("passport_pkey");

            entity.ToTable("passport");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PassportIssuedBy)
                .HasMaxLength(200)
                .HasColumnName("passport_issued_by");
            entity.Property(e => e.PassportIssuedDate).HasColumnName("passport_issued_date");
            entity.Property(e => e.PassportNumber).HasColumnName("passport_number");
            entity.Property(e => e.PassportSerial).HasColumnName("passport_serial");
            entity.Property(e => e.PassportValidUntil).HasColumnName("passport_valid_until");
        });

        modelBuilder.Entity<RealEstateObject>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("real_estate_object_pkey");

            entity.ToTable("real_estate_object");

            entity.Property(e => e.ContractId)
                .ValueGeneratedNever()
                .HasColumnName("contract_id");
            entity.Property(e => e.Address)
                .HasMaxLength(400)
                .HasColumnName("address");
            entity.Property(e => e.BuildingYear).HasColumnName("building_year");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.FloorsCount).HasColumnName("floors_count");
            entity.Property(e => e.IsArchive)
                .HasColumnType("bit(1)")
                .HasColumnName("is_archive");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .HasColumnName("notes");
            entity.Property(e => e.ObjectType).HasColumnName("object_type");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.RoomsCount).HasColumnName("rooms_count");
            entity.Property(e => e.Square)
                .HasPrecision(10, 2)
                .HasColumnName("square");

            entity.HasOne(d => d.Contract).WithOne(p => p.RealEstateObject)
                .HasForeignKey<RealEstateObject>(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("real_estate_object_contract_id_fkey");

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.RealEstateObjects)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("real_estate_object_object_type_fkey");
        });

        modelBuilder.Entity<RealEstateObjectDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("real_estate_object_document_pkey");

            entity.ToTable("real_estate_object_document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.RealEstateObjectId).HasColumnName("real_estate_object_id");

            entity.HasOne(d => d.Document).WithMany(p => p.RealEstateObjectDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("real_estate_object_document_document_id_fkey");

            entity.HasOne(d => d.RealEstateObject).WithMany(p => p.RealEstateObjectDocuments)
                .HasForeignKey(d => d.RealEstateObjectId)
                .HasConstraintName("real_estate_object_document_real_estate_object_id_fkey");
        });

        modelBuilder.Entity<RealEstateObjectPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("real_estate_object_photo_pkey");

            entity.ToTable("real_estate_object_photo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FileName)
                .HasMaxLength(200)
                .HasColumnName("file_name");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");

            entity.HasOne(d => d.Object).WithMany(p => p.RealEstateObjectPhotos)
                .HasForeignKey(d => d.ObjectId)
                .HasConstraintName("real_estate_object_photo_object_id_fkey");
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
