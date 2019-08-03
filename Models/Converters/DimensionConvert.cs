using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class DimensionConvert : IConverter<Dimension, DimensionDefault> {
    public DimensionDefault Convert (Dimension sourceObject) {
        var result = new DimensionDefault () {
            Height = sourceObject.Height,
            Width = sourceObject.Height,
            Thickness = sourceObject.Thickness,
            Volume = sourceObject.Volume
        };

        return result;
    }

    public Dimension Convert (DimensionDefault sourceObject) {
        var result = new Dimension () {
            Height = sourceObject.Height,
            Width = sourceObject.Height,
            Thickness = sourceObject.Thickness,
            Volume = sourceObject.Volume
        };

        return result;
    }
}
