using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class SimCardConvert : IConverter<SimCard, SimCardDefault> {
    public SimCardDefault Convert(SimCard sourceObject) {
        var result = new SimCardDefault() {
            Type = sourceObject.Type
        };

        return result;
    }

    public SimCard Convert(SimCardDefault sourceObject) {
        var result = new SimCard() {
            Type = sourceObject.Type
        };

        return result;
    }
}
