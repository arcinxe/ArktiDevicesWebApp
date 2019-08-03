using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class DeviceDetail {
        public int DeviceDetailID { get; set; }

        // public virtual int BasicID { get; set; }
        // public virtual int StatusID { get; set; }
        // public virtual int BatteryID { get; set; }
        // public virtual int DisplayID { get; set; }
        // public virtual int CommunicationID { get; set; }
        // public virtual int BuildID { get; set; }
        // public virtual int CameraInfoID { get; set; }
        // public virtual int MemoryID { get; set; }
        // public virtual int PriceID { get; set; }
        // public virtual int OperatingSystemID { get; set; }
        // public virtual int CpuID { get; set; }
        // public virtual int GpuID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public virtual Basic Basic { get; set; }
        public virtual Status Status { get; set; }
        public virtual Battery Battery { get; set; }
        public virtual Display Display { get; set; }
        public virtual Communication Communication { get; set; }
        public virtual Build Build { get; set; }
        public virtual CameraInfo CameraInfo { get; set; }
        public virtual Memory Memory { get; set; }
        public virtual Price Price { get; set; }
        public virtual OperatingSystem OperatingSystem { get; set; }
        public virtual Cpu Cpu { get; set; }
        public virtual Gpu Gpu { get; set; }
        // public DeviceDetail()
        // {
        //     Basic = new Basic();
        //     // Status = new Status ();
        //     // Battery = new Battery ();
        //     // Display = new Display ();
        //     // Communication = new Communication ();
        //     // Communication.Usb = new Usb ();
        //     // Communication.Wlan = new Wlan ();
        //     // Communication.Gps = new Gps ();
        //     // Build = new Build ();
        //     // Build.Dimension = new Dimension ();
        //     // Build.Material = new Material ();
        //     // CameraInfo = new CameraInfo ();
        //     // Memory = new Memory ();
        //     // Price = new Price ();
        //     // OperatingSystem = new OperatingSystem ();
        //     // Cpu = new Cpu ();
        //     // Gpu = new Gpu ();
        // }

    }

    // Used locally in application
    public class DeviceDetailDefault {
        public string Brand { get; set; }
        public string Name { get; set; }
        public virtual BasicDefault Basic { get; set; }
        public virtual StatusDefault Status { get; set; }
        public virtual BatteryDefault Battery { get; set; }
        public virtual DisplayDefault Display { get; set; }
        public virtual CommunicationDefault Communication { get; set; }
        public virtual BuildDefault Build { get; set; }
        public virtual CameraInfoDefault CameraInfo { get; set; }
        public virtual MemoryDefault Memory { get; set; }
        public virtual PriceDefault Price { get; set; }
        public virtual OperatingSystemDefault OperatingSystem { get; set; }
        public virtual CpuDefault Cpu { get; set; }
        public virtual GpuDefault Gpu { get; set; }

        public DeviceDetailDefault () {
            Basic = new BasicDefault ();
            Status = new StatusDefault ();
            Battery = new BatteryDefault ();
            Display = new DisplayDefault ();
            Communication = new CommunicationDefault ();
            Communication.Usb = new UsbDefault ();
            Communication.Wlan = new WlanDefault ();
            Communication.Gps = new GpsDefault ();
            Build = new BuildDefault ();
            Build.Dimension = new DimensionDefault ();
            Build.Material = new MaterialDefault ();
            CameraInfo = new CameraInfoDefault ();
            Memory = new MemoryDefault ();
            Price = new PriceDefault ();
            OperatingSystem = new OperatingSystemDefault ();
            Cpu = new CpuDefault ();
            Gpu = new GpuDefault ();
        }
    }

    // Used locally in application
    public class DeviceDetailsMongo : DeviceDetailDefault {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { get; set; }
        public DeviceDetailsMongo (DeviceDetailDefault device) {
            Basic = device.Basic;
            Status = device.Status;
            Battery = device.Battery;
            Display = device.Display;
            Communication = device.Communication;
            Build = device.Build;
            CameraInfo = device.CameraInfo;
            Memory = device.Memory;
            Price = device.Price;
            OperatingSystem = device.OperatingSystem;
            Cpu = device.Cpu;
            Gpu = device.Gpu;
        }
    }
}