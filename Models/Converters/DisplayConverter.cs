using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class DisplayConvert : IConverter<Display, DisplayDefault> {
    public DisplayDefault Convert(Display sourceObject) {
        var result = new DisplayDefault() {
            ResolutionWidth = sourceObject.ResolutionWidth,
            ResolutionHeight = sourceObject.ResolutionHeight,
            ResolutionLines = sourceObject.ResolutionLines,
            PixelDensity = sourceObject.PixelDensity,
            WidthRatio = sourceObject.WidthRatio,
            HeightRatio = sourceObject.HeightRatio,
            Diagonal = sourceObject.Diagonal,
            Area = sourceObject.Area,
            ScreenToBodyRatio = sourceObject.ScreenToBodyRatio,
            Type = sourceObject.Type,
            ColorMode = sourceObject.ColorMode,
            Colors = sourceObject.Colors,
            EffectiveColors = sourceObject.EffectiveColors,
            Touchscreen = sourceObject.Touchscreen
        };

        return result;
    }

    public Display Convert(DisplayDefault sourceObject) {
        var result = new Display() {
            ResolutionWidth = sourceObject.ResolutionWidth,
            ResolutionHeight = sourceObject.ResolutionHeight,
            ResolutionLines = sourceObject.ResolutionLines,
            PixelDensity = sourceObject.PixelDensity,
            WidthRatio = sourceObject.WidthRatio,
            HeightRatio = sourceObject.HeightRatio,
            Diagonal = sourceObject.Diagonal,
            Area = sourceObject.Area,
            ScreenToBodyRatio = sourceObject.ScreenToBodyRatio,
            Type = sourceObject.Type,
            ColorMode = sourceObject.ColorMode,
            Colors = sourceObject.Colors,
            EffectiveColors = sourceObject.EffectiveColors,
            Touchscreen = sourceObject.Touchscreen
        };

        return result;
    }
}
