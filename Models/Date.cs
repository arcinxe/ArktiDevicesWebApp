using System.ComponentModel.DataAnnotations.Schema;

namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Date {
        public int DateID { get; set; }

        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Quarter { get; set; }
        public int? AnnouncedStatusID { get; set; }
        public int? ReleasedStatusID { get; set; }

        [ForeignKey ("AnnouncedStatusID")]
        [InverseProperty ("AnnouncedDate")]
        public virtual Status AnnouncedStatus { get; set; }

        [ForeignKey ("ReleasedStatusID")]
        [InverseProperty ("ReleasedDate")]
        public virtual Status ReleasedStatus { get; set; }
    }

    // Used locally in application
    public class DateDefault {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Quarter { get; set; }
    }
}