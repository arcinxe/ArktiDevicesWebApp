namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class OperatingSystem {
        public int OperatingSystemID { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string LatestVersion { get; set; }
        public string FlavorName { get; set; }
        public string FlavorVersion { get; set; }
        public int DeviceDetailID { get; set; }
        public virtual DeviceDetail DeviceDetail { get; set; }
    }

    // Used locally in application
    public class OperatingSystemDefault {
        public string Name { get; set; }
        public string Version { get; set; }
        public string LatestVersion { get; set; }
        public string FlavorName { get; set; }
        public string FlavorVersion { get; set; }
    }
}