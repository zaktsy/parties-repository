﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PartiesApi.Database;

#nullable disable

namespace PartiesApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PartiesApi.Models.DressCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DressCodes");
                });

            modelBuilder.Entity("PartiesApi.Models.FriendRequest", b =>
                {
                    b.Property<Guid>("FromUserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ToUserId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("FromUserId", "ToUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("PartiesApi.Models.Party", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("DressCodeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("LocationLatitude")
                        .HasColumnType("double precision");

                    b.Property<double>("LocationLongitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("OrganizerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DressCodeId");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Parties");
                });

            modelBuilder.Entity("PartiesApi.Models.PartyRule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PartyRules");
                });

            modelBuilder.Entity("PartiesApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PartyPartyRule", b =>
                {
                    b.Property<Guid>("PartiesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PartyRulesId")
                        .HasColumnType("uuid");

                    b.HasKey("PartiesId", "PartyRulesId");

                    b.HasIndex("PartyRulesId");

                    b.ToTable("PartyPartyRule");
                });

            modelBuilder.Entity("PartyUser", b =>
                {
                    b.Property<Guid>("MemberPartiesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PartyMembersId")
                        .HasColumnType("uuid");

                    b.HasKey("MemberPartiesId", "PartyMembersId");

                    b.HasIndex("PartyMembersId");

                    b.ToTable("PartyUser");
                });

            modelBuilder.Entity("PartiesApi.Models.FriendRequest", b =>
                {
                    b.HasOne("PartiesApi.Models.User", "FromUser")
                        .WithMany("SentRequests")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PartiesApi.Models.User", "ToUser")
                        .WithMany("ReceivedRequests")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("PartiesApi.Models.Party", b =>
                {
                    b.HasOne("PartiesApi.Models.DressCode", "DressCode")
                        .WithMany()
                        .HasForeignKey("DressCodeId");

                    b.HasOne("PartiesApi.Models.User", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId");

                    b.Navigation("DressCode");

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("PartyPartyRule", b =>
                {
                    b.HasOne("PartiesApi.Models.Party", null)
                        .WithMany()
                        .HasForeignKey("PartiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartiesApi.Models.PartyRule", null)
                        .WithMany()
                        .HasForeignKey("PartyRulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartyUser", b =>
                {
                    b.HasOne("PartiesApi.Models.Party", null)
                        .WithMany()
                        .HasForeignKey("MemberPartiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartiesApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("PartyMembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartiesApi.Models.User", b =>
                {
                    b.Navigation("ReceivedRequests");

                    b.Navigation("SentRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
