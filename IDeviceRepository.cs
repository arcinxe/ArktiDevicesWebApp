using System.Collections.Generic;
using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
namespace ArktiPhonesDatabaseUploader
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