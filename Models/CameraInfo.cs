using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class CameraInfo {
        public int CameraInfoID { get; set; }
        public double? PhotoResolution { get; set; }
        public int? VideoResolution { get; set; }
        public int? FrontCameraLeds { get; set; }
        public int? RearCameraLeds { get; set; }
        public string CameraOriginalText { get; set; }
        public virtual ICollection<VideoMode> VideoModes { get; set; }

        [InverseProperty ("VideoFeature")]
        public virtual ICollection<CameraFeature> VideoFeatures { get; set; }

        [InverseProperty ("RearCameraFeature")]
        public virtual ICollection<CameraFeature> RearCameraFeatures { get; set; }

        [InverseProperty ("FrontCameraFeature")]
        public virtual ICollection<CameraFeature> FrontCameraFeatures { get; set; }

        public virtual ICollection<Camera> Cameras { get; set; }

        public int DeviceDetailID { get; set; }
        public virtual DeviceDetail DeviceDetail { get; set; }
    }

    // Used locally in application
    public class CameraInfoDefault {
        public double? PhotoResolution { get; set; }
        public int? VideoResolution { get; set; }
        public int? FrontCameraLeds { get; set; }
        public int? RearCameraLeds { get; set; }
        public string CameraOriginalText { get; set; }
        public ICollection<VideoModeDefault> VideoModes { get; set; }
        public ICollection<CameraFeatureDefault> VideoFeatures { get; set; }
        public ICollection<CameraFeatureDefault> RearCameraFeatures { get; set; }
        public ICollection<CameraFeatureDefault> FrontCameraFeatures { get; set; }
        public ICollection<CameraDefault> Cameras { get; set; }

    }
}