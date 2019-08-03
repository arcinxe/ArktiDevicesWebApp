namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Memory {
        public int MemoryID { get; set; }
        public string CardType { get; set; }
        public int? CardMaxSize { get; set; }
        public int? Internal { get; set; }
        public int? ReadOnly { get; set; }
        public int? RandomAccess { get; set; }
        public int DeviceDetailID { get; set; }
        public virtual DeviceDetail DeviceDetail { get; set; }
    }

    // Used locally in application
    public class MemoryDefault {
        public string CardType { get; set; }
        public int? CardMaxSize { get; set; }
        public int? Internal { get; set; }
        public int? ReadOnly { get; set; }
        public int? RandomAccess { get; set; }
    }
}