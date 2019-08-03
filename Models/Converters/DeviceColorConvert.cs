using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class DeviceColorConvert : IConverter<DeviceColor, DeviceColorDefault> {
    public DeviceColorDefault Convert (DeviceColor sourceObject) {
        var result = new DeviceColorDefault () {
            Name = sourceObject.Name
        };

        return result;
    }

    public DeviceColor Convert (DeviceColorDefault sourceObject) {
        var result = new DeviceColor () {
            Name = sourceObject.Name
        };

        return result;
    }
}
