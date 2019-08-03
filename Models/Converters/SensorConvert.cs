using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class SensorConvert : IConverter<Sensor, SensorDefault> {
    public SensorDefault Convert(Sensor sourceObject) {
        var result = new SensorDefault() {
            Name = sourceObject.Name
        };

        return result;
    }

    public Sensor Convert(SensorDefault sourceObject) {
        var result = new Sensor() {
            Name = sourceObject.Name
        };

        return result;
    }
}
