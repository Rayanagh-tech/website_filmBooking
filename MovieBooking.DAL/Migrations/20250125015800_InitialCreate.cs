using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieBooking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoviePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Showtimes",
                columns: table => new
                {
                    ShowtimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ScreenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showtimes", x => x.ShowtimeId);
                    table.ForeignKey(
                        name: "FK_Showtimes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    SeatIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShowtimeId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Showtimes_ShowtimeId",
                        column: x => x.ShowtimeId,
                        principalTable: "Showtimes",
                        principalColumn: "ShowtimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    ShowtimeId = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Showtimes_ShowtimeId",
                        column: x => x.ShowtimeId,
                        principalTable: "Showtimes",
                        principalColumn: "ShowtimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "b6bd5d60-ccac-4a20-b2ff-c0decb960409", null, false, "John", "Doe", false, null, null, null, null, null, false, new byte[0], "ca040cca-1a10-4cb1-9d6b-05a95def50df", false, null },
                    { "2", 0, "f0efe2d7-efe9-42e0-a73b-cb02eb1e91a0", null, false, "Jane", "Doe", false, null, null, null, null, null, false, new byte[0], "c397dba5-aa2e-42f4-8796-1c0a6d9e1e84", false, null },
                    { "3", 0, "edb240ff-41a8-4efb-8618-22fa42683f81", "alice.smith@example.com", false, "Alice", "Smith", false, null, null, null, null, null, false, new byte[0], "9d39bfc3-d8b8-48bf-9a3f-ae2d48676fbd", false, "alicesmith" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Description", "Duration", "Genre", "MoviePicture", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 10, "A thief who steals corporate secrets through dream-sharing.", 148, "Sci-Fi", new byte[0], new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 20, "Batman battles the Joker in Gotham City.", 152, "Action", new byte[0], new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { 30, "A team of explorers travel through a wormhole in space to ensure humanity's survival.", 169, "Sci-Fi", new byte[0], new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar" },
                    { 40, "The Avengers assemble to reverse the damage caused by Thanos.", 181, "Action", new byte[0], new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "pulp-fiction" }
                });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "ShowtimeId", "AvailableSeats", "MovieId", "ScreenId", "StartTime" },
                values: new object[,]
                {
                    { 1, 10, 10, 1, new DateTime(2024, 12, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 15, 20, 1, new DateTime(2024, 12, 11, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 20, 30, 2, new DateTime(2024, 12, 12, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 25, 40, 3, new DateTime(2024, 12, 13, 19, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "ApplicationUserId", "BookingDate", "MovieId", "NumberOfSeats", "PaymentStatus", "SeatIds", "ShowtimeId" },
                values: new object[,]
                {
                    { 10, "1", new DateTime(2025, 1, 25, 2, 57, 59, 489, DateTimeKind.Local).AddTicks(9822), 10, 2, "Paid", "1,2", 1 },
                    { 20, "2", new DateTime(2025, 1, 25, 2, 57, 59, 491, DateTimeKind.Local).AddTicks(9864), 20, 1, "Pending", "3", 2 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "SeatId", "Column", "IsBooked", "MovieId", "Row", "SeatNumber", "ShowtimeId" },
                values: new object[,]
                {
                    { 100, "1", false, 0, "A", 0, 1 },
                    { 101, "2", false, 0, "A", 0, 1 },
                    { 102, "3", false, 0, "A", 0, 1 },
                    { 103, "4", false, 0, "A", 0, 1 },
                    { 104, "5", false, 0, "A", 0, 1 },
                    { 110, "1", false, 0, "B", 0, 1 },
                    { 111, "2", false, 0, "B", 0, 1 },
                    { 112, "3", false, 0, "B", 0, 1 },
                    { 113, "4", false, 0, "B", 0, 1 },
                    { 114, "5", false, 0, "B", 0, 1 },
                    { 120, "1", false, 0, "C", 0, 1 },
                    { 121, "2", false, 0, "C", 0, 1 },
                    { 122, "3", false, 0, "C", 0, 1 },
                    { 123, "4", false, 0, "C", 0, 1 },
                    { 124, "5", false, 0, "C", 0, 1 },
                    { 130, "1", false, 0, "D", 0, 1 },
                    { 131, "2", false, 0, "D", 0, 1 },
                    { 132, "3", false, 0, "D", 0, 1 },
                    { 133, "4", false, 0, "D", 0, 1 },
                    { 134, "5", false, 0, "D", 0, 1 },
                    { 140, "1", false, 0, "E", 0, 1 },
                    { 141, "2", false, 0, "E", 0, 1 },
                    { 142, "3", false, 0, "E", 0, 1 },
                    { 143, "4", false, 0, "E", 0, 1 },
                    { 144, "5", false, 0, "E", 0, 1 },
                    { 200, "1", false, 0, "A", 0, 2 },
                    { 201, "2", false, 0, "A", 0, 2 },
                    { 202, "3", false, 0, "A", 0, 2 },
                    { 203, "4", false, 0, "A", 0, 2 },
                    { 204, "5", false, 0, "A", 0, 2 },
                    { 210, "1", false, 0, "B", 0, 2 },
                    { 211, "2", false, 0, "B", 0, 2 },
                    { 212, "3", false, 0, "B", 0, 2 },
                    { 213, "4", false, 0, "B", 0, 2 },
                    { 214, "5", false, 0, "B", 0, 2 },
                    { 220, "1", false, 0, "C", 0, 2 },
                    { 221, "2", false, 0, "C", 0, 2 },
                    { 222, "3", false, 0, "C", 0, 2 },
                    { 223, "4", false, 0, "C", 0, 2 },
                    { 224, "5", false, 0, "C", 0, 2 },
                    { 230, "1", false, 0, "D", 0, 2 },
                    { 231, "2", false, 0, "D", 0, 2 },
                    { 232, "3", false, 0, "D", 0, 2 },
                    { 233, "4", false, 0, "D", 0, 2 },
                    { 234, "5", false, 0, "D", 0, 2 },
                    { 240, "1", false, 0, "E", 0, 2 },
                    { 241, "2", false, 0, "E", 0, 2 },
                    { 242, "3", false, 0, "E", 0, 2 },
                    { 243, "4", false, 0, "E", 0, 2 },
                    { 244, "5", false, 0, "E", 0, 2 },
                    { 300, "1", false, 0, "A", 0, 3 },
                    { 301, "2", false, 0, "A", 0, 3 },
                    { 302, "3", false, 0, "A", 0, 3 },
                    { 303, "4", false, 0, "A", 0, 3 },
                    { 304, "5", false, 0, "A", 0, 3 },
                    { 310, "1", false, 0, "B", 0, 3 },
                    { 311, "2", false, 0, "B", 0, 3 },
                    { 312, "3", false, 0, "B", 0, 3 },
                    { 313, "4", false, 0, "B", 0, 3 },
                    { 314, "5", false, 0, "B", 0, 3 },
                    { 320, "1", false, 0, "C", 0, 3 },
                    { 321, "2", false, 0, "C", 0, 3 },
                    { 322, "3", false, 0, "C", 0, 3 },
                    { 323, "4", false, 0, "C", 0, 3 },
                    { 324, "5", false, 0, "C", 0, 3 },
                    { 330, "1", false, 0, "D", 0, 3 },
                    { 331, "2", false, 0, "D", 0, 3 },
                    { 332, "3", false, 0, "D", 0, 3 },
                    { 333, "4", false, 0, "D", 0, 3 },
                    { 334, "5", false, 0, "D", 0, 3 },
                    { 340, "1", false, 0, "E", 0, 3 },
                    { 341, "2", false, 0, "E", 0, 3 },
                    { 342, "3", false, 0, "E", 0, 3 },
                    { 343, "4", false, 0, "E", 0, 3 },
                    { 344, "5", false, 0, "E", 0, 3 },
                    { 400, "1", false, 0, "A", 0, 4 },
                    { 401, "2", false, 0, "A", 0, 4 },
                    { 402, "3", false, 0, "A", 0, 4 },
                    { 403, "4", false, 0, "A", 0, 4 },
                    { 404, "5", false, 0, "A", 0, 4 },
                    { 410, "1", false, 0, "B", 0, 4 },
                    { 411, "2", false, 0, "B", 0, 4 },
                    { 412, "3", false, 0, "B", 0, 4 },
                    { 413, "4", false, 0, "B", 0, 4 },
                    { 414, "5", false, 0, "B", 0, 4 },
                    { 420, "1", false, 0, "C", 0, 4 },
                    { 421, "2", false, 0, "C", 0, 4 },
                    { 422, "3", false, 0, "C", 0, 4 },
                    { 423, "4", false, 0, "C", 0, 4 },
                    { 424, "5", false, 0, "C", 0, 4 },
                    { 430, "1", false, 0, "D", 0, 4 },
                    { 431, "2", false, 0, "D", 0, 4 },
                    { 432, "3", false, 0, "D", 0, 4 },
                    { 433, "4", false, 0, "D", 0, 4 },
                    { 434, "5", false, 0, "D", 0, 4 },
                    { 440, "1", false, 0, "E", 0, 4 },
                    { 441, "2", false, 0, "E", 0, 4 },
                    { 442, "3", false, 0, "E", 0, 4 },
                    { 443, "4", false, 0, "E", 0, 4 },
                    { 444, "5", false, 0, "E", 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BookingId", "PaymentDate", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, 20.00m, 10, new DateTime(2025, 1, 25, 2, 57, 59, 492, DateTimeKind.Local).AddTicks(1260), "Credit Card" },
                    { 2, 15.00m, 20, new DateTime(2025, 1, 25, 2, 57, 59, 492, DateTimeKind.Local).AddTicks(1737), "PayPal" }
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
                name: "IX_Bookings_ApplicationUserId",
                table: "Bookings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MovieId",
                table: "Bookings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShowtimeId",
                table: "Bookings",
                column: "ShowtimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ShowtimeId",
                table: "Seats",
                column: "ShowtimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_MovieId",
                table: "Showtimes",
                column: "MovieId");
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
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Showtimes");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
