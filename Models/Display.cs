namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Display {
        public int DisplayID { get; set; }
        public int? ResolutionWidth { get; set; }
        public int? ResolutionHeight { get; set; }
        public int? ResolutionLines { get; set; }
        public double? PixelDensity { get; set; }
        public double? WidthRatio { get; set; }
        public double? HeightRatio { get; set; }
        public double? Diagonal { get; set; }
        public double? Area { get; set; }
        public double? ScreenToBodyRatio { get; set; }
        public string Type { get; set; }
        public string ColorMode { get; set; }
        public int? Colors { get; set; }
        public int? EffectiveColors { get; set; }
        public string Touchscreen { get; set; }
        public int DeviceDetailID { get; set; }
        public virtual DeviceDetail DeviceDetail { get; set; }
    }

    // Used locally in application
    public class DisplayDefault {
        public int? ResolutionWidth { get; set; }
        public int? ResolutionHeight { get; set; }
        public int? ResolutionLines { get; set; }
        public double? PixelDensity { get; set; }
        public double? WidthRatio { get; set; }
        public double? HeightRatio { get; set; }
        public double? Diagonal { get; set; }
        public double? Area { get; set; }
        public double? ScreenToBodyRatio { get; set; }
        public string Type { get; set; }
        public string ColorMode { get; set; }
        public int? Colors { get; set; }
        public int? EffectiveColors { get; set; }
        public string Touchscreen { get; set; }
    }
}