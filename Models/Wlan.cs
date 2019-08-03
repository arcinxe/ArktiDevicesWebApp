using System.Collections.Generic;

namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Wlan {
        public int WlanID { get; set; }
        public bool? Available { get; set; }
        public virtual ICollection<WlanStandard> Standards { get; set; }
        public virtual ICollection<WlanFeature> Features { get; set; }

        // public int CommunicationID { get; set; }
        public virtual Communication Communication { get; set; }
    }

    // Used locally in application
    public class WlanDefault {
        public bool? Available { get; set; }

        public virtual ICollection<WlanStandardDefault> Standards { get; set; }
        public virtual ICollection<WlanFeatureDefault> Features { get; set; }
    }
}