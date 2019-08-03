using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class DeviceDetailConvert : IConverter<DeviceDetail, DeviceDetailDefault> {
    public DeviceDetailDefault Convert(DeviceDetail sourceObject) {
        var result = new DeviceDetailDefault();
        result.Name = sourceObject.Name;
        result.Brand = sourceObject.Brand;

        result.Basic = new BasicConvert().Convert(sourceObject.Basic);
        result.Build = new BuildConvert().Convert(sourceObject.Build);
        result.Battery = new BatteryConvert().Convert(sourceObject.Battery);
        result.Display = new DisplayConvert().Convert(sourceObject.Display);
        result.Cpu = new CpuConvert().Convert(sourceObject.Cpu);
        result.Gpu = new GpuConvert().Convert(sourceObject.Gpu);
        result.Memory = new MemoryConvert().Convert(sourceObject.Memory);
        result.OperatingSystem = new OperatingSystemConvert().Convert(sourceObject.OperatingSystem);
        result.Price = new PriceConvert().Convert(sourceObject.Price);
        result.Status = new StatusConvert().Convert(sourceObject.Status);
        result.Communication = new CommunicationConvert().Convert(sourceObject.Communication);
        result.CameraInfo = new CameraInfoConvert().Convert(sourceObject.CameraInfo);

        return result;
    }

    public DeviceDetail Convert(DeviceDetailDefault sourceObject) {
        var result = new DeviceDetail();
        result.Name = sourceObject.Name;
        result.Brand = sourceObject.Brand;

        result.Basic = new BasicConvert().Convert(sourceObject.Basic);
        result.Build = new BuildConvert().Convert(sourceObject.Build);
        result.Battery = new BatteryConvert().Convert(sourceObject.Battery);
        result.Display = new DisplayConvert().Convert(sourceObject.Display);
        result.Cpu = new CpuConvert().Convert(sourceObject.Cpu);
        result.Gpu = new GpuConvert().Convert(sourceObject.Gpu);
        result.Memory = new MemoryConvert().Convert(sourceObject.Memory);
        result.OperatingSystem = new OperatingSystemConvert().Convert(sourceObject.OperatingSystem);
        result.Price = new PriceConvert().Convert(sourceObject.Price);
        result.Status = new StatusConvert().Convert(sourceObject.Status);
        result.Communication = new CommunicationConvert().Convert(sourceObject.Communication);
        result.CameraInfo = new CameraInfoConvert().Convert(sourceObject.CameraInfo);

        return result;
    }
}
