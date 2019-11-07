﻿// <auto-generated />
using System;
using MediaService.MediaDBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MediaService.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MediaService.DBModel.CatalogueBooks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("Count");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Des");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Tel");

                    b.Property<string>("Type");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("CatalogueBooks");
                });

            modelBuilder.Entity("MediaService.DBModel.Express", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CompanyId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ExpressCompany");

                    b.Property<string>("ExpressContent");

                    b.Property<string>("ExpressNum");

                    b.Property<bool>("IsExamine");

                    b.Property<bool>("IsExhibitor");

                    b.Property<bool>("IsSend");

                    b.Property<string>("Price");

                    b.Property<string>("Recipient");

                    b.Property<string>("RecipientUnit");

                    b.Property<string>("Sender");

                    b.Property<string>("SenderId");

                    b.Property<DateTime>("SentDate");

                    b.Property<string>("Tel");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.ToTable("Express");
                });

            modelBuilder.Entity("MediaService.DBModel.FormPublic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("AddressEn");

                    b.Property<string>("BoothNumber");

                    b.Property<string>("CompanyId");

                    b.Property<string>("CompanyNameCn");

                    b.Property<string>("CompanyNameEn");

                    b.Property<string>("ContractNumber");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionEn");

                    b.Property<string>("Email");

                    b.Property<string>("ExbContractId");

                    b.Property<string>("Fax");

                    b.Property<bool>("IsHaveLogo");

                    b.Property<bool>("IsPay");

                    b.Property<string>("Logo");

                    b.Property<string>("Option");

                    b.Property<string>("OwnerId");

                    b.Property<string>("OwnerName");

                    b.Property<string>("PavilionNumber");

                    b.Property<string>("ProductType");

                    b.Property<string>("SnecLogoWebsite");

                    b.Property<string>("Source");

                    b.Property<string>("Telephone");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("FormPublic");
                });

            modelBuilder.Entity("MediaService.DBModel.HighlightsInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contract");

                    b.Property<string>("ContractCompany");

                    b.Property<string>("ContractCompanyEn");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("ExbContractId");

                    b.Property<string>("LDdescribeCn");

                    b.Property<string>("LDdescribeEn");

                    b.Property<string>("LDimage");

                    b.Property<string>("LDlogo");

                    b.Property<string>("LDnameCn");

                    b.Property<string>("LDnameEn");

                    b.Property<string>("MemberId");

                    b.Property<string>("Mobile");

                    b.Property<string>("OwnerId");

                    b.Property<string>("OwnerName");

                    b.Property<string>("ShowWay");

                    b.Property<string>("Tel");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Website");

                    b.Property<string>("YJIntroduction");

                    b.Property<string>("YJPhoto");

                    b.Property<string>("YJPosition");

                    b.Property<string>("YJPositionEn");

                    b.Property<string>("YJname");

                    b.Property<string>("YJnameEn");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.ToTable("HighlightsInfo");
                });

            modelBuilder.Entity("MediaService.DBModel.Hotel", b =>
                {
                    b.Property<Guid>("HotelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BankInfo");

                    b.Property<string>("BankInfoEn");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("HotelAddress");

                    b.Property<string>("HotelAddressEn");

                    b.Property<string>("HotelCode");

                    b.Property<string>("HotelEmail");

                    b.Property<string>("HotelIntroduction");

                    b.Property<string>("HotelIntroductionEn");

                    b.Property<int>("HotelLevel");

                    b.Property<string>("HotelName");

                    b.Property<string>("HotelNameEn");

                    b.Property<string>("HotelTel");

                    b.Property<string>("KeyWord");

                    b.Property<string>("Remark");

                    b.Property<string>("RemarkEn");

                    b.Property<int>("Sort");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("HotelId");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("MediaService.DBModel.HotelBookRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArriveFlight");

                    b.Property<DateTime>("BookTime");

                    b.Property<string>("CardDate");

                    b.Property<string>("CardNumber");

                    b.Property<string>("CardPerson");

                    b.Property<string>("CardType");

                    b.Property<string>("CheckInTime");

                    b.Property<string>("CheckOutTime");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Days");

                    b.Property<Guid>("HotelId");

                    b.Property<Guid>("HotelRoomTypeId");

                    b.Property<bool>("IsCanceled");

                    b.Property<int>("IsChecked");

                    b.Property<bool>("IsSmoke");

                    b.Property<bool>("IsWebsite");

                    b.Property<string>("LeaveFlight");

                    b.Property<string>("LinkManBirth");

                    b.Property<string>("LinkManCity");

                    b.Property<string>("LinkManCompany");

                    b.Property<string>("LinkManCountry");

                    b.Property<string>("LinkManEmail");

                    b.Property<string>("LinkManEmail2");

                    b.Property<string>("LinkManFax");

                    b.Property<string>("LinkManFirstName");

                    b.Property<string>("LinkManIdCardNumber");

                    b.Property<string>("LinkManIdCardType");

                    b.Property<string>("LinkManLastName");

                    b.Property<string>("LinkManMobile");

                    b.Property<string>("LinkManTel");

                    b.Property<string>("LinkManTitle");

                    b.Property<string>("MemberCompany");

                    b.Property<string>("MemberCompanyEn");

                    b.Property<string>("MemberEmail");

                    b.Property<string>("MemberId");

                    b.Property<string>("MemberName");

                    b.Property<string>("OrderNumber");

                    b.Property<string>("OtherCompany");

                    b.Property<string>("OtherEmail");

                    b.Property<string>("OtherMobile");

                    b.Property<string>("OtherName");

                    b.Property<string>("OtherTitle");

                    b.Property<string>("PayType");

                    b.Property<string>("Payer");

                    b.Property<string>("PriceCount");

                    b.Property<string>("Remark");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("HotelRoomTypeId");

                    b.ToTable("HotelBookRecord");
                });

            modelBuilder.Entity("MediaService.DBModel.HotelRoomType", b =>
                {
                    b.Property<Guid>("HotelRoomTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BedType");

                    b.Property<string>("BedTypeEn");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("HotelId");

                    b.Property<bool>("IsBreakfast");

                    b.Property<bool>("IsNet");

                    b.Property<bool>("IsUsed");

                    b.Property<int>("MaxCount");

                    b.Property<string>("Price");

                    b.Property<string>("Tax");

                    b.Property<string>("TypeName");

                    b.Property<string>("TypeNameEn");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("HotelRoomTypeId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRoomType");
                });

            modelBuilder.Entity("MediaService.DBModel.Interview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<string>("CompanyNameEn");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ExbContractId");

                    b.Property<string>("InterviewTime");

                    b.Property<string>("Introduction");

                    b.Property<string>("JobTitle");

                    b.Property<string>("JobTitleEn");

                    b.Property<string>("MediaName");

                    b.Property<string>("MemberId");

                    b.Property<string>("Name");

                    b.Property<string>("NameEn");

                    b.Property<string>("OwnerId");

                    b.Property<string>("OwnerName");

                    b.Property<string>("Photo");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Website");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.ToTable("Interview");
                });

            modelBuilder.Entity("MediaService.DBModel.HotelBookRecord", b =>
                {
                    b.HasOne("MediaService.DBModel.Hotel", "HotelItem")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MediaService.DBModel.HotelRoomType", "HotelRoomTypeItem")
                        .WithMany("HotelBookRecords")
                        .HasForeignKey("HotelRoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaService.DBModel.HotelRoomType", b =>
                {
                    b.HasOne("MediaService.DBModel.Hotel", "Hotel")
                        .WithMany("HotelRoomTypes")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
