using System.Collections.Generic;

namespace ArktiDevicesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class VideoMode {
        public int VideoModeID { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? FrameRate { get; set; }
        public string CameraSide { get; set; }
        public int CameraInfoID { get; set; }
        public virtual CameraInfo CameraInfo { get; set; }
    }

    // Used locally in application
    public class VideoModeDefault {
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? FrameRate { get; set; }
        public string CameraSide { get; set; }
    }
}