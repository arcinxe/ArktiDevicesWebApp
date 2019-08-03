using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class UsbFeatureConvert : IConverter<UsbFeature, UsbFeatureDefault> {
    public UsbFeatureDefault Convert(UsbFeature sourceObject) {
        var result = new UsbFeatureDefault() {
            Name = sourceObject.Name
        };

        return result;
    }

    public UsbFeature Convert(UsbFeatureDefault sourceObject) {
        var result = new UsbFeature() {
            Name = sourceObject.Name
        };

        return result;
    }
}
