using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class BasicConvert : IConverter<Basic, BasicDefault> {
    public BasicDefault Convert(Basic sourceObject) {
        var result = new BasicDefault() {
            DeviceType = sourceObject.DeviceType,
            GsmArenaNumber = sourceObject.GsmArenaNumber,
            ImageUrl = sourceObject.ImageUrl,
            Slug = sourceObject.Slug
        };

        return result;
    }

    public Basic Convert(BasicDefault sourceObject) {
        var result = new Basic() {
            DeviceType = sourceObject.DeviceType,
            GsmArenaNumber = sourceObject.GsmArenaNumber,
            ImageUrl = sourceObject.ImageUrl,
            Slug = sourceObject.Slug
        };

        return result;
    }
}
