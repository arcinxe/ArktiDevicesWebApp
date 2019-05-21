using System.Collections.Generic;

namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class SimCard {
        public int SimCardID { get; set; }
        public string Type { get; set; }

        public int CommunicationID { get; set; }
        public virtual Communication Communication { get; set; }
    }

    // Used locally in application
    public class SimCardDefault {
        public string Type { get; set; }

    }
}