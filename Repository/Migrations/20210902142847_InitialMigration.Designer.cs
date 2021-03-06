// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20210902142847_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("account");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            AccountType = 0,
                            DateCreated = new DateTime(2021, 9, 2, 9, 28, 46, 932, DateTimeKind.Local).AddTicks(4086),
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 200,
                            AccountType = 1,
                            DateCreated = new DateTime(2021, 9, 2, 9, 28, 46, 935, DateTimeKind.Local).AddTicks(6923),
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 300,
                            AccountType = 0,
                            DateCreated = new DateTime(2021, 9, 2, 9, 28, 46, 935, DateTimeKind.Local).AddTicks(6954),
                            OwnerId = 2
                        });
                });

            modelBuilder.Entity("Domain.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("RegionCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("owner");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "city",
                            FirstName = "John",
                            LastName = "Doe",
                            PostalCode = "00000",
                            RegionCode = "AA",
                            Street = "street"
                        },
                        new
                        {
                            Id = 2,
                            City = "city",
                            FirstName = "Jane",
                            LastName = "Foe",
                            PostalCode = "00000",
                            RegionCode = "AA",
                            Street = "street"
                        });
                });

            modelBuilder.Entity("Domain.Models.Account", b =>
                {
                    b.HasOne("Domain.Models.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Models.Owner", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
