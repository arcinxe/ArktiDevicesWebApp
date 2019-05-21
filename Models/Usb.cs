using System.Collections.Generic;

namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Usb {
        public int UsbID { get; set; }
        public string Version { get; set; }
        public string Connector { get; set; }
        public virtual ICollection<UsbFeature> Features { get; set; }

        // public int CommunicationID { get; set; }
        public virtual Communication Communication { get; set; }
    }

    // Used locally in application
    public class UsbDefault {
        public ICollection<UsbFeatureDefault> Features { get; set; }
        public string Version { get; set; }
        public string Connector { get; set; }
    }
}