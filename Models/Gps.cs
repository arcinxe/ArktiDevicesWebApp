using System.Collections.Generic;

namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Gps {
        public int GpsID { get; set; }
        public bool? Available { get; set; }
        public virtual ICollection<GpsFeature> Features { get; set; }

        // public int CommunicationID { get; set; }
        public virtual Communication Communication { get; set; }
    }

    // Used locally in application and for noSQL databases
    public class GpsDefault {
        public ICollection<GpsFeatureDefault> Features { get; set; }
        public bool? Available { get; set; }
    }
}