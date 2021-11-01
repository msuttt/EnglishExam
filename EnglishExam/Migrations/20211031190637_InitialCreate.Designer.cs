﻿// <auto-generated />
using System;
using EnglishExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EnglishExam.Migrations
{
    [DbContext(typeof(ContextDatabase))]
    [Migration("20211031190637_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("EnglishExam.Models.Entities.Authority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthorityName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authority");
                });

            modelBuilder.Entity("EnglishExam.Models.Entities.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("EnglishExam.Models.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("A")
                        .HasColumnType("TEXT");

                    b.Property<string>("B")
                        .HasColumnType("TEXT");

                    b.Property<string>("C")
                        .HasColumnType("TEXT");

                    b.Property<string>("D")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderNo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionContent")
                        .HasColumnType("TEXT");

                    b.Property<char>("TrueAnswer")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("EnglishExam.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorityId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EnglishExam.Models.Entities.Question", b =>
                {
                    b.HasOne("EnglishExam.Models.Entities.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("EnglishExam.Models.Entities.User", b =>
                {
                    b.HasOne("EnglishExam.Models.Entities.Authority", "Authority")
                        .WithMany()
                        .HasForeignKey("AuthorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authority");
                });

            modelBuilder.Entity("EnglishExam.Models.Entities.Exam", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}