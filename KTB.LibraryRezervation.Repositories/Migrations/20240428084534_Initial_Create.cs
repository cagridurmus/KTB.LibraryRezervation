using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KTB.LibraryRezervation.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryHalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeskCapacity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryHalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    OpeningTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Desks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryHallId = table.Column<int>(type: "int", nullable: false),
                    DeskNo = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desks_LibraryHalls_LibraryHallId",
                        column: x => x.LibraryHallId,
                        principalTable: "LibraryHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeskId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Desks_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LibraryHalls",
                columns: new[] { "Id", "CreatedAt", "DeskCapacity", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7310), 8, "Salon 1", null },
                    { 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7310), 5, "Salon 2", null }
                });

            migrationBuilder.InsertData(
                table: "Desks",
                columns: new[] { "Id", "Capacity", "CreatedAt", "DeskNo", "LibraryHallId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6680), 1, 1, null },
                    { 2, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6710), 2, 1, null },
                    { 3, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6720), 3, 1, null },
                    { 4, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6720), 4, 1, null },
                    { 5, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6720), 5, 1, null },
                    { 6, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6720), 6, 1, null },
                    { 7, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6720), 7, 1, null },
                    { 8, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6720), 8, 1, null },
                    { 9, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6730), 1, 2, null },
                    { 10, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6730), 2, 2, null },
                    { 11, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6730), 3, 2, null },
                    { 12, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6730), 4, 2, null },
                    { 13, 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(6730), 5, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seat",
                columns: new[] { "Id", "CreatedAt", "DeskId", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7760), 1, "1A", null },
                    { 2, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7760), 1, "1B", null },
                    { 3, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7760), 2, "2A", null },
                    { 4, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7760), 2, "2B", null },
                    { 5, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7760), 3, "3A", null },
                    { 6, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7770), 3, "3B", null },
                    { 7, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7770), 4, "4A", null },
                    { 8, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7770), 4, "4B", null },
                    { 9, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7770), 5, "5A", null },
                    { 10, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7770), 5, "5B", null },
                    { 11, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7770), 6, "6A", null },
                    { 12, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7780), 6, "6B", null },
                    { 13, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7780), 7, "7A", null },
                    { 14, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7780), 7, "7B", null },
                    { 15, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7780), 8, "8A", null },
                    { 16, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7780), 8, "8B", null },
                    { 17, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7780), 9, "1A", null },
                    { 18, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7790), 9, "1B", null },
                    { 19, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7790), 10, "2A", null },
                    { 20, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7790), 10, "2B", null },
                    { 21, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7790), 11, "3A", null },
                    { 22, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7790), 11, "3B", null },
                    { 23, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7790), 12, "4A", null },
                    { 24, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7790), 12, "4B", null },
                    { 25, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7800), 13, "5A", null },
                    { 26, new DateTime(2024, 4, 28, 11, 45, 33, 979, DateTimeKind.Local).AddTicks(7800), 13, "5B", null }
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

            migrationBuilder.CreateIndex(
                name: "IX_Desks_LibraryHallId",
                table: "Desks",
                column: "LibraryHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SeatId",
                table: "Reservations",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_DeskId",
                table: "Seat",
                column: "DeskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "WorkingHours");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Desks");

            migrationBuilder.DropTable(
                name: "LibraryHalls");
        }
    }
}
