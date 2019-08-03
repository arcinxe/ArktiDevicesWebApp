using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class GpuConvert : IConverter<Gpu, GpuDefault> {
    public GpuDefault Convert(Gpu sourceObject) {
        var result = new GpuDefault() {
            Name = sourceObject.Name,
            Model = sourceObject.Model
        };

        return result;
    }

    public Gpu Convert(GpuDefault sourceObject) {
        var result = new Gpu() {
            Name = sourceObject.Name,
            Model = sourceObject.Model
        };

        return result;
    }
}
