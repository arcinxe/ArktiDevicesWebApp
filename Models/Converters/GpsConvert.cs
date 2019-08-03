using System.Collections.Generic;
using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class GpsConvert : IConverter<Gps, GpsDefault> {
    public GpsDefault Convert(Gps sourceObject) {
        var result = new GpsDefault() {
            Available = sourceObject.Available,
            Features = sourceObject.Features.Select(f => new GpsFeatureConvert().Convert(f)).ToList(),
        };

        return result;
    }

    public Gps Convert(GpsDefault sourceObject) {
        var result = new Gps() {
            Available = sourceObject.Available,
            Features = sourceObject.Features != null?sourceObject.Features.Select(f => new GpsFeatureConvert().Convert(f)).ToList() : new List<GpsFeature>(),
        };

        return result;
    }
}
