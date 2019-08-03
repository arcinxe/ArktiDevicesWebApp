using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class GpsFeatureConvert : IConverter<GpsFeature, GpsFeatureDefault> {
    public GpsFeatureDefault Convert(GpsFeature sourceObject) {
        var result = new GpsFeatureDefault() {
            Name = sourceObject.Name
        };

        return result;
    }

    public GpsFeature Convert(GpsFeatureDefault sourceObject) {
        var result = new GpsFeature() {
            Name = sourceObject.Name
        };

        return result;
    }
}
