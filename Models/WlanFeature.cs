using System.Collections.Generic;

namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class WlanFeature {
        public int WlanFeatureID { get; set; }
        public string Name { get; set; }

        public int WlanID { get; set; }
        public virtual Wlan Wlan { get; set; }

    }

    // Used locally in application
    public class WlanFeatureDefault {
        public string Name { get; set; }

    }
}