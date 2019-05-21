using System.Collections.Generic;

namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Sensor {
        public int SensorID { get; set; }
        public string Name { get; set; }

        public int CommunicationID { get; set; }
        public virtual Communication Communication { get; set; }
    }

    // Used locally in application
    public class SensorDefault {
        public string Name { get; set; }

    }
}