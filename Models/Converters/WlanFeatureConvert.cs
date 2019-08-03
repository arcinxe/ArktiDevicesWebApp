using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class WlanFeatureConvert : IConverter<WlanFeature, WlanFeatureDefault> {
    public WlanFeatureDefault Convert(WlanFeature sourceObject) {
        var result = new WlanFeatureDefault() {
            Name = sourceObject.Name
        };

        return result;
    }

    public WlanFeature Convert(WlanFeatureDefault sourceObject) {
        var result = new WlanFeature() {
            Name = sourceObject.Name
        };

        return result;
    }
}
