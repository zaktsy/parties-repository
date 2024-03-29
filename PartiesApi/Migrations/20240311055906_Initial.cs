﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartiesApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DressCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DressCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartyRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    FromUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => new { x.FromUserId, x.ToUserId });
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DressCodeId = table.Column<Guid>(type: "uuid", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrganizerId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationLatitude = table.Column<double>(type: "double precision", nullable: false),
                    LocationLongitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parties_DressCodes_DressCodeId",
                        column: x => x.DressCodeId,
                        principalTable: "DressCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parties_Users_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFriend",
                columns: table => new
                {
                    FirstUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecondUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriend", x => new { x.FirstUserId, x.SecondUserId });
                    table.ForeignKey(
                        name: "FK_UserFriend_Users_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFriend_Users_SecondUserId",
                        column: x => x.SecondUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartyEditors",
                columns: table => new
                {
                    EditorPartiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartyEditorsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyEditors", x => new { x.EditorPartiesId, x.PartyEditorsId });
                    table.ForeignKey(
                        name: "FK_PartyEditors_Parties_EditorPartiesId",
                        column: x => x.EditorPartiesId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartyEditors_Users_PartyEditorsId",
                        column: x => x.PartyEditorsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartyMembers",
                columns: table => new
                {
                    MemberPartiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartyMembersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyMembers", x => new { x.MemberPartiesId, x.PartyMembersId });
                    table.ForeignKey(
                        name: "FK_PartyMembers_Parties_MemberPartiesId",
                        column: x => x.MemberPartiesId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartyMembers_Users_PartyMembersId",
                        column: x => x.PartyMembersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartyPartyRule",
                columns: table => new
                {
                    PartiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartyRulesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyPartyRule", x => new { x.PartiesId, x.PartyRulesId });
                    table.ForeignKey(
                        name: "FK_PartyPartyRule_Parties_PartiesId",
                        column: x => x.PartiesId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartyPartyRule_PartyRules_PartyRulesId",
                        column: x => x.PartyRulesId,
                        principalTable: "PartyRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ToUserId",
                table: "FriendRequests",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_DressCodeId",
                table: "Parties",
                column: "DressCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_OrganizerId",
                table: "Parties",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyEditors_PartyEditorsId",
                table: "PartyEditors",
                column: "PartyEditorsId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyMembers_PartyMembersId",
                table: "PartyMembers",
                column: "PartyMembersId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyPartyRule_PartyRulesId",
                table: "PartyPartyRule",
                column: "PartyRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriend_SecondUserId",
                table: "UserFriend",
                column: "SecondUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "PartyEditors");

            migrationBuilder.DropTable(
                name: "PartyMembers");

            migrationBuilder.DropTable(
                name: "PartyPartyRule");

            migrationBuilder.DropTable(
                name: "UserFriend");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "PartyRules");

            migrationBuilder.DropTable(
                name: "DressCodes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
