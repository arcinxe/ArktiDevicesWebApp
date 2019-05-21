using System.Collections.Generic;

namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class DeviceColor {
        public int DeviceColorID { get; set; }
        public string Name { get; set; }

        public int BuildID { get; set; }
        public virtual Build Build { get; set; }
    }

    // Used locally in application
    public class DeviceColorDefault {
        public string Name { get; set; }

    }
}