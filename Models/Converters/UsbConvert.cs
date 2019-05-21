using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class UsbConvert : IConverter<Usb, UsbDefault> {
    public UsbDefault Convert(Usb sourceObject) {
        var result = new UsbDefault() {
            Version = sourceObject.Version,
            Connector = sourceObject.Connector,
            Features = sourceObject.Features.Select(f => new UsbFeatureConvert().Convert(f)).ToList()
        };

        return result;
    }

    public Usb Convert(UsbDefault sourceObject) {
        var result = new Usb() {
            Version = sourceObject.Version,
            Connector = sourceObject.Connector,
            Features = sourceObject.Features != null?sourceObject.Features.Select(f => new UsbFeatureConvert().Convert(f)).ToList() : new System.Collections.Generic.List<UsbFeature>()
        };

        return result;
    }
}
