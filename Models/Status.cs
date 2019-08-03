using System.ComponentModel.DataAnnotations.Schema;

namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Status {
        public int StatusID { get; set; }
        // public int AnnouncedDateID { get; set; }
        // public int ReleasedDateID { get; set; }

        public string CurrentStatus { get; set; }

        public string DatesOriginalText { get; set; }
        // [InverseProperty("AnnouncedStatus")]

        // [ForeignKey("AnnouncedDateID")]
        public virtual Date AnnouncedDate { get; set; }

        // [InverseProperty("ReleasedStatus")]
        // [ForeignKey("ReleasedDateID")]
        public virtual Date ReleasedDate { get; set; }
        public int DeviceDetailID { get; set; }
        public virtual DeviceDetail DeviceDetail { get; set; }
    }

    // Used locally in application
    public class StatusDefault {

        public string CurrentStatus { get; set; }

        public string DatesOriginalText { get; set; }
        public virtual DateDefault AnnouncedDate { get; set; }
        public virtual DateDefault ReleasedDate { get; set; }
    }
}