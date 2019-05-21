namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Dimension {
        public int DimensionID { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Thickness { get; set; }
        public double? Volume { get; set; }
        public int BuildID { get; set; }
        public virtual Build Build { get; set; }
    }

    // Used locally in application
    public class DimensionDefault {
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Thickness { get; set; }
        public double? Volume { get; set; }
    }
}