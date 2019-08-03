using System.Collections.Generic;
using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
namespace ArktiDevicesDatabaseUploader
{
    interface IDeviceRepository
    {
        IQueryable<DeviceDetail> GetDevices();
        DeviceDetail AddDevice(DeviceDetail device);
        IEnumerable<Models.DeviceDetail> AddDevices(IEnumerable<Models.DeviceDetail> devices);
        void RemoveDevice(int id);
        void UpdateDevice(int id, DeviceDetail device);
    }
}