using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogueBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Des = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogueBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Express",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    ExpressNum = table.Column<string>(nullable: true),
                    SentDate = table.Column<DateTime>(nullable: false),
                    SenderId = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    RecipientUnit = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Recipient = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    ExpressContent = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    ExpressCompany = table.Column<string>(nullable: true),
                    IsExamine = table.Column<bool>(nullable: false),
                    IsSend = table.Column<bool>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Express", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormPublic",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    CompanyNameCn = table.Column<string>(nullable: true),
                    CompanyNameEn = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AddressEn = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    PavilionNumber = table.Column<string>(nullable: true),
                    BoothNumber = table.Column<string>(nullable: true),
                    Option = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    SnecLogoWebsite = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Updated_at = table.Column<DateTime>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(nullable: true),
                    IsPay = table.Column<bool>(nullable: false),
                    IsHaveLogo = table.Column<bool>(nullable: false),
                    ContractNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormPublic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HighlightsInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LDnameCn = table.Column<string>(nullable: true),
                    LDnameEn = table.Column<string>(nullable: true),
                    LDdescribeCn = table.Column<string>(nullable: true),
                    LDdescribeEn = table.Column<string>(nullable: true),
                    LDimage = table.Column<string>(nullable: true),
                    LDlogo = table.Column<string>(nullable: true),
                    YJname = table.Column<string>(nullable: true),
                    YJnameEn = table.Column<string>(nullable: true),
                    YJPosition = table.Column<string>(nullable: true),
                    YJPositionEn = table.Column<string>(nullable: true),
                    YJIntroduction = table.Column<string>(nullable: true),
                    YJPhoto = table.Column<string>(nullable: true),
                    ShowWay = table.Column<string>(nullable: true),
                    Contract = table.Column<string>(nullable: true),
                    ContractCompany = table.Column<string>(nullable: true),
                    ContractCompanyEn = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MemberId = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighlightsInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelId = table.Column<Guid>(nullable: false),
                    HotelCode = table.Column<string>(nullable: true),
                    HotelName = table.Column<string>(nullable: true),
                    HotelNameEn = table.Column<string>(nullable: true),
                    HotelAddress = table.Column<string>(nullable: true),
                    HotelAddressEn = table.Column<string>(nullable: true),
                    Country = table.Column<int>(nullable: false),
                    KeyWord = table.Column<string>(nullable: true),
                    HotelEmail = table.Column<string>(nullable: true),
                    HotelTel = table.Column<string>(nullable: true),
                    HotelLevel = table.Column<int>(nullable: false),
                    HotelIntroduction = table.Column<string>(nullable: true),
                    HotelIntroductionEn = table.Column<string>(nullable: true),
                    BankInfo = table.Column<string>(nullable: true),
                    BankInfoEn = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    RemarkEn = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    JobTitleEn = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    InterviewTime = table.Column<string>(nullable: true),
                    MediaName = table.Column<string>(nullable: true),
                    MemberId = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyNameEn = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoomType",
                columns: table => new
                {
                    HptelRoomTypeId = table.Column<Guid>(nullable: false),
                    HotelId = table.Column<Guid>(nullable: false),
                    TypeName = table.Column<string>(nullable: true),
                    TypeNameEn = table.Column<string>(nullable: true),
                    BedType = table.Column<string>(nullable: true),
                    BedTypeEn = table.Column<string>(nullable: true),
                    MaxCount = table.Column<int>(nullable: false),
                    Price = table.Column<string>(nullable: true),
                    Tax = table.Column<string>(nullable: true),
                    IsBreakfast = table.Column<bool>(nullable: false),
                    IsNet = table.Column<bool>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomType", x => x.HptelRoomTypeId);
                    table.ForeignKey(
                        name: "FK_HotelRoomType_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelBookRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MemberId = table.Column<string>(nullable: true),
                    MemberCompany = table.Column<string>(nullable: true),
                    MemberCompanyEn = table.Column<string>(nullable: true),
                    HotelId = table.Column<Guid>(nullable: false),
                    HotelRoomTypeId = table.Column<Guid>(nullable: false),
                    BookTime = table.Column<DateTime>(nullable: false),
                    CheckInTime = table.Column<string>(nullable: true),
                    CheckOutTime = table.Column<string>(nullable: true),
                    IsCanceled = table.Column<int>(nullable: false),
                    IsChecked = table.Column<int>(nullable: false),
                    PriceCount = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Days = table.Column<int>(nullable: false),
                    ArriveFlight = table.Column<string>(nullable: true),
                    LeaveFlight = table.Column<string>(nullable: true),
                    IsSmoke = table.Column<string>(nullable: true),
                    LinkManFirstName = table.Column<string>(nullable: true),
                    LinkManLastName = table.Column<string>(nullable: true),
                    LinkManTel = table.Column<string>(nullable: true),
                    LinkManEmail = table.Column<string>(nullable: true),
                    LinkManTitle = table.Column<string>(nullable: true),
                    LinkManCountryId = table.Column<int>(nullable: false),
                    LinkManCity = table.Column<string>(nullable: true),
                    LinkManFax = table.Column<string>(nullable: true),
                    LinkManIdCardType = table.Column<string>(nullable: true),
                    LinkManIdCardNumber = table.Column<string>(nullable: true),
                    LinkManCompany = table.Column<string>(nullable: true),
                    LinkManMobile = table.Column<string>(nullable: true),
                    LinkManBirth = table.Column<string>(nullable: true),
                    OtherName = table.Column<string>(nullable: true),
                    OtherTitle = table.Column<string>(nullable: true),
                    OtherEmail = table.Column<string>(nullable: true),
                    OtherMobile = table.Column<string>(nullable: true),
                    OtherCompany = table.Column<string>(nullable: true),
                    CardPerson = table.Column<string>(nullable: true),
                    CardType = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    CardDate = table.Column<string>(nullable: true),
                    Payer = table.Column<string>(nullable: true),
                    PayType = table.Column<string>(nullable: true),
                    LinkManEmail2 = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false),
                    IsWebsite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBookRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelBookRecord_HotelRoomType_HotelRoomTypeId",
                        column: x => x.HotelRoomTypeId,
                        principalTable: "HotelRoomType",
                        principalColumn: "HptelRoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookRecord_HotelRoomTypeId",
                table: "HotelBookRecord",
                column: "HotelRoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomType_HotelId",
                table: "HotelRoomType",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogueBooks");

            migrationBuilder.DropTable(
                name: "Express");

            migrationBuilder.DropTable(
                name: "FormPublic");

            migrationBuilder.DropTable(
                name: "HighlightsInfo");

            migrationBuilder.DropTable(
                name: "HotelBookRecord");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "HotelRoomType");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
