using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class StatusConvert : IConverter<Status, StatusDefault> {
    public StatusDefault Convert(Status sourceObject) {
        var result = new StatusDefault() {
            CurrentStatus = sourceObject.CurrentStatus,
            AnnouncedDate = new DateConvert().Convert(sourceObject.AnnouncedDate),
            ReleasedDate = new DateConvert().Convert(sourceObject.ReleasedDate),
            DatesOriginalText = sourceObject.DatesOriginalText
        };

        return result;
    }

    public Status Convert(StatusDefault sourceObject) {
        var result = new Status() {
            CurrentStatus = sourceObject.CurrentStatus,
            AnnouncedDate = new DateConvert().Convert(sourceObject.AnnouncedDate),
            ReleasedDate = new DateConvert().Convert(sourceObject.ReleasedDate),
            DatesOriginalText = sourceObject.DatesOriginalText
        };

        return result;
    }
}
