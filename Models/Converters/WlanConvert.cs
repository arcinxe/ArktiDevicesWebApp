using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class WlanConvert : IConverter<Wlan, WlanDefault> {
    public WlanDefault Convert(Wlan sourceObject) {
        var result = new WlanDefault() {
            Available = sourceObject.Available,
            Features = sourceObject.Features.Select(f => new WlanFeatureConvert().Convert(f)).ToList(),
            Standards = sourceObject.Standards.Select(f => new WlanStandardConvert().Convert(f)).ToList()
        };

        return result;
    }

    public Wlan Convert(WlanDefault sourceObject) {
        var result = new Wlan() {
            Available = sourceObject.Available,
            Features = sourceObject.Features.Select(f => new WlanFeatureConvert().Convert(f)).ToList(),
            Standards = sourceObject.Standards.Select(f => new WlanStandardConvert().Convert(f)).ToList()
        };

        return result;
    }
}
