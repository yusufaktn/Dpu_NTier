using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class New_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRole_Roles_RoleId",
                table: "KullaniciRole");

            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRole_Users_UserId",
                table: "KullaniciRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Kullanici");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.AddColumn<Guid>(
                name: "BolumID",
                table: "Kullanici",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kullanici",
                table: "Kullanici",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Odalar",
                columns: table => new
                {
                    OdaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdaAdı = table.Column<string>(type: "varchar(80)", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(150)", nullable: false),
                    BolumID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odalar", x => x.OdaID);
                    table.ForeignKey(
                        name: "FK_Odalar_Bolumler_BolumID",
                        column: x => x.BolumID,
                        principalTable: "Bolumler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Odalar_Kullanici_UserID",
                        column: x => x.UserID,
                        principalTable: "Kullanici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OdaMesajları",
                columns: table => new
                {
                    OdaMesajID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mesaj = table.Column<string>(type: "varchar(500)", nullable: false),
                    MesajTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DosyaYolu = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    OdaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdaMesajları", x => x.OdaMesajID);
                    table.ForeignKey(
                        name: "FK_OdaMesajları_Kullanici_UserID",
                        column: x => x.UserID,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdaMesajları_Odalar_OdaID",
                        column: x => x.OdaID,
                        principalTable: "Odalar",
                        principalColumn: "OdaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_BolumID",
                table: "Kullanici",
                column: "BolumID");

            migrationBuilder.CreateIndex(
                name: "IX_Odalar_BolumID",
                table: "Odalar",
                column: "BolumID");

            migrationBuilder.CreateIndex(
                name: "IX_Odalar_UserID",
                table: "Odalar",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OdaMesajları_OdaID",
                table: "OdaMesajları",
                column: "OdaID");

            migrationBuilder.CreateIndex(
                name: "IX_OdaMesajları_UserID",
                table: "OdaMesajları",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanici_Bolumler_BolumID",
                table: "Kullanici",
                column: "BolumID",
                principalTable: "Bolumler",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRole_Kullanici_UserId",
                table: "KullaniciRole",
                column: "UserId",
                principalTable: "Kullanici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRole_Role_RoleId",
                table: "KullaniciRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanici_Bolumler_BolumID",
                table: "Kullanici");

            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRole_Kullanici_UserId",
                table: "KullaniciRole");

            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRole_Role_RoleId",
                table: "KullaniciRole");

            migrationBuilder.DropTable(
                name: "OdaMesajları");

            migrationBuilder.DropTable(
                name: "Odalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kullanici",
                table: "Kullanici");

            migrationBuilder.DropIndex(
                name: "IX_Kullanici_BolumID",
                table: "Kullanici");

            migrationBuilder.DropColumn(
                name: "BolumID",
                table: "Kullanici");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Kullanici",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRole_Roles_RoleId",
                table: "KullaniciRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRole_Users_UserId",
                table: "KullaniciRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
