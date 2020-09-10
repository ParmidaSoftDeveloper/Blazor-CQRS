﻿// <auto-generated />
using System;
using Atlas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Atlas.Data.Migrations.AtlasMigrations
{
    [DbContext(typeof(AtlasDbContext))]
    partial class AtlasDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Atlas.Domain.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PermissionSetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RepliesCount")
                        .HasColumnType("int");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TopicsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionSetId");

                    b.HasIndex("SiteId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Atlas.Domain.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TargetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TargetType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Atlas.Domain.Forums.Forum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LastPostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PermissionSetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RepliesCount")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TopicsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LastPostId");

                    b.HasIndex("PermissionSetId");

                    b.ToTable("Forum");
                });

            modelBuilder.Entity("Atlas.Domain.PermissionSets.Permission", b =>
                {
                    b.Property<Guid>("PermissionSetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("PermissionSetId", "RoleId", "Type");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Atlas.Domain.PermissionSets.PermissionSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PermissionSet");
                });

            modelBuilder.Entity("Atlas.Domain.Posts.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ForumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HasAnswer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAnswer")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastReplyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Locked")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Pinned")
                        .HasColumnType("bit");

                    b.Property<int>("RepliesCount")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ForumId");

                    b.HasIndex("LastReplyId");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("TopicId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Atlas.Domain.Sites.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdminCss")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminTheme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeadScript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Privacy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicCss")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicTheme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Terms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("Atlas.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepliesCount")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("TopicsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Atlas.Domain.Categories.Category", b =>
                {
                    b.HasOne("Atlas.Domain.PermissionSets.PermissionSet", "PermissionSet")
                        .WithMany("Categories")
                        .HasForeignKey("PermissionSetId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Atlas.Domain.Sites.Site", "Site")
                        .WithMany("Categories")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Atlas.Domain.Event", b =>
                {
                    b.HasOne("Atlas.Domain.Users.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Atlas.Domain.Forums.Forum", b =>
                {
                    b.HasOne("Atlas.Domain.Categories.Category", "Category")
                        .WithMany("Forums")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Atlas.Domain.Posts.Post", "LastPost")
                        .WithMany()
                        .HasForeignKey("LastPostId");

                    b.HasOne("Atlas.Domain.PermissionSets.PermissionSet", "PermissionSet")
                        .WithMany("Forums")
                        .HasForeignKey("PermissionSetId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Atlas.Domain.PermissionSets.Permission", b =>
                {
                    b.HasOne("Atlas.Domain.PermissionSets.PermissionSet", "PermissionSet")
                        .WithMany("Permissions")
                        .HasForeignKey("PermissionSetId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Atlas.Domain.Posts.Post", b =>
                {
                    b.HasOne("Atlas.Domain.Users.User", "CreatedByUser")
                        .WithMany("Posts")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Atlas.Domain.Forums.Forum", "Forum")
                        .WithMany("Posts")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Atlas.Domain.Posts.Post", "LastReply")
                        .WithMany()
                        .HasForeignKey("LastReplyId");

                    b.HasOne("Atlas.Domain.Users.User", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedBy");

                    b.HasOne("Atlas.Domain.Posts.Post", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId");
                });
#pragma warning restore 612, 618
        }
    }
}
