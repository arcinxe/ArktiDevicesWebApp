using System.Collections.Generic;

namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Camera {
        public int CameraID { get; set; }
        public int CameraInfoID { get; set; }
        public string Location { get; set; }
        public double? Resolution { get; set; }
        public int? OpticalZoom { get; set; }
        public double? SensorSize { get; set; } // 1/x.xx"
        public double? FocalLength { get; set; } // x.xx mm
        public double? Aperture { get; set; } // f/x.xx
        public virtual CameraInfo CameraInfo { get; set; }
        public virtual ICollection<CameraFeature> Features { get; set; }
    }

    // Used locally in application
    public class CameraDefault {
        public string Location { get; set; }
        public double? Resolution { get; set; }
        public int? OpticalZoom { get; set; }
        public double? SensorSize { get; set; } // 1/x.xx"
        public double? FocalLength { get; set; } // x.xx mm
        public double? Aperture { get; set; } // f/x.xx
        public ICollection<CameraFeatureDefault> Features { get; set; }
    }
}