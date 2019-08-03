namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Battery {
        public int BatteryID { get; set; }

        public int? Capacity { get; set; }
        public string Technology { get; set; }
        public int? Endurance { get; set; }
        public int DeviceDetailID { get; set; }
        public virtual DeviceDetail DeviceDetail { get; set; }
    }

    // Used locally in application
    public class BatteryDefault {

        public int? Capacity { get; set; }
        public string Technology { get; set; }
        public int? Endurance { get; set; }
    }
}