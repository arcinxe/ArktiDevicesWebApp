using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class VideoModeConvert : IConverter<VideoMode, VideoModeDefault> {
    public VideoModeDefault Convert(VideoMode sourceObject) {
        var result = new VideoModeDefault() {
            CameraSide = sourceObject.CameraSide,
            FrameRate = sourceObject.FrameRate,
            Height = sourceObject.Height,
            Width = sourceObject.Width
        };
        return result;
    }

    public VideoMode Convert(VideoModeDefault sourceObject) {
        var result = new VideoMode() {
            CameraSide = sourceObject.CameraSide,
            FrameRate = sourceObject.FrameRate,
            Height = sourceObject.Height,
            Width = sourceObject.Width
        };
        return result;
    }
}
