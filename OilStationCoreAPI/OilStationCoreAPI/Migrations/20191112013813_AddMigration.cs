using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OilStationCoreAPI.Migrations
{
    public partial class AddMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //注释掉不需要新增的表 ，防止覆盖

            //migrationBuilder.CreateTable(
            //    name: "Approver",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        JobCode = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
            //        AreaLeve = table.Column<int>(nullable: false),
            //        Discrible = table.Column<string>(maxLength: 100, nullable: true),
            //        Order = table.Column<int>(nullable: false),
            //        ProcessItemId = table.Column<Guid>(nullable: true),
            //        ExecuteMethod = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Approver", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserSex = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    JobId = table.Column<string>(nullable: true),
                    OrgId = table.Column<string>(nullable: true),
                    IsHSEGroup = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Entry",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        StaffName = table.Column<string>(maxLength: 500, nullable: false),
            //        Sex = table.Column<bool>(nullable: false),
            //        BirthDay = table.Column<DateTime>(type: "date", nullable: true),
            //        MaritalStatus = table.Column<bool>(nullable: true),
            //        Height = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
            //        HighestEducation = table.Column<int>(nullable: true),
            //        Major = table.Column<string>(maxLength: 500, nullable: true),
            //        ForeginLanguageAptitude = table.Column<string>(maxLength: 500, nullable: true),
            //        IDNumber = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        NativePlace = table.Column<string>(maxLength: 500, nullable: true),
            //        Address = table.Column<string>(maxLength: 500, nullable: true),
            //        Email = table.Column<string>(maxLength: 500, nullable: true),
            //        Tel = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        HaseMedicalHistory = table.Column<bool>(nullable: true),
            //        MedicalHistoryComment = table.Column<string>(maxLength: 500, nullable: true),
            //        HobbiesAndSpeciality = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience1StartDate = table.Column<DateTime>(type: "date", nullable: true),
            //        EducationalExperience1EndDate = table.Column<DateTime>(type: "date", nullable: true),
            //        EducationalExperience1SchoolName = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience1Major = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience1Certificate = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience2StartDate = table.Column<DateTime>(type: "date", nullable: true),
            //        EducationalExperience2EndDate = table.Column<DateTime>(type: "date", nullable: true),
            //        EducationalExperience2SchoolName = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience2Major = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience2Certificate = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience3StartDate = table.Column<DateTime>(type: "date", nullable: true),
            //        EducationalExperience3EndDate = table.Column<DateTime>(type: "date", nullable: true),
            //        EducationalExperience3SchoolName = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience3Major = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience3Certificate = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience4StartDate = table.Column<DateTime>(type: "date", nullable: true),
            //        EducationalExperience4EndDate = table.Column<DateTime>(type: "date", nullable: true),
            //        EducationalExperience4SchoolName = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience4Major = table.Column<string>(maxLength: 500, nullable: true),
            //        EducationalExperience4Certificate = table.Column<string>(maxLength: 500, nullable: true),
            //        FamilyStatus1Name = table.Column<string>(maxLength: 500, nullable: true),
            //        FamilyStatus1Appellation = table.Column<string>(maxLength: 500, nullable: true),
            //        FamilyStatus1Company = table.Column<string>(maxLength: 500, nullable: true),
            //        FamilyStatus1Tel = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        FamilyStatus2Name = table.Column<string>(maxLength: 500, nullable: true),
            //        FamilyStatus2Appellation = table.Column<string>(maxLength: 500, nullable: true),
            //        FamilyStatus2Company = table.Column<string>(maxLength: 500, nullable: true),
            //        FamilyStatus2Tel = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        EmergencyContactName = table.Column<string>(maxLength: 500, nullable: true),
            //        EmergencyContactTel = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        EmergencyContactEelationShipWithMe = table.Column<string>(maxLength: 500, nullable: true),
            //        WorkExperience1CompanyName = table.Column<string>(maxLength: 500, nullable: true),
            //        WorkExperience1Job = table.Column<string>(maxLength: 500, nullable: true),
            //        WorkExperience1StartDate = table.Column<DateTime>(type: "date", nullable: true),
            //        WorkExperience1EndDate = table.Column<DateTime>(type: "date", nullable: true),
            //        WorkExperience1Pay = table.Column<string>(maxLength: 50, nullable: true),
            //        WorkExperience1LeavingReasons = table.Column<string>(maxLength: 100, nullable: true),
            //        WorkExperience2CompanyName = table.Column<string>(maxLength: 500, nullable: true),
            //        WorkExperience2Job = table.Column<string>(maxLength: 500, nullable: true),
            //        WorkExperience2StartDate = table.Column<DateTime>(type: "date", nullable: true),
            //        WorkExperience2EndDate = table.Column<DateTime>(type: "date", nullable: true),
            //        WorkExperience2Pay = table.Column<string>(maxLength: 50, nullable: true),
            //        WorkExperience2LeavingReasons = table.Column<string>(maxLength: 100, nullable: true),
            //        WorkExperience3CompanyName = table.Column<string>(maxLength: 500, nullable: true),
            //        WorkExperience3Job = table.Column<string>(maxLength: 500, nullable: true),
            //        WorkExperience3StartDate = table.Column<DateTime>(type: "date", nullable: true),
            //        WorkExperience3EndDate = table.Column<DateTime>(type: "date", nullable: true),
            //        WorkExperience3Pay = table.Column<string>(maxLength: 50, nullable: true),
            //        WorkExperience3LeavingReasons = table.Column<string>(maxLength: 100, nullable: true),
            //        WorkExperience4CompanyName = table.Column<string>(maxLength: 500, nullable: true),
            //        WorkExperience4Job = table.Column<string>(maxLength: 500, nullable: true),
            //        WorkExperience4StartDate = table.Column<DateTime>(type: "date", nullable: true),
            //        WorkExperience4EndDate = table.Column<DateTime>(type: "date", nullable: true),
            //        WorkExperience4Pay = table.Column<string>(maxLength: 50, nullable: true),
            //        WorkExperience4LeavingReasons = table.Column<string>(maxLength: 100, nullable: true),
            //        JobId = table.Column<Guid>(nullable: true),
            //        Title = table.Column<string>(maxLength: 50, nullable: true),
            //        Organization_Id = table.Column<Guid>(nullable: true),
            //        SupervisorComments = table.Column<string>(maxLength: 500, nullable: true),
            //        ProbationarySalary = table.Column<string>(maxLength: 50, nullable: true),
            //        CorrectSalary = table.Column<string>(maxLength: 50, nullable: true),
            //        WorkNumber = table.Column<string>(maxLength: 50, nullable: true),
            //        EntryDate = table.Column<DateTime>(type: "date", nullable: true),
            //        BirthCertificatePhoto = table.Column<string>(maxLength: 200, nullable: true),
            //        RegistrationPhoto = table.Column<string>(maxLength: 200, nullable: true),
            //        BankCardNumber = table.Column<string>(maxLength: 200, nullable: true),
            //        CreateStaffeId = table.Column<Guid>(nullable: true),
            //        CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        No = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        StaffNo = table.Column<string>(maxLength: 100, nullable: true),
            //        IsDel = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Entry", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Job",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Name = table.Column<string>(maxLength: 100, nullable: true),
            //        Code = table.Column<string>(maxLength: 100, nullable: true),
            //        UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        IsDel = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Job", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LeaveOffice",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        No = table.Column<string>(maxLength: 100, nullable: true),
            //        StaffName = table.Column<string>(maxLength: 100, nullable: true),
            //        JobId = table.Column<Guid>(nullable: false),
            //        LeaveType = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
            //        ApplyDate = table.Column<DateTime>(type: "date", nullable: true),
            //        Reason = table.Column<string>(maxLength: 500, nullable: true),
            //        ExplanationHandover = table.Column<string>(maxLength: 500, nullable: true),
            //        HandoverSatffId = table.Column<Guid>(nullable: true),
            //        ApplyPersonId = table.Column<Guid>(nullable: true),
            //        CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        IsDel = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LeaveOffice", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OilMaterialOrder",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        No = table.Column<string>(maxLength: 100, nullable: false),
            //        ApplyPersonId = table.Column<Guid>(nullable: false),
            //        ApplyDate = table.Column<DateTime>(type: "date", nullable: true),
            //        Remark = table.Column<string>(maxLength: 500, nullable: true),
            //        IsDel = table.Column<bool>(nullable: false),
            //        CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OilMaterialOrder", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OilMaterialOrderDetail",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        OrderId = table.Column<Guid>(nullable: false),
            //        OilSpec = table.Column<string>(maxLength: 100, nullable: true),
            //        Volume = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        Surplus = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        DayAvg = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        NeedAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        IsDel = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OilMaterialOrderDetail", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrganizationStructure",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Code = table.Column<string>(maxLength: 100, nullable: false),
            //        Name = table.Column<string>(maxLength: 100, nullable: false),
            //        Leve = table.Column<int>(nullable: false),
            //        ParentId = table.Column<Guid>(nullable: true),
            //        CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        IsDel = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrganizationStructure", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProcessItem",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Code = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
            //        Discrible = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProcessItem", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProcessStepRecord",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Type = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
            //        RecordRemarks = table.Column<string>(maxLength: 500, nullable: true),
            //        StepOrder = table.Column<int>(nullable: false),
            //        WaitForExecutionStaffId = table.Column<Guid>(nullable: false),
            //        CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        WhetherToExecute = table.Column<bool>(nullable: false),
            //        No = table.Column<string>(maxLength: 50, nullable: false),
            //        RefOrderId = table.Column<Guid>(nullable: false),
            //        Result = table.Column<bool>(nullable: false),
            //        ExecuteMethod = table.Column<string>(maxLength: 4000, nullable: true),
            //        Discrible = table.Column<string>(maxLength: 400, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProcessStepRecord", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Role",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Name = table.Column<string>(maxLength: 500, nullable: false),
            //        Code = table.Column<string>(maxLength: 500, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Role", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoleResourceModule",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        RoleId = table.Column<Guid>(nullable: false),
            //        ResourceModuleId = table.Column<Guid>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoleResourceModule", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Staff",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        No = table.Column<string>(maxLength: 500, nullable: true),
            //        Name = table.Column<string>(maxLength: 500, nullable: true),
            //        Sex = table.Column<bool>(nullable: true),
            //        BirthDay = table.Column<DateTime>(type: "date", nullable: true),
            //        NativePlace = table.Column<string>(maxLength: 500, nullable: true),
            //        Address = table.Column<string>(maxLength: 500, nullable: true),
            //        Password = table.Column<string>(maxLength: 1000, nullable: true),
            //        Email = table.Column<string>(maxLength: 50, nullable: true),
            //        Tel = table.Column<string>(maxLength: 20, nullable: true),
            //        Status = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
            //        CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        JobId = table.Column<Guid>(nullable: true),
            //        OrgID = table.Column<Guid>(nullable: true),
            //        IsHSEGroup = table.Column<bool>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Staff", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StaffRole",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        StaffId = table.Column<Guid>(nullable: false),
            //        RoleId = table.Column<Guid>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StaffRole", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SystemResourceModule",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Name = table.Column<string>(maxLength: 500, nullable: true),
            //        Code = table.Column<string>(maxLength: 500, nullable: false),
            //        Url = table.Column<string>(maxLength: 1000, nullable: true),
            //        Type = table.Column<int>(nullable: false),
            //        ParentId = table.Column<Guid>(nullable: true),
            //        OrderNo = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SystemResourceModule", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approver");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "LeaveOffice");

            migrationBuilder.DropTable(
                name: "OilMaterialOrder");

            migrationBuilder.DropTable(
                name: "OilMaterialOrderDetail");

            migrationBuilder.DropTable(
                name: "OrganizationStructure");

            migrationBuilder.DropTable(
                name: "ProcessItem");

            migrationBuilder.DropTable(
                name: "ProcessStepRecord");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RoleResourceModule");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "StaffRole");

            migrationBuilder.DropTable(
                name: "SystemResourceModule");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
