using System.Collections.Generic;

namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Gpu {
        public int GpuID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int DeviceDetailID { get; set; }

        public virtual DeviceDetail DeviceDetail { get; set; }
    }

    // Used locally in application
    public class GpuDefault {
        public string Name { get; set; }
        public string Model { get; set; }
    }
}