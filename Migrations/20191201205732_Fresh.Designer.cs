﻿// <auto-generated />
using System;
using BugTrackerIssueApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BugTrackerIssueApi.Migrations
{
    [DbContext(typeof(BugTrackerContext))]
    [Migration("20191201205732_Fresh")]
    partial class Fresh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BugTrackerIssueApi.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("active")
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("'1'");

                    b.Property<string>("CommentBody")
                        .IsRequired()
                        .HasColumnName("comment_body")
                        .HasColumnType("varchar(1440)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_on")
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("IssueId")
                        .HasColumnName("issue_id")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("DATETIME");

                    b.Property<int>("OwnerId")
                        .HasColumnName("owner_id")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("BugTrackerIssueApi.Models.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("active")
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("'1'");

                    b.Property<DateTime?>("ClosedOn")
                        .HasColumnName("closed_on")
                        .HasColumnType("DATETIME");

                    b.Property<int>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_on")
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(144)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<int>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("priority")
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'1'");

                    b.HasKey("Id");

                    b.ToTable("issues");
                });

            modelBuilder.Entity("BugTrackerIssueApi.Models.Comment", b =>
                {
                    b.HasOne("BugTrackerIssueApi.Models.Issue", "Issue")
                        .WithMany("Comments")
                        .HasForeignKey("IssueId")
                        .HasConstraintName("comment_FK00")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
