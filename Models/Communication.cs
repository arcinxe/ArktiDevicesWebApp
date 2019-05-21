using System.Collections.Generic;

namespace ArktiPhonesDatabaseUploader.Models {

    // Used to work with SQL databases
    public class Communication {
        public int CommunicationID { get; set; }
        public bool? AudioJack { get; set; }
        public string Bluetooth { get; set; }
        public bool Infrared { get; set; }
        public bool Nfc { get; set; }
        public int? GpsID { get; set; }
        public int? UsbID { get; set; }
        public int? WlanID { get; set; }
        public virtual Gps Gps { get; set; }
        public virtual Usb Usb { get; set; }
        public virtual Wlan Wlan { get; set; }
        public virtual ICollection<SimCard> SimCards { get; set; }
        public virtual ICollection<Sensor> Sensors { get; set; }

        public int DeviceDetailID { get; set; }
        public virtual DeviceDetail DeviceDetail { get; set; }

        public Communication () {
            Gps = new Gps ();
            Usb = new Usb ();
            Wlan = new Wlan ();
        }
    }

    // Used locally in application
    public class CommunicationDefault {
        public bool? AudioJack { get; set; }
        public string Bluetooth { get; set; }
        public bool Infrared { get; set; }
        public bool Nfc { get; set; }
        public GpsDefault Gps { get; set; }
        public UsbDefault Usb { get; set; }
        public WlanDefault Wlan { get; set; }
        public ICollection<SimCardDefault> SimCards { get; set; }
        public ICollection<SensorDefault> Sensors { get; set; }

        public CommunicationDefault () {
            Gps = new GpsDefault ();
            Usb = new UsbDefault ();
            Wlan = new WlanDefault ();
        }
    }
}