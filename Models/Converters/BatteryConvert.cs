using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class BatteryConvert : IConverter<Battery, BatteryDefault> {
    public BatteryDefault Convert(Battery sourceObject) {
        var result = new BatteryDefault() {
            Capacity = sourceObject.Capacity,
            Technology = sourceObject.Technology,
            Endurance = sourceObject.Endurance
        };

        return result;
    }

    public Battery Convert(BatteryDefault sourceObject) {
        var result = new Battery() {
            Capacity = sourceObject.Capacity,
            Technology = sourceObject.Technology,
            Endurance = sourceObject.Endurance
        };

        return result;
    }
}
