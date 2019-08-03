using System.Collections.Generic;

namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class WlanStandard {
        public int WlanStandardID { get; set; }
        public string Name { get; set; }

        public int WlanID { get; set; }
        public virtual Wlan Wlan { get; set; }
    }

    // Used locally in application
    public class WlanStandardDefault {
        public string Name { get; set; }

    }
}