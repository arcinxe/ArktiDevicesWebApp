using System.Collections.Generic;

namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class GpsFeature {
        public int GpsFeatureID { get; set; }
        public string Name { get; set; }

        public int GpsID { get; set; }
        public virtual Gps Gps { get; set; }
    }

    // Used locally in application
    public class GpsFeatureDefault {
        public string Name { get; set; }

    }
}