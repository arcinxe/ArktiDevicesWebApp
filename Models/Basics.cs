namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Basic {
        public int BasicID { get; set; }
        public int GsmArenaNumber { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string DeviceType { get; set; }
        public int DeviceDetailID { get; set; }
        public virtual DeviceDetail DeviceDetail { get; set; }
    }

    // Used locally in application
    public class BasicDefault {
        public int GsmArenaNumber { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string DeviceType { get; set; }
    }
}