namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Price {
        public int PriceID { get; set; }
        public double? Value { get; set; }
        public string Currency { get; set; }
        public double? EstimatedInEuro { get; set; }
        public int DeviceDetailID { get; set; }
        public virtual DeviceDetail DeviceDetail { get; set; }
    }

    // Used locally in application
    public class PriceDefault {
        public double? Value { get; set; }
        public string Currency { get; set; }
        public double? EstimatedInEuro { get; set; }
    }
}