using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class WlanStandardConvert : IConverter<WlanStandard, WlanStandardDefault> {
    public WlanStandardDefault Convert(WlanStandard sourceObject) {
        var result = new WlanStandardDefault() {
            Name = sourceObject.Name
        };

        return result;
    }

    public WlanStandard Convert(WlanStandardDefault sourceObject) {
        var result = new WlanStandard() {
            Name = sourceObject.Name
        };

        return result;
    }
}
