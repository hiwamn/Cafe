using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.EndPoint.Migrations
{
    public partial class _280799 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Mobile = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BarginTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarginTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    DocumentType = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PricePerFirstHour = table.Column<int>(nullable: false),
                    PricePerOtherhour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredTableUserCount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredTableUserCount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Updates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Version = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Restricted = table.Column<bool>(nullable: false),
                    Link = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Updates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slider_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    StaffPrice = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_EntityStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EntityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    No = table.Column<int>(nullable: false),
                    MaxCount = table.Column<int>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    IsForGame = table.Column<bool>(nullable: false),
                    EntityStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_EntityStatuses_EntityStatusId",
                        column: x => x.EntityStatusId,
                        principalTable: "EntityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BarginCampaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    BarginTypeId = table.Column<int>(nullable: false),
                    GameTypeId = table.Column<int>(nullable: true),
                    IsProductDiscount = table.Column<bool>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    TotalCount = table.Column<int>(nullable: false),
                    RemainedCount = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StartTime = table.Column<long>(nullable: false),
                    EndTime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarginCampaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarginCampaigns_BarginTypes_BarginTypeId",
                        column: x => x.BarginTypeId,
                        principalTable: "BarginTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarginCampaigns_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarginCampaigns_EntityStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EntityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventAndLeagues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GameTypeId = table.Column<int>(nullable: false),
                    StartAt = table.Column<long>(nullable: false),
                    TotalCount = table.Column<int>(nullable: false),
                    RemainedCount = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    IsEvent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAndLeagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventAndLeagues_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventAndLeagues_EntityStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EntityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GameTypeId = table.Column<int>(nullable: false),
                    StartAt = table.Column<long>(nullable: false),
                    TotalCount = table.Column<int>(nullable: false),
                    RemainedCount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupGames_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupGames_EntityStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EntityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    TableId = table.Column<Guid>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableMessage_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FamilyName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthday = table.Column<long>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ReferenceId = table.Column<Guid>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    ProfileImageId = table.Column<Guid>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Documents_ProfileImageId",
                        column: x => x.ProfileImageId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BarginUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BarginCampaignId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarginUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarginUsers_BarginCampaigns_BarginCampaignId",
                        column: x => x.BarginCampaignId,
                        principalTable: "BarginCampaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarginUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    PushId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    EventAndLeagueId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUsers", x => new { x.EventAndLeagueId, x.UserId });
                    table.ForeignKey(
                        name: "FK_EventUsers_EventAndLeagues_EventAndLeagueId",
                        column: x => x.EventAndLeagueId,
                        principalTable: "EventAndLeagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupGameUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    GroupGameId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupGameUsers", x => new { x.GroupGameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GroupGameUsers_GroupGames_GroupGameId",
                        column: x => x.GroupGameId,
                        principalTable: "GroupGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupGameUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    IsFromAdmin = table.Column<bool>(nullable: false),
                    UserId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductRate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRate_ProductRate_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductRate_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductRate_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    TableId = table.Column<Guid>(nullable: false),
                    FinishedTime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredTable_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredTable_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredWorkTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Date = table.Column<long>(nullable: false),
                    Hour = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredWorkTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredWorkTime_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TableReserve",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    TableId = table.Column<Guid>(nullable: true),
                    Time = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableReserve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableReserve_EntityStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EntityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableReserve_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TableReserve_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    Date = table.Column<long>(nullable: false),
                    MaxCount = table.Column<int>(nullable: false),
                    Remained = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDiscount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    From = table.Column<long>(nullable: false),
                    To = table.Column<long>(nullable: false),
                    Percent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiscount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDiscount_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTransactionList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    PartnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTransactionList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTransactionList_Users_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTransactionList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    IsInput = table.Column<bool>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Date = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTime_EntityStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EntityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkTime_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    DeviceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    EndedAt = table.Column<long>(nullable: false),
                    PeopleCount = table.Column<int>(nullable: false),
                    TableReserveId = table.Column<Guid>(nullable: true),
                    PromoterId = table.Column<Guid>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Paid = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<long>(nullable: false),
                    RegisteredTableId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Users_PromoterId",
                        column: x => x.PromoterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bills_RegisteredTable_RegisteredTableId",
                        column: x => x.RegisteredTableId,
                        principalTable: "RegisteredTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bills_TableReserve_TableReserveId",
                        column: x => x.TableReserveId,
                        principalTable: "TableReserve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMember_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMember_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BarginUserBills",
                columns: table => new
                {
                    BarginUsersId = table.Column<Guid>(nullable: false),
                    BillId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    BarginUsersId1 = table.Column<Guid>(nullable: true),
                    BillId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarginUserBills", x => new { x.BarginUsersId, x.BillId });
                    table.ForeignKey(
                        name: "FK_BarginUserBills_BarginUsers_BarginUsersId",
                        column: x => x.BarginUsersId,
                        principalTable: "BarginUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarginUserBills_BarginUsers_BarginUsersId1",
                        column: x => x.BarginUsersId1,
                        principalTable: "BarginUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarginUserBills_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarginUserBills_Bills_BillId1",
                        column: x => x.BillId1,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    GameTypeId = table.Column<int>(nullable: false),
                    BillId = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    From = table.Column<long>(nullable: false),
                    To = table.Column<long>(nullable: false),
                    UnitPriceFirstHour = table.Column<int>(nullable: false),
                    UnitPriceOtherHour = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillGames_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillGames_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    BillId = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillItems_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    TransactionCategoryId = table.Column<int>(nullable: false),
                    Authority = table.Column<string>(nullable: true),
                    RefId = table.Column<string>(nullable: true),
                    IsSuccessful = table.Column<bool>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    BillId = table.Column<Guid>(nullable: true),
                    NextUserId = table.Column<Guid>(nullable: true),
                    Json = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_NextUserId",
                        column: x => x.NextUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionCategories_TransactionCategoryId",
                        column: x => x.TransactionCategoryId,
                        principalTable: "TransactionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BarginTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "درصد" },
                    { 2, "ثابت" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Iran" });

            migrationBuilder.InsertData(
                table: "EntityStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Waiting/Deactivated" },
                    { 1, "Activated/Submited" },
                    { 2, "Deleted" },
                    { 3, "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "GameTypes",
                columns: new[] { "Id", "Name", "PricePerFirstHour", "PricePerOtherhour" },
                values: new object[,]
                {
                    { 1, "بازیهای رومیزی", 0, 0 },
                    { 2, "بازیهای کنسول", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Accountant" },
                    { 3, "Staff" },
                    { 1, "Mobile" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "سقف خرید پرسنل", "MaxStaffBying", "50000" },
                    { 2, "هزینه ساخت تیم", "TeamPrice", "50000" }
                });

            migrationBuilder.InsertData(
                table: "TransactionCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "حقوق" },
                    { 1, "پرداخت" },
                    { 2, "دریافت" },
                    { 3, "ارسال" },
                    { 4, "واریز از درگاه" },
                    { 5, "نقدی" },
                    { 6, "افزایش اعتبار روزانه" },
                    { 7, "کاهش اعتبار روزانه" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Birthday", "CityId", "CreatedAt", "Email", "FamilyName", "Gender", "Mobile", "Name", "Password", "ProfileImageId", "ReferenceId", "Salt", "Status" },
                values: new object[] { new Guid("8114eb2e-3588-4239-98a4-f7e3023674e8"), null, null, null, 0L, null, "کل", null, "09130097415", "مدیر", "2qvDblRb3qH7Iih+x1g+aqsFyWoW/1bjlv/fa0/V2N2fJakZBYqxxA==", null, null, "2rQAX8POwoxBCoaBgjAe3QQ1vqKt5fZhkMAeohIZ8hfzGbdsXb9HxQ==", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "ParentId", "Price", "StaffPrice", "StatusId" },
                values: new object[,]
                {
                    { new Guid("6b22b8a8-4402-4127-87f2-7e6df18bf0e6"), 1603106178L, "میان وعده", "میان وعده", null, 0, 0, 0 },
                    { new Guid("a2881e4f-43ce-47df-ab15-edb746ef281d"), 1603106178L, "نوشیدنی سرد", "نوشیدنی سرد", null, 0, 0, 0 },
                    { new Guid("d340e0f7-7ebd-4b3f-bc4c-115e224546d1"), 1603106178L, "سردنوش گیاهی", "سردنوش گیاهی", null, 0, 0, 0 },
                    { new Guid("69eb1978-7fc3-4936-b43b-ca1d3d1d90ad"), 1603106178L, "نوشیدنی گرم", "نوشیدنی گرم", null, 0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Isfahan" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "RoleId", "UserId" },
                values: new object[] { new Guid("44fc4a46-6bd7-45d0-a911-b989ed4a944c"), 1603106178L, 2, new Guid("8114eb2e-3588-4239-98a4-f7e3023674e8") });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Sede", 1 },
                    { 2, "Shahin Shahr", 1 },
                    { 3, "Jalal Abad", 1 },
                    { 4, "Ghahdrijan", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "ParentId", "Price", "StaffPrice", "StatusId" },
                values: new object[,]
                {
                    { new Guid("18b746d2-7eef-46b6-8ea8-d19de794ed74"), 1603106178L, "میان وعده 1", "میان وعده 1", new Guid("6b22b8a8-4402-4127-87f2-7e6df18bf0e6"), 0, 0, 0 },
                    { new Guid("2f036ba7-c577-4870-ade8-c5b71bf5378b"), 1603106178L, "میان وعده 2", "میان وعده 2", new Guid("6b22b8a8-4402-4127-87f2-7e6df18bf0e6"), 0, 0, 0 },
                    { new Guid("57dda9fa-feb2-46e0-b7c3-a619497f1545"), 1603106178L, "نوشیدنی سرد 1", "نوشیدنی سرد 1", new Guid("a2881e4f-43ce-47df-ab15-edb746ef281d"), 0, 0, 0 },
                    { new Guid("b3215f0c-eb04-4371-b11b-6d554bd7deaa"), 1603106178L, "نوشیدنی سرد 2", "نوشیدنی سرد 2", new Guid("a2881e4f-43ce-47df-ab15-edb746ef281d"), 0, 0, 0 },
                    { new Guid("daf5bb7e-5d45-403f-a120-230bb35928eb"), 1603106178L, "سردنوش گیاهی 1", "سردنوش گیاهی 1", new Guid("d340e0f7-7ebd-4b3f-bc4c-115e224546d1"), 0, 0, 0 },
                    { new Guid("c056d1cb-d42e-4c66-b430-cbfd4775a842"), 1603106178L, "سردنوش گیاهی 2", "سردنوش گیاهی 2", new Guid("d340e0f7-7ebd-4b3f-bc4c-115e224546d1"), 0, 0, 0 },
                    { new Guid("86e88e9c-3e6c-4bf1-9f27-86fe1550f7cc"), 1603106178L, "قهوه ها", "قهوه ها", new Guid("69eb1978-7fc3-4936-b43b-ca1d3d1d90ad"), 0, 0, 0 },
                    { new Guid("b29d2e3f-839f-4666-8da6-fb15dc3e955c"), 1603106178L, "کاپوچینوها", "کاپوچینوها", new Guid("69eb1978-7fc3-4936-b43b-ca1d3d1d90ad"), 0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "ParentId", "Price", "StaffPrice", "StatusId" },
                values: new object[,]
                {
                    { new Guid("7e2b0815-956a-432e-b675-21e60f1b1c43"), 1603106178L, "", "میان 1", new Guid("18b746d2-7eef-46b6-8ea8-d19de794ed74"), 0, 0, 0 },
                    { new Guid("3fb5d92d-a5a4-44b8-8a3d-83b7688372c8"), 1603106178L, "", "میان 2", new Guid("18b746d2-7eef-46b6-8ea8-d19de794ed74"), 0, 0, 0 },
                    { new Guid("73c6db7c-858c-42a1-a004-528fc0d41924"), 1603106178L, "", "میان 3", new Guid("2f036ba7-c577-4870-ade8-c5b71bf5378b"), 0, 0, 0 },
                    { new Guid("b38671d2-aaec-40b3-bd33-37570b2b0eea"), 1603106178L, "", "میان 4", new Guid("2f036ba7-c577-4870-ade8-c5b71bf5378b"), 0, 0, 0 },
                    { new Guid("e1fa6eb1-2c9b-4c19-99bd-07655f1eaf04"), 1603106178L, "", "نوش 1", new Guid("57dda9fa-feb2-46e0-b7c3-a619497f1545"), 0, 0, 0 },
                    { new Guid("cd9b33b5-881e-4d01-8cb2-67e75436ce36"), 1603106178L, "", "نوش 2", new Guid("57dda9fa-feb2-46e0-b7c3-a619497f1545"), 0, 0, 0 },
                    { new Guid("49f637fb-7434-4429-9a3d-0b061dfd9aee"), 1603106178L, "", "نوش 3", new Guid("b3215f0c-eb04-4371-b11b-6d554bd7deaa"), 0, 0, 0 },
                    { new Guid("1f19acd9-54df-4898-9a73-322bb21f0827"), 1603106178L, "", "نوش 4", new Guid("b3215f0c-eb04-4371-b11b-6d554bd7deaa"), 0, 0, 0 },
                    { new Guid("f36da1d0-11f6-4b0a-9bdd-292c4eb056e2"), 1603106178L, "", "سردنوش 1", new Guid("daf5bb7e-5d45-403f-a120-230bb35928eb"), 0, 0, 0 },
                    { new Guid("bf856381-349c-41b6-ad9c-e54a2f054447"), 1603106178L, "", "سردنوش 2", new Guid("daf5bb7e-5d45-403f-a120-230bb35928eb"), 0, 0, 0 },
                    { new Guid("cfeed39b-c410-4767-927c-1be02c8c9096"), 1603106178L, "", "سردنوش 3", new Guid("c056d1cb-d42e-4c66-b430-cbfd4775a842"), 0, 0, 0 },
                    { new Guid("211d7f77-c324-417e-9e73-ba5bcc6c42ff"), 1603106178L, "", "سردوش 4", new Guid("c056d1cb-d42e-4c66-b430-cbfd4775a842"), 0, 0, 0 },
                    { new Guid("c5ac0554-3e81-4655-97a2-35415a96afe1"), 1603106178L, "", "قهوه 1", new Guid("86e88e9c-3e6c-4bf1-9f27-86fe1550f7cc"), 0, 0, 0 },
                    { new Guid("042d0c7c-028d-4a54-be9b-1b019c7b7e27"), 1603106178L, "", "قهوه 2", new Guid("86e88e9c-3e6c-4bf1-9f27-86fe1550f7cc"), 0, 0, 0 },
                    { new Guid("cb76002a-43d6-4516-bcb1-d2782ad7c6c0"), 1603106178L, "", "کاپوچینو 1", new Guid("b29d2e3f-839f-4666-8da6-fb15dc3e955c"), 0, 0, 0 },
                    { new Guid("6bff0dca-8871-44ba-b0ce-fd892c70dce1"), 1603106178L, "", "کاپوچینو 2", new Guid("b29d2e3f-839f-4666-8da6-fb15dc3e955c"), 0, 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarginCampaigns_BarginTypeId",
                table: "BarginCampaigns",
                column: "BarginTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BarginCampaigns_GameTypeId",
                table: "BarginCampaigns",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BarginCampaigns_StatusId",
                table: "BarginCampaigns",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BarginUserBills_BarginUsersId1",
                table: "BarginUserBills",
                column: "BarginUsersId1",
                unique: true,
                filter: "[BarginUsersId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BarginUserBills_BillId",
                table: "BarginUserBills",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BarginUserBills_BillId1",
                table: "BarginUserBills",
                column: "BillId1");

            migrationBuilder.CreateIndex(
                name: "IX_BarginUsers_BarginCampaignId",
                table: "BarginUsers",
                column: "BarginCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_BarginUsers_UserId",
                table: "BarginUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BillGames_BillId",
                table: "BillGames",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillGames_GameTypeId",
                table: "BillGames",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BillItems_BillId",
                table: "BillItems",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillItems_ProductId",
                table: "BillItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PromoterId",
                table: "Bills",
                column: "PromoterId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_RegisteredTableId",
                table: "Bills",
                column: "RegisteredTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_TableReserveId",
                table: "Bills",
                column: "TableReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserId",
                table: "Bills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAndLeagues_GameTypeId",
                table: "EventAndLeagues",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAndLeagues_StatusId",
                table: "EventAndLeagues",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUsers_UserId",
                table: "EventUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupGames_GameTypeId",
                table: "GroupGames",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupGames_StatusId",
                table: "GroupGames",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupGameUsers_UserId",
                table: "GroupGameUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId1",
                table: "Message",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DeviceId",
                table: "Notifications",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_DocumentId",
                table: "ProductImages",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRate_ParentId",
                table: "ProductRate",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRate_ProductId",
                table: "ProductRate",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRate_UserId",
                table: "ProductRate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StatusId",
                table: "Products",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTable_TableId",
                table: "RegisteredTable",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTable_UserId",
                table: "RegisteredTable",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredWorkTime_UserId",
                table: "RegisteredWorkTime",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_DocumentId",
                table: "Slider",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_TableMessage_TableId",
                table: "TableMessage",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReserve_StatusId",
                table: "TableReserve",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReserve_TableId",
                table: "TableReserve",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReserve_UserId",
                table: "TableReserve",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_EntityStatusId",
                table: "Tables",
                column: "EntityStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UserId",
                table: "Team",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_TeamId",
                table: "TeamMember",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_UserId",
                table: "TeamMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BillId",
                table: "Transactions",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_NextUserId",
                table: "Transactions",
                column: "NextUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionCategoryId",
                table: "Transactions",
                column: "TransactionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscount_UserId",
                table: "UserDiscount",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileImageId",
                table: "Users",
                column: "ProfileImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ReferenceId",
                table: "Users",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTransactionList_PartnerId",
                table: "UserTransactionList",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTransactionList_UserId",
                table: "UserTransactionList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTime_StatusId",
                table: "WorkTime",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTime_UserId",
                table: "WorkTime",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveCodes");

            migrationBuilder.DropTable(
                name: "BarginUserBills");

            migrationBuilder.DropTable(
                name: "BillGames");

            migrationBuilder.DropTable(
                name: "BillItems");

            migrationBuilder.DropTable(
                name: "EventUsers");

            migrationBuilder.DropTable(
                name: "GroupGameUsers");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductRate");

            migrationBuilder.DropTable(
                name: "RegisteredTableUserCount");

            migrationBuilder.DropTable(
                name: "RegisteredWorkTime");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "TableMessage");

            migrationBuilder.DropTable(
                name: "TeamMember");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Updates");

            migrationBuilder.DropTable(
                name: "UserDiscount");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTransactionList");

            migrationBuilder.DropTable(
                name: "WorkTime");

            migrationBuilder.DropTable(
                name: "BarginUsers");

            migrationBuilder.DropTable(
                name: "EventAndLeagues");

            migrationBuilder.DropTable(
                name: "GroupGames");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "TransactionCategories");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "BarginCampaigns");

            migrationBuilder.DropTable(
                name: "RegisteredTable");

            migrationBuilder.DropTable(
                name: "TableReserve");

            migrationBuilder.DropTable(
                name: "BarginTypes");

            migrationBuilder.DropTable(
                name: "GameTypes");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EntityStatuses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
