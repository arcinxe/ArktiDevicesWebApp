using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class CameraConvert : IConverter<Camera, CameraDefault> {
    public CameraDefault Convert(Camera sourceObject) {
        var result = new CameraDefault() {
            Aperture = sourceObject.Aperture,
            FocalLength = sourceObject.FocalLength,
            Location = sourceObject.Location,
            OpticalZoom = sourceObject.OpticalZoom,
            Resolution = sourceObject.Resolution,
            SensorSize = sourceObject.SensorSize,
            Features = sourceObject.Features.Select(f => new CameraFeatureConvert().Convert(f)).ToList()
        };

        return result;
    }

    public Camera Convert(CameraDefault sourceObject) {
        var result = new Camera() {
            Aperture = sourceObject.Aperture,
            FocalLength = sourceObject.FocalLength,
            Location = sourceObject.Location,
            OpticalZoom = sourceObject.OpticalZoom,
            Resolution = sourceObject.Resolution,
            SensorSize = sourceObject.SensorSize,
            Features = sourceObject.Features.Select(f => new CameraFeatureConvert().Convert(f)).ToList()
        };

        return result;
    }
}
