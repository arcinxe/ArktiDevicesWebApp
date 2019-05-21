using System.Collections.Generic;
using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class CommunicationConvert : IConverter<Communication, CommunicationDefault> {
    public CommunicationDefault Convert(Communication sourceObject) {
        var result = new CommunicationDefault() {
            Bluetooth = sourceObject.Bluetooth,
            AudioJack = sourceObject.AudioJack,
            Infrared = sourceObject.Infrared,
            Nfc = sourceObject.Nfc,
            Usb = new UsbConvert().Convert(sourceObject.Usb),
            Gps = new GpsConvert().Convert(sourceObject.Gps),
            Wlan = new WlanConvert().Convert(sourceObject.Wlan),
            SimCards = sourceObject.SimCards.Select(f => new SimCardConvert().Convert(f)).ToList(),
            Sensors = sourceObject.Sensors.Select(f => new SensorConvert().Convert(f)).ToList()
        };

        return result;
    }

    public Communication Convert(CommunicationDefault sourceObject) {
        var result = new Communication() {
            Bluetooth = sourceObject.Bluetooth,
            AudioJack = sourceObject.AudioJack,
            Infrared = sourceObject.Infrared,
            Nfc = sourceObject.Nfc,
            Usb = new UsbConvert().Convert(sourceObject.Usb),
            Gps = new GpsConvert().Convert(sourceObject.Gps),
            Wlan = new WlanConvert().Convert(sourceObject.Wlan),
            SimCards = sourceObject.SimCards != null? sourceObject.SimCards.Select(f => new SimCardConvert().Convert(f)).ToList() : new List<SimCard>(),
            Sensors = sourceObject.Sensors.Select(f => new SensorConvert().Convert(f)).ToList()
        };

        return result;
    }
}
