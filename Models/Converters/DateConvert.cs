using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class DateConvert : IConverter<Date, DateDefault> {
    public DateDefault Convert(Date sourceObject) {
        var result = new DateDefault() {
            Year = sourceObject.Year,
            Quarter = sourceObject.Quarter,
            Month = sourceObject.Month
        };

        return result;
    }

    public Date Convert(DateDefault sourceObject) {
        var result = new Date() {
            Year = sourceObject.Year,
            Quarter = sourceObject.Quarter,
            Month = sourceObject.Month
        };

        return result;
    }
}
