using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class OperatingSystemConvert : IConverter<OperatingSystem, OperatingSystemDefault> {
    public OperatingSystemDefault Convert(OperatingSystem sourceObject) {
        var result = new OperatingSystemDefault() {
            Name = sourceObject.Name,
            Version = sourceObject.Version,
            VersionName = sourceObject.VersionName,
            LatestVersion = sourceObject.LatestVersion,
            FlavorName = sourceObject.FlavorName,
            FlavorVersion = sourceObject.FlavorVersion
        };

        return result;
    }

    public OperatingSystem Convert(OperatingSystemDefault sourceObject) {
        var result = new OperatingSystem() {
            Name = sourceObject.Name,
            Version = sourceObject.Version,
            VersionName = sourceObject.VersionName,
            LatestVersion = sourceObject.LatestVersion,
            FlavorName = sourceObject.FlavorName,
            FlavorVersion = sourceObject.FlavorVersion
        };

        return result;
    }
}
