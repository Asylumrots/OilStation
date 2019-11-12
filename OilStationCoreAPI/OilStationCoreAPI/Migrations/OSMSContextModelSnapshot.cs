﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OilStationCoreAPI.Models;

namespace OilStationCoreAPI.Migrations
{
    [DbContext(typeof(OSMSContext))]
    partial class OSMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OilStationCoreAPI.Model.Approver", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("AreaLeve");

                    b.Property<string>("Discrible")
                        .HasMaxLength(100);

                    b.Property<string>("ExecuteMethod")
                        .HasMaxLength(100);

                    b.Property<string>("JobCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("Order");

                    b.Property<Guid?>("ProcessItemId");

                    b.HasKey("Id");

                    b.ToTable("Approver");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetRoles", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetUsers", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("IsHsegroup")
                        .HasColumnName("IsHSEGroup");

                    b.Property<string>("JobId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("OrgId");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("UserSex");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.Entry", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<string>("BankCardNumber")
                        .HasMaxLength(200);

                    b.Property<string>("BirthCertificatePhoto")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("date");

                    b.Property<string>("CorrectSalary")
                        .HasMaxLength(50);

                    b.Property<Guid?>("CreateStaffeId");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("EducationalExperience1Certificate")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("EducationalExperience1EndDate")
                        .HasColumnType("date");

                    b.Property<string>("EducationalExperience1Major")
                        .HasMaxLength(500);

                    b.Property<string>("EducationalExperience1SchoolName")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("EducationalExperience1StartDate")
                        .HasColumnType("date");

                    b.Property<string>("EducationalExperience2Certificate")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("EducationalExperience2EndDate")
                        .HasColumnType("date");

                    b.Property<string>("EducationalExperience2Major")
                        .HasMaxLength(500);

                    b.Property<string>("EducationalExperience2SchoolName")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("EducationalExperience2StartDate")
                        .HasColumnType("date");

                    b.Property<string>("EducationalExperience3Certificate")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("EducationalExperience3EndDate")
                        .HasColumnType("date");

                    b.Property<string>("EducationalExperience3Major")
                        .HasMaxLength(500);

                    b.Property<string>("EducationalExperience3SchoolName")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("EducationalExperience3StartDate")
                        .HasColumnType("date");

                    b.Property<string>("EducationalExperience4Certificate")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("EducationalExperience4EndDate")
                        .HasColumnType("date");

                    b.Property<string>("EducationalExperience4Major")
                        .HasMaxLength(500);

                    b.Property<string>("EducationalExperience4SchoolName")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("EducationalExperience4StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(500);

                    b.Property<string>("EmergencyContactEelationShipWithMe")
                        .HasMaxLength(500);

                    b.Property<string>("EmergencyContactName")
                        .HasMaxLength(500);

                    b.Property<string>("EmergencyContactTel")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<DateTime?>("EntryDate")
                        .HasColumnType("date");

                    b.Property<string>("FamilyStatus1Appellation")
                        .HasMaxLength(500);

                    b.Property<string>("FamilyStatus1Company")
                        .HasMaxLength(500);

                    b.Property<string>("FamilyStatus1Name")
                        .HasMaxLength(500);

                    b.Property<string>("FamilyStatus1Tel")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("FamilyStatus2Appellation")
                        .HasMaxLength(500);

                    b.Property<string>("FamilyStatus2Company")
                        .HasMaxLength(500);

                    b.Property<string>("FamilyStatus2Name")
                        .HasMaxLength(500);

                    b.Property<string>("FamilyStatus2Tel")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("ForeginLanguageAptitude")
                        .HasMaxLength(500);

                    b.Property<bool?>("HaseMedicalHistory");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int?>("HighestEducation");

                    b.Property<string>("HobbiesAndSpeciality")
                        .HasMaxLength(500);

                    b.Property<string>("Idnumber")
                        .HasColumnName("IDNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<bool>("IsDel");

                    b.Property<Guid?>("JobId");

                    b.Property<string>("Major")
                        .HasMaxLength(500);

                    b.Property<bool?>("MaritalStatus");

                    b.Property<string>("MedicalHistoryComment")
                        .HasMaxLength(500);

                    b.Property<string>("NativePlace")
                        .HasMaxLength(500);

                    b.Property<string>("No")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnName("Organization_Id");

                    b.Property<string>("ProbationarySalary")
                        .HasMaxLength(50);

                    b.Property<string>("RegistrationPhoto")
                        .HasMaxLength(200);

                    b.Property<bool>("Sex");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("StaffNo")
                        .HasMaxLength(100);

                    b.Property<string>("SupervisorComments")
                        .HasMaxLength(500);

                    b.Property<string>("Tel")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("WorkExperience1CompanyName")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("WorkExperience1EndDate")
                        .HasColumnType("date");

                    b.Property<string>("WorkExperience1Job")
                        .HasMaxLength(500);

                    b.Property<string>("WorkExperience1LeavingReasons")
                        .HasMaxLength(100);

                    b.Property<string>("WorkExperience1Pay")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("WorkExperience1StartDate")
                        .HasColumnType("date");

                    b.Property<string>("WorkExperience2CompanyName")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("WorkExperience2EndDate")
                        .HasColumnType("date");

                    b.Property<string>("WorkExperience2Job")
                        .HasMaxLength(500);

                    b.Property<string>("WorkExperience2LeavingReasons")
                        .HasMaxLength(100);

                    b.Property<string>("WorkExperience2Pay")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("WorkExperience2StartDate")
                        .HasColumnType("date");

                    b.Property<string>("WorkExperience3CompanyName")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("WorkExperience3EndDate")
                        .HasColumnType("date");

                    b.Property<string>("WorkExperience3Job")
                        .HasMaxLength(500);

                    b.Property<string>("WorkExperience3LeavingReasons")
                        .HasMaxLength(100);

                    b.Property<string>("WorkExperience3Pay")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("WorkExperience3StartDate")
                        .HasColumnType("date");

                    b.Property<string>("WorkExperience4CompanyName")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("WorkExperience4EndDate")
                        .HasColumnType("date");

                    b.Property<string>("WorkExperience4Job")
                        .HasMaxLength(500);

                    b.Property<string>("WorkExperience4LeavingReasons")
                        .HasMaxLength(100);

                    b.Property<string>("WorkExperience4Pay")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("WorkExperience4StartDate")
                        .HasColumnType("date");

                    b.Property<string>("WorkNumber")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Entry");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.Job", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Code")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsDel");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.LeaveOffice", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime?>("ApplyDate")
                        .HasColumnType("date");

                    b.Property<Guid?>("ApplyPersonId");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("ExplanationHandover")
                        .HasMaxLength(500);

                    b.Property<Guid?>("HandoverSatffId");

                    b.Property<bool?>("IsDel");

                    b.Property<Guid>("JobId");

                    b.Property<string>("LeaveType")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("No")
                        .HasMaxLength(100);

                    b.Property<string>("Reason")
                        .HasMaxLength(500);

                    b.Property<string>("StaffName")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("LeaveOffice");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.OilMaterialOrder", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime?>("ApplyDate")
                        .HasColumnType("date");

                    b.Property<Guid>("ApplyPersonId");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDel");

                    b.Property<string>("No")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Remark")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("OilMaterialOrder");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.OilMaterialOrderDetail", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("DayAvg")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool?>("IsDel");

                    b.Property<decimal?>("NeedAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("OilSpec")
                        .HasMaxLength(100);

                    b.Property<Guid>("OrderId");

                    b.Property<decimal?>("Surplus")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("Volume")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("OilMaterialOrderDetail");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.OrganizationStructure", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDel");

                    b.Property<int>("Leve");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid?>("ParentId");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("OrganizationStructure");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.ProcessItem", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Discrible")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ProcessItem");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.ProcessStepRecord", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Discrible")
                        .HasMaxLength(400);

                    b.Property<string>("ExecuteMethod")
                        .HasMaxLength(4000);

                    b.Property<string>("No")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("RecordRemarks")
                        .HasMaxLength(500);

                    b.Property<Guid>("RefOrderId");

                    b.Property<bool>("Result");

                    b.Property<int>("StepOrder");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("WaitForExecutionStaffId");

                    b.Property<bool>("WhetherToExecute");

                    b.HasKey("Id");

                    b.ToTable("ProcessStepRecord");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.Role", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.RoleResourceModule", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("ResourceModuleId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleResourceModule");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.Staff", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("date");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<bool?>("IsHsegroup")
                        .HasColumnName("IsHSEGroup");

                    b.Property<Guid?>("JobId");

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.Property<string>("NativePlace")
                        .HasMaxLength(500);

                    b.Property<string>("No")
                        .HasMaxLength(500);

                    b.Property<Guid?>("OrgId")
                        .HasColumnName("OrgID");

                    b.Property<string>("Password")
                        .HasMaxLength(1000);

                    b.Property<bool?>("Sex");

                    b.Property<string>("Status")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Tel")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.StaffRole", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("StaffId");

                    b.HasKey("Id");

                    b.ToTable("StaffRole");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.SystemResourceModule", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.Property<int?>("OrderNo");

                    b.Property<Guid?>("ParentId");

                    b.Property<int>("Type");

                    b.Property<string>("Url")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.ToTable("SystemResourceModule");
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetRoleClaims", b =>
                {
                    b.HasOne("OilStationCoreAPI.Model.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetUserClaims", b =>
                {
                    b.HasOne("OilStationCoreAPI.Model.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetUserLogins", b =>
                {
                    b.HasOne("OilStationCoreAPI.Model.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetUserRoles", b =>
                {
                    b.HasOne("OilStationCoreAPI.Model.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OilStationCoreAPI.Model.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OilStationCoreAPI.Model.AspNetUserTokens", b =>
                {
                    b.HasOne("OilStationCoreAPI.Model.AspNetUsers", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}