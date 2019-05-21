using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class BuildConvert : IConverter<Build, BuildDefault> {
    public BuildDefault Convert(Build sourceObject) {
        var result = new BuildDefault() {
            Weight = sourceObject.Weight,
            Dimension = new DimensionConvert().Convert(sourceObject.Dimension),
            Material = new MaterialConvert().Convert(sourceObject.Material),
            Colors = sourceObject.Colors.Select(c => new DeviceColorConvert().Convert(c)).ToList()
        };

        return result;
    }

    public Build Convert(BuildDefault sourceObject) {
        var result = new Build() {
            Weight = sourceObject.Weight,
            Dimension = new DimensionConvert().Convert(sourceObject.Dimension),
            Material = new MaterialConvert().Convert(sourceObject.Material),
            Colors = sourceObject.Colors.Select(c => new DeviceColorConvert().Convert(c)).ToList()
        };

        return result;
    }
}
