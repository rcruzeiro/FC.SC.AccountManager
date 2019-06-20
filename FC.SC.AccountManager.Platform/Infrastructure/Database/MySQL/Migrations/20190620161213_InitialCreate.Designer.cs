﻿// <auto-generated />
using System;
using FC.SC.AccountManager.Platform.Infrastructure.Database.MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FC.SC.AccountManager.Platform.Infrastructure.Database.MySQL.Migrations
{
    [DbContext(typeof(AccountManagerContext))]
    [Migration("20190620161213_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FC.SC.AccountManager.Platform.Domain.Accounts.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<decimal>("Balance")
                        .HasColumnName("balance")
                        .HasColumnType("decimal(7,2)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_at")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("FC.SC.AccountManager.Platform.Domain.Accounts.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("AccountId")
                        .HasColumnName("account_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_at")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("OperationType")
                        .IsRequired()
                        .HasColumnName("operation_type");

                    b.Property<int>("RelatedAccountId")
                        .HasColumnName("related_account_id");

                    b.Property<decimal>("Value")
                        .HasColumnName("value")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Id");

                    b.ToTable("entries");
                });

            modelBuilder.Entity("FC.SC.AccountManager.Platform.Domain.Accounts.Entry", b =>
                {
                    b.HasOne("FC.SC.AccountManager.Platform.Domain.Accounts.Account")
                        .WithMany("Entries")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
