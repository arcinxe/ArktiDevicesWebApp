using System.Collections.Generic;

namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class CameraFeature {
        public int CameraFeatureID { get; set; }

        public string Name { get; set; }
        // public int CameraInfoID { get; set; }
        // public virtual CameraInfo CameraInfo { get; set; }
        public int? CameraID { get; set; }
        public virtual Camera Camera { get; set; }
        public int? VideoFeatureID { get; set; }
        public virtual CameraInfo VideoFeature { get; set; }
        public int? RearCameraFeatureID { get; set; }
        public virtual CameraInfo RearCameraFeature { get; set; }
        public int? FrontCameraFeatureID { get; set; }
        public virtual CameraInfo FrontCameraFeature { get; set; }
    }

    // Used locally in application
    public class CameraFeatureDefault {
        public string Name { get; set; }

    }

    public class CertainCameraFeature {
        public int CertainCameraFeatureID { get; set; }
        public string Name { get; set; }

        public int CameraID { get; set; }
        public virtual Camera Camera { get; set; }
    }
}