using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_CleanArchitecture.Infrastructure.Data.Migrations
{
  [DbContext(typeof(AppDbContext))]
  [Migration("Customer")]
  partial class Customer
  {
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

      modelBuilder.Entity("API_CleanArchitecture.Core.CustomerAggregate.Customer", b =>
      {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("INTEGER");

        b.Property<string>("Name")
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("TEXT");

        b.Property<string>("LastName")
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("TEXT");

        b.Property<string>("Email")
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("TEXT");

        b.Property<string>("Identification")
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("TEXT");

        b.Property<string>("Phone")
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("TEXT");

        b.Property<string>("Address")
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("TEXT");

        b.Property<string>("Gender")
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("TEXT");

        b.Property<DateOnly>("Birthday")
            .IsRequired()
            .HasColumnType("DATE");

        b.Property<DateTime>("CreatedDate")
            .IsRequired()
            .HasColumnType("DATETIME");

        b.Property<DateTime>("LastModifiedDate")
            .IsRequired()
            .HasColumnType("DATETIME");

        b.HasKey("Id");

        b.ToTable("Customer");
      });
    }
  }
}
