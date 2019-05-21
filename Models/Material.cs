namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Material {
        public int MaterialID { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public string Frame { get; set; }
        public string Body { get; set; }
        // public int BuildID { get; set; }
        public virtual Build Build { get; set; }
    }

    // Used locally in application
    public class MaterialDefault {
        public string Front { get; set; }
        public string Back { get; set; }
        public string Frame { get; set; }
        public string Body { get; set; }
    }
}