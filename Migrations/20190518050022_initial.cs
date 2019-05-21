using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArktiPhonesWebApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Basics",
                columns: table => new
                {
                    BasicID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GsmArenaId = table.Column<int>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    DeviceType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basics", x => x.BasicID);
                });

            migrationBuilder.CreateTable(
                name: "Batteries",
                columns: table => new
                {
                    BatteryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Capacity = table.Column<int>(nullable: true),
                    Technology = table.Column<string>(nullable: true),
                    Endurance = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batteries", x => x.BatteryID);
                });

            migrationBuilder.CreateTable(
                name: "CameraInfos",
                columns: table => new
                {
                    CameraInfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhotoResolution = table.Column<double>(nullable: true),
                    VideoResolution = table.Column<int>(nullable: true),
                    FrontCameraLeds = table.Column<int>(nullable: true),
                    RearCameraLeds = table.Column<int>(nullable: true),
                    CameraOriginalText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraInfos", x => x.CameraInfoID);
                });

            migrationBuilder.CreateTable(
                name: "Cpus",
                columns: table => new
                {
                    CpuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Producer = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Series = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Cores = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpus", x => x.CpuID);
                });

            migrationBuilder.CreateTable(
                name: "Displays",
                columns: table => new
                {
                    DisplayID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResolutionWidth = table.Column<int>(nullable: true),
                    ResolutionHeight = table.Column<int>(nullable: true),
                    ResolutionLines = table.Column<int>(nullable: true),
                    PixelDensity = table.Column<double>(nullable: true),
                    WidthRatio = table.Column<double>(nullable: true),
                    HeightRatio = table.Column<double>(nullable: true),
                    Diagonal = table.Column<double>(nullable: true),
                    Area = table.Column<double>(nullable: true),
                    ScreenToBodyRatio = table.Column<double>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ColorMode = table.Column<string>(nullable: true),
                    Colors = table.Column<int>(nullable: true),
                    EffectiveColors = table.Column<int>(nullable: true),
                    Touchscreen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Displays", x => x.DisplayID);
                });

            migrationBuilder.CreateTable(
                name: "Gps",
                columns: table => new
                {
                    GpsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Available = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gps", x => x.GpsID);
                });

            migrationBuilder.CreateTable(
                name: "Gpus",
                columns: table => new
                {
                    GpuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gpus", x => x.GpuID);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Front = table.Column<string>(nullable: true),
                    Back = table.Column<string>(nullable: true),
                    Frame = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialID);
                });

            migrationBuilder.CreateTable(
                name: "Memories",
                columns: table => new
                {
                    MemoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardType = table.Column<string>(nullable: true),
                    CardMaxSize = table.Column<int>(nullable: true),
                    Internal = table.Column<int>(nullable: true),
                    ReadOnly = table.Column<int>(nullable: true),
                    RandomAccess = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memories", x => x.MemoryID);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystems",
                columns: table => new
                {
                    OperatingSystemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    LatestVersion = table.Column<string>(nullable: true),
                    FlavorName = table.Column<string>(nullable: true),
                    FlavorVersion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystems", x => x.OperatingSystemID);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<double>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    EstimatedInEuro = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentStatus = table.Column<string>(nullable: true),
                    DatesOriginalText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Usb",
                columns: table => new
                {
                    UsbID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Version = table.Column<string>(nullable: true),
                    Connector = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usb", x => x.UsbID);
                });

            migrationBuilder.CreateTable(
                name: "Wlan",
                columns: table => new
                {
                    WlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Available = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wlan", x => x.WlanID);
                });

            migrationBuilder.CreateTable(
                name: "Camera",
                columns: table => new
                {
                    CameraID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true),
                    Resolution = table.Column<double>(nullable: true),
                    OpticalZoom = table.Column<int>(nullable: true),
                    SensorSize = table.Column<double>(nullable: true),
                    FocalLength = table.Column<double>(nullable: true),
                    Aperture = table.Column<double>(nullable: true),
                    CameraInfoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera", x => x.CameraID);
                    table.ForeignKey(
                        name: "FK_Camera_CameraInfos_CameraInfoID",
                        column: x => x.CameraInfoID,
                        principalTable: "CameraInfos",
                        principalColumn: "CameraInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoMode",
                columns: table => new
                {
                    VideoModeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Width = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: true),
                    FrameRate = table.Column<int>(nullable: true),
                    CameraSide = table.Column<string>(nullable: true),
                    CameraInfoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoMode", x => x.VideoModeID);
                    table.ForeignKey(
                        name: "FK_VideoMode_CameraInfos_CameraInfoID",
                        column: x => x.CameraInfoID,
                        principalTable: "CameraInfos",
                        principalColumn: "CameraInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GpsFeature",
                columns: table => new
                {
                    GpsFeatureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    GpsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpsFeature", x => x.GpsFeatureID);
                    table.ForeignKey(
                        name: "FK_GpsFeature_Gps_GpsID",
                        column: x => x.GpsID,
                        principalTable: "Gps",
                        principalColumn: "GpsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Builds",
                columns: table => new
                {
                    BuildID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Weight = table.Column<double>(nullable: true),
                    DimensionsID = table.Column<int>(nullable: true),
                    MaterialID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builds", x => x.BuildID);
                    table.ForeignKey(
                        name: "FK_Builds_Material_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Material",
                        principalColumn: "MaterialID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    DateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: true),
                    Month = table.Column<int>(nullable: true),
                    Quarter = table.Column<int>(nullable: true),
                    AnnouncedStatusID = table.Column<int>(nullable: true),
                    ReleasedStatusID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.DateID);
                    table.ForeignKey(
                        name: "FK_Date_Status_AnnouncedStatusID",
                        column: x => x.AnnouncedStatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Date_Status_ReleasedStatusID",
                        column: x => x.ReleasedStatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsbFeature",
                columns: table => new
                {
                    UsbFeatureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UsbID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsbFeature", x => x.UsbFeatureID);
                    table.ForeignKey(
                        name: "FK_UsbFeature_Usb_UsbID",
                        column: x => x.UsbID,
                        principalTable: "Usb",
                        principalColumn: "UsbID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Communications",
                columns: table => new
                {
                    CommunicationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AudioJack = table.Column<bool>(nullable: true),
                    Bluetooth = table.Column<string>(nullable: true),
                    Infrared = table.Column<bool>(nullable: false),
                    Nfc = table.Column<bool>(nullable: false),
                    GpsID = table.Column<int>(nullable: true),
                    UsbID = table.Column<int>(nullable: true),
                    WlanID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communications", x => x.CommunicationID);
                    table.ForeignKey(
                        name: "FK_Communications_Gps_GpsID",
                        column: x => x.GpsID,
                        principalTable: "Gps",
                        principalColumn: "GpsID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Communications_Usb_UsbID",
                        column: x => x.UsbID,
                        principalTable: "Usb",
                        principalColumn: "UsbID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Communications_Wlan_WlanID",
                        column: x => x.WlanID,
                        principalTable: "Wlan",
                        principalColumn: "WlanID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WlanFeature",
                columns: table => new
                {
                    WlanFeatureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    WlanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WlanFeature", x => x.WlanFeatureID);
                    table.ForeignKey(
                        name: "FK_WlanFeature_Wlan_WlanID",
                        column: x => x.WlanID,
                        principalTable: "Wlan",
                        principalColumn: "WlanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WlanStandard",
                columns: table => new
                {
                    WlanStandardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    WlanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WlanStandard", x => x.WlanStandardID);
                    table.ForeignKey(
                        name: "FK_WlanStandard_Wlan_WlanID",
                        column: x => x.WlanID,
                        principalTable: "Wlan",
                        principalColumn: "WlanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CameraFeature",
                columns: table => new
                {
                    CameraFeatureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CameraID = table.Column<int>(nullable: true),
                    VideoFeatureCameraInfoID = table.Column<int>(nullable: true),
                    RearCameraFeatureCameraInfoID = table.Column<int>(nullable: true),
                    FrontCameraFeatureCameraInfoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraFeature", x => x.CameraFeatureID);
                    table.ForeignKey(
                        name: "FK_CameraFeature_Camera_CameraID",
                        column: x => x.CameraID,
                        principalTable: "Camera",
                        principalColumn: "CameraID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CameraFeature_CameraInfos_FrontCameraFeatureCameraInfoID",
                        column: x => x.FrontCameraFeatureCameraInfoID,
                        principalTable: "CameraInfos",
                        principalColumn: "CameraInfoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CameraFeature_CameraInfos_RearCameraFeatureCameraInfoID",
                        column: x => x.RearCameraFeatureCameraInfoID,
                        principalTable: "CameraInfos",
                        principalColumn: "CameraInfoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CameraFeature_CameraInfos_VideoFeatureCameraInfoID",
                        column: x => x.VideoFeatureCameraInfoID,
                        principalTable: "CameraInfos",
                        principalColumn: "CameraInfoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceColor",
                columns: table => new
                {
                    DeviceColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BuildID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceColor", x => x.DeviceColorID);
                    table.ForeignKey(
                        name: "FK_DeviceColor_Builds_BuildID",
                        column: x => x.BuildID,
                        principalTable: "Builds",
                        principalColumn: "BuildID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dimension",
                columns: table => new
                {
                    DimensionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Width = table.Column<double>(nullable: true),
                    Height = table.Column<double>(nullable: true),
                    Thickness = table.Column<double>(nullable: true),
                    Volume = table.Column<double>(nullable: true),
                    BuildID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimension", x => x.DimensionID);
                    table.ForeignKey(
                        name: "FK_Dimension_Builds_BuildID",
                        column: x => x.BuildID,
                        principalTable: "Builds",
                        principalColumn: "BuildID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceDetails",
                columns: table => new
                {
                    DeviceDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BasicID = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    BatteryID = table.Column<int>(nullable: false),
                    DisplayID = table.Column<int>(nullable: false),
                    CommunicationID = table.Column<int>(nullable: false),
                    BuildID = table.Column<int>(nullable: false),
                    CameraInfoID = table.Column<int>(nullable: false),
                    MemoryID = table.Column<int>(nullable: false),
                    PriceID = table.Column<int>(nullable: false),
                    OperatingSystemID = table.Column<int>(nullable: false),
                    CpuID = table.Column<int>(nullable: false),
                    GpuID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDetails", x => x.DeviceDetailID);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Basics_BasicID",
                        column: x => x.BasicID,
                        principalTable: "Basics",
                        principalColumn: "BasicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Batteries_BatteryID",
                        column: x => x.BatteryID,
                        principalTable: "Batteries",
                        principalColumn: "BatteryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Builds_BuildID",
                        column: x => x.BuildID,
                        principalTable: "Builds",
                        principalColumn: "BuildID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_CameraInfos_CameraInfoID",
                        column: x => x.CameraInfoID,
                        principalTable: "CameraInfos",
                        principalColumn: "CameraInfoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Communications_CommunicationID",
                        column: x => x.CommunicationID,
                        principalTable: "Communications",
                        principalColumn: "CommunicationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Cpus_CpuID",
                        column: x => x.CpuID,
                        principalTable: "Cpus",
                        principalColumn: "CpuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Displays_DisplayID",
                        column: x => x.DisplayID,
                        principalTable: "Displays",
                        principalColumn: "DisplayID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Gpus_GpuID",
                        column: x => x.GpuID,
                        principalTable: "Gpus",
                        principalColumn: "GpuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Memories_MemoryID",
                        column: x => x.MemoryID,
                        principalTable: "Memories",
                        principalColumn: "MemoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_OperatingSystems_OperatingSystemID",
                        column: x => x.OperatingSystemID,
                        principalTable: "OperatingSystems",
                        principalColumn: "OperatingSystemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Prices_PriceID",
                        column: x => x.PriceID,
                        principalTable: "Prices",
                        principalColumn: "PriceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDetails_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    SensorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CommunicationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.SensorID);
                    table.ForeignKey(
                        name: "FK_Sensor_Communications_CommunicationID",
                        column: x => x.CommunicationID,
                        principalTable: "Communications",
                        principalColumn: "CommunicationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimCard",
                columns: table => new
                {
                    SimCardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    CommunicationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimCard", x => x.SimCardID);
                    table.ForeignKey(
                        name: "FK_SimCard_Communications_CommunicationID",
                        column: x => x.CommunicationID,
                        principalTable: "Communications",
                        principalColumn: "CommunicationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Builds_MaterialID",
                table: "Builds",
                column: "MaterialID",
                unique: true,
                filter: "[MaterialID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Camera_CameraInfoID",
                table: "Camera",
                column: "CameraInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_CameraFeature_CameraID",
                table: "CameraFeature",
                column: "CameraID");

            migrationBuilder.CreateIndex(
                name: "IX_CameraFeature_FrontCameraFeatureCameraInfoID",
                table: "CameraFeature",
                column: "FrontCameraFeatureCameraInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_CameraFeature_RearCameraFeatureCameraInfoID",
                table: "CameraFeature",
                column: "RearCameraFeatureCameraInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_CameraFeature_VideoFeatureCameraInfoID",
                table: "CameraFeature",
                column: "VideoFeatureCameraInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_GpsID",
                table: "Communications",
                column: "GpsID",
                unique: true,
                filter: "[GpsID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_UsbID",
                table: "Communications",
                column: "UsbID",
                unique: true,
                filter: "[UsbID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_WlanID",
                table: "Communications",
                column: "WlanID",
                unique: true,
                filter: "[WlanID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Date_AnnouncedStatusID",
                table: "Date",
                column: "AnnouncedStatusID",
                unique: true,
                filter: "[AnnouncedStatusID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Date_ReleasedStatusID",
                table: "Date",
                column: "ReleasedStatusID",
                unique: true,
                filter: "[ReleasedStatusID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceColor_BuildID",
                table: "DeviceColor",
                column: "BuildID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_BasicID",
                table: "DeviceDetails",
                column: "BasicID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_BatteryID",
                table: "DeviceDetails",
                column: "BatteryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_BuildID",
                table: "DeviceDetails",
                column: "BuildID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_CameraInfoID",
                table: "DeviceDetails",
                column: "CameraInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_CommunicationID",
                table: "DeviceDetails",
                column: "CommunicationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_CpuID",
                table: "DeviceDetails",
                column: "CpuID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_DisplayID",
                table: "DeviceDetails",
                column: "DisplayID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_GpuID",
                table: "DeviceDetails",
                column: "GpuID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_MemoryID",
                table: "DeviceDetails",
                column: "MemoryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_OperatingSystemID",
                table: "DeviceDetails",
                column: "OperatingSystemID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_PriceID",
                table: "DeviceDetails",
                column: "PriceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDetails_StatusID",
                table: "DeviceDetails",
                column: "StatusID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dimension_BuildID",
                table: "Dimension",
                column: "BuildID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GpsFeature_GpsID",
                table: "GpsFeature",
                column: "GpsID");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_CommunicationID",
                table: "Sensor",
                column: "CommunicationID");

            migrationBuilder.CreateIndex(
                name: "IX_SimCard_CommunicationID",
                table: "SimCard",
                column: "CommunicationID");

            migrationBuilder.CreateIndex(
                name: "IX_UsbFeature_UsbID",
                table: "UsbFeature",
                column: "UsbID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoMode_CameraInfoID",
                table: "VideoMode",
                column: "CameraInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_WlanFeature_WlanID",
                table: "WlanFeature",
                column: "WlanID");

            migrationBuilder.CreateIndex(
                name: "IX_WlanStandard_WlanID",
                table: "WlanStandard",
                column: "WlanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CameraFeature");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "DeviceColor");

            migrationBuilder.DropTable(
                name: "DeviceDetails");

            migrationBuilder.DropTable(
                name: "Dimension");

            migrationBuilder.DropTable(
                name: "GpsFeature");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "SimCard");

            migrationBuilder.DropTable(
                name: "UsbFeature");

            migrationBuilder.DropTable(
                name: "VideoMode");

            migrationBuilder.DropTable(
                name: "WlanFeature");

            migrationBuilder.DropTable(
                name: "WlanStandard");

            migrationBuilder.DropTable(
                name: "Camera");

            migrationBuilder.DropTable(
                name: "Basics");

            migrationBuilder.DropTable(
                name: "Batteries");

            migrationBuilder.DropTable(
                name: "Cpus");

            migrationBuilder.DropTable(
                name: "Displays");

            migrationBuilder.DropTable(
                name: "Gpus");

            migrationBuilder.DropTable(
                name: "Memories");

            migrationBuilder.DropTable(
                name: "OperatingSystems");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Builds");

            migrationBuilder.DropTable(
                name: "Communications");

            migrationBuilder.DropTable(
                name: "CameraInfos");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Gps");

            migrationBuilder.DropTable(
                name: "Usb");

            migrationBuilder.DropTable(
                name: "Wlan");
        }
    }
}
