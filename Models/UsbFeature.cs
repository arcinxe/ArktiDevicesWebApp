using System.Collections.Generic;

namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class UsbFeature {
        public int UsbFeatureID { get; set; }
        public string Name { get; set; }
        public int UsbID { get; set; }
        public virtual Usb Usb { get; set; }
    }

    // Used locally in application
    public class UsbFeatureDefault {
        public string Name { get; set; }
    }
}