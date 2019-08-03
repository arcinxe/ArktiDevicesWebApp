using System.Collections.Generic;
using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class CameraInfoConvert : IConverter<CameraInfo, CameraInfoDefault> {
    public CameraInfoDefault Convert(CameraInfo sourceObject) {
        var result = new CameraInfoDefault() {
            PhotoResolution = sourceObject.PhotoResolution,
            VideoResolution = sourceObject.VideoResolution,
            FrontCameraLeds = sourceObject.FrontCameraLeds,
            RearCameraLeds = sourceObject.RearCameraLeds,
            CameraOriginalText = sourceObject.CameraOriginalText,
            VideoFeatures = sourceObject.VideoFeatures.Select(f => new CameraFeatureConvert().Convert(f)).ToList(),
            FrontCameraFeatures = sourceObject.FrontCameraFeatures.Select(f => new CameraFeatureConvert().Convert(f)).ToList(),
            RearCameraFeatures = sourceObject.RearCameraFeatures.Select(f => new CameraFeatureConvert().Convert(f)).ToList(),
            Cameras = sourceObject.Cameras.Select(f => new CameraConvert().Convert(f)).ToList(),
            VideoModes = sourceObject.VideoModes.Select(f => new VideoModeConvert().Convert(f)).ToList()
        };

        return result;
    }

    public CameraInfo Convert(CameraInfoDefault sourceObject) {
        var result = new CameraInfo() {
            PhotoResolution = sourceObject.PhotoResolution,
            VideoResolution = sourceObject.VideoResolution,
            FrontCameraLeds = sourceObject.FrontCameraLeds,
            RearCameraLeds = sourceObject.RearCameraLeds,
            CameraOriginalText = sourceObject.CameraOriginalText,
            VideoFeatures = sourceObject.VideoFeatures != null ? sourceObject.VideoFeatures.Select(f => new CameraFeatureConvert().Convert(f)).ToList() : new List<CameraFeature>(),
            FrontCameraFeatures = sourceObject.FrontCameraFeatures != null?sourceObject.FrontCameraFeatures.Select(f => new CameraFeatureConvert().Convert(f)).ToList() : new List<CameraFeature>(),
            RearCameraFeatures = sourceObject.RearCameraFeatures != null?sourceObject.RearCameraFeatures.Select(f => new CameraFeatureConvert().Convert(f)).ToList() : new List<CameraFeature>(),
            Cameras = sourceObject.Cameras != null?sourceObject.Cameras.Select(f => new CameraConvert().Convert(f)).ToList() : new List<Camera>(),
            VideoModes = sourceObject.VideoModes != null?sourceObject.VideoModes.Select(f => new VideoModeConvert().Convert(f)).ToList() : new List<VideoMode>()
        };

        return result;
    }
}
