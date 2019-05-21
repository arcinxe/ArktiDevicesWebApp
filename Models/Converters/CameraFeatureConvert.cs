using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class CameraFeatureConvert : IConverter<CameraFeature, CameraFeatureDefault> {
    public CameraFeatureDefault Convert(CameraFeature sourceObject) {
        var result = new CameraFeatureDefault() {
            Name = sourceObject.Name
        };

        return result;
    }

    public CameraFeature Convert(CameraFeatureDefault sourceObject) {
        var result = new CameraFeature() {
            Name = sourceObject.Name
        };

        return result;
    }
}
