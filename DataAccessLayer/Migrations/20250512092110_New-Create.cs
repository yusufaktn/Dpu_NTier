using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class NewCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ad = table.Column<string>(type: "varchar(50)", nullable: false),
                    Soyad = table.Column<string>(type: "varchar(50)", nullable: false),
                    Eposta = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefon = table.Column<string>(type: "varchar(14)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universiteler",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniversiteAd = table.Column<string>(type: "varchar(80)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universiteler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fakulte",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FakülteAd = table.Column<string>(type: "varchar(100)", nullable: false),
                    UniversiteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakulte", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fakulte_Universiteler_UniversiteID",
                        column: x => x.UniversiteID,
                        principalTable: "Universiteler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_KullaniciRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bolumler",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BolumAd = table.Column<string>(type: "varchar(100)", nullable: false),
                    FakulteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolumler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bolumler_Fakulte_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakulte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dersler",
                columns: table => new
                {
                    DersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DersAd = table.Column<string>(type: "varchar(100)", nullable: false),
                    Donem = table.Column<string>(type: "varchar(50)", nullable: false),
                    BolumID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dersler", x => x.DersID);
                    table.ForeignKey(
                        name: "FK_Dersler_Bolumler_BolumID",
                        column: x => x.BolumID,
                        principalTable: "Bolumler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DersNotu",
                columns: table => new
                {
                    DersNotuID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OgretmenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotBaslıgı = table.Column<string>(type: "varchar(100)", nullable: false),
                    DosyaYolu = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    YuklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersNotu", x => x.DersNotuID);
                    table.ForeignKey(
                        name: "FK_DersNotu_Dersler_DersID",
                        column: x => x.DersID,
                        principalTable: "Dersler",
                        principalColumn: "DersID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersNotu_Ogretmenler_OgretmenID",
                        column: x => x.OgretmenID,
                        principalTable: "Ogretmenler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgretmenDersler",
                columns: table => new
                {
                    OgretmenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonemYil = table.Column<string>(type: "varchar(50)", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgretmenDersler", x => new { x.OgretmenID, x.DersID });
                    table.ForeignKey(
                        name: "FK_OgretmenDersler_Dersler_DersID",
                        column: x => x.DersID,
                        principalTable: "Dersler",
                        principalColumn: "DersID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgretmenDersler_Ogretmenler_OgretmenID",
                        column: x => x.OgretmenID,
                        principalTable: "Ogretmenler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bolumler_FakulteID",
                table: "Bolumler",
                column: "FakulteID");

            migrationBuilder.CreateIndex(
                name: "IX_Dersler_BolumID",
                table: "Dersler",
                column: "BolumID");

            migrationBuilder.CreateIndex(
                name: "IX_DersNotu_DersID",
                table: "DersNotu",
                column: "DersID");

            migrationBuilder.CreateIndex(
                name: "IX_DersNotu_OgretmenID",
                table: "DersNotu",
                column: "OgretmenID");

            migrationBuilder.CreateIndex(
                name: "IX_Fakulte_UniversiteID",
                table: "Fakulte",
                column: "UniversiteID");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRole_UserId",
                table: "KullaniciRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OgretmenDersler_DersID",
                table: "OgretmenDersler",
                column: "DersID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DersNotu");

            migrationBuilder.DropTable(
                name: "KullaniciRole");

            migrationBuilder.DropTable(
                name: "OgretmenDersler");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Dersler");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropTable(
                name: "Bolumler");

            migrationBuilder.DropTable(
                name: "Fakulte");

            migrationBuilder.DropTable(
                name: "Universiteler");
        }
    }
}
