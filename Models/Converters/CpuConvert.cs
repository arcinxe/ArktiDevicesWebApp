using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class CpuConvert : IConverter<Cpu, CpuDefault> {
    public CpuDefault Convert(Cpu sourceObject) {
        var result = new CpuDefault() {
            Producer = sourceObject.Producer,
            Name = sourceObject.Name,
            Series = sourceObject.Series,
            Model = sourceObject.Model,
            Cores = sourceObject.Cores
        };

        return result;
    }

    public Cpu Convert(CpuDefault sourceObject) {
        var result = new Cpu() {
            Producer = sourceObject.Producer,
            Name = sourceObject.Name,
            Series = sourceObject.Series,
            Model = sourceObject.Model,
            Cores = sourceObject.Cores
        };

        return result;
    }
}
