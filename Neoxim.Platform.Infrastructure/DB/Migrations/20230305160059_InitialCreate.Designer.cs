﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Neoxim.Platform.Infrastructure.DB.Contexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Neoxim.Platform.Infrastructure.DB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230305160059_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("nxm")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTimeOffset>("LastChangesDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_changes_date");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("type");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("url");

                    b.Property<Guid>("folder_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("project_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.HasIndex("Title");

                    b.HasIndex("folder_id");

                    b.HasIndex("project_id");

                    b.ToTable("documents", "nxm");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.DocumentIssue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("LastChangesDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_changes_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<byte[]>("SnapshotImage")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("snapshot");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("document_issues", "nxm");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.DocumentIssueComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("author_id");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<DateTimeOffset>("LastChangesDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_changes_date");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.Property<Guid>("issue_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("issue_id");

                    b.ToTable("document_issue_comments", "nxm");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Folder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<DateTimeOffset>("LastChangesDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_changes_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("parent_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.HasIndex("parent_id");

                    b.ToTable("folders", "nxm");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ConstructionType")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("construction_type");

                    b.Property<string>("ContractType")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("contract_type");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("customer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<DateTimeOffset>("LastChangesDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_changes_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("type");

                    b.Property<Guid>("tenant_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("tenant_id");

                    b.ToTable("projects", "nxm");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<DateTimeOffset?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<DateTimeOffset>("LastChangesDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_changes_date");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("tenant_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("tenant_id");

                    b.ToTable("subscriptions", "nxm");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<DateTimeOffset>("LastChangesDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_changes_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tenants", "nxm");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<DateTimeOffset>("LastChangesDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_changes_date");

                    b.Property<Guid>("tenant_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("tenant_id");

                    b.ToTable("users", "nxm");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Document", b =>
                {
                    b.HasOne("Neoxim.Platform.Core.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Neoxim.Platform.Core.Entities.Folder", "Folder")
                        .WithMany("Documents")
                        .HasForeignKey("folder_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Neoxim.Platform.Core.Entities.Project", "Project")
                        .WithMany("Documents")
                        .HasForeignKey("project_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");

                    b.Navigation("Project");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.DocumentIssue", b =>
                {
                    b.HasOne("Neoxim.Platform.Core.Entities.Document", "Document")
                        .WithMany("Issues")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.DocumentIssueComment", b =>
                {
                    b.HasOne("Neoxim.Platform.Core.Entities.DocumentIssue", "Issue")
                        .WithMany("Comments")
                        .HasForeignKey("issue_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Folder", b =>
                {
                    b.HasOne("Neoxim.Platform.Core.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Neoxim.Platform.Core.Entities.Folder", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("parent_id");

                    b.Navigation("Parent");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Project", b =>
                {
                    b.HasOne("Neoxim.Platform.Core.Entities.Tenant", "Tenant")
                        .WithMany("Projects")
                        .HasForeignKey("tenant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Neoxim.Platform.Core.ValueObjects.Amount", "Amount", b1 =>
                        {
                            b1.Property<Guid>("ProjectId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(6)
                                .HasColumnType("character varying(6)")
                                .HasColumnName("amount_currency");

                            b1.Property<decimal>("Value")
                                .HasColumnType("numeric")
                                .HasColumnName("amount_value");

                            b1.HasKey("ProjectId");

                            b1.ToTable("projects", "nxm");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.Navigation("Amount")
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Subscription", b =>
                {
                    b.HasOne("Neoxim.Platform.Core.Entities.Tenant", "Tenant")
                        .WithMany("Subscriptions")
                        .HasForeignKey("tenant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Neoxim.Platform.Core.ValueObjects.Amount", "UnitAmount", b1 =>
                        {
                            b1.Property<Guid>("SubscriptionId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(6)
                                .HasColumnType("character varying(6)")
                                .HasColumnName("amount_currency");

                            b1.Property<decimal>("Value")
                                .HasColumnType("numeric")
                                .HasColumnName("amount_value");

                            b1.HasKey("SubscriptionId");

                            b1.ToTable("subscriptions", "nxm");

                            b1.WithOwner()
                                .HasForeignKey("SubscriptionId");
                        });

                    b.Navigation("Tenant");

                    b.Navigation("UnitAmount")
                        .IsRequired();
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Tenant", b =>
                {
                    b.OwnsOne("Neoxim.Platform.Core.ValueObjects.Contact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("TenantId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("character varying(128)")
                                .HasColumnName("contact_address");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("character varying(128)")
                                .HasColumnName("contact_email");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("contact_phone");

                            b1.HasKey("TenantId");

                            b1.ToTable("tenants", "nxm");

                            b1.WithOwner()
                                .HasForeignKey("TenantId");
                        });

                    b.Navigation("Contact")
                        .IsRequired();
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.User", b =>
                {
                    b.HasOne("Neoxim.Platform.Core.Entities.Tenant", "Tenant")
                        .WithMany("Users")
                        .HasForeignKey("tenant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Neoxim.Platform.Core.ValueObjects.Contact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("character varying(128)")
                                .HasColumnName("contact_address");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("character varying(128)")
                                .HasColumnName("contact_email");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("contact_phone");

                            b1.HasKey("UserId");

                            b1.ToTable("users", "nxm");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Neoxim.Platform.Core.ValueObjects.UserName", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("character varying(128)")
                                .HasColumnName("first_name");

                            b1.Property<string>("Gender")
                                .IsRequired()
                                .HasMaxLength(6)
                                .HasColumnType("character varying(6)")
                                .HasColumnName("gender");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("last_name");

                            b1.HasKey("UserId");

                            b1.ToTable("users", "nxm");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Contact")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Document", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.DocumentIssue", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Folder", b =>
                {
                    b.Navigation("Childs");

                    b.Navigation("Documents");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Project", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("Neoxim.Platform.Core.Entities.Tenant", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Subscriptions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
