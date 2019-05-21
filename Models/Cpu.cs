using System.Collections.Generic;

namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Cpu {
        public int CpuID { get; set; }

        public string Producer { get; set; }
        public string Name { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int? Cores { get; set; }
        public int DeviceDetailID { get; set; }

        public virtual DeviceDetail DeviceDetail { get; set; }
    }

    // Used locally in application
    public class CpuDefault {
        public string Producer { get; set; }
        public string Name { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int? Cores { get; set; }
    }
}