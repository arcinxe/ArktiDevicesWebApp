using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
using ArktiDevicesWebApp;

public class DevicesFilter {
    private IQueryable<DeviceDetail> _devices;
    private Dictionary<char, string> _deviceTypesAbbr = new Dictionary<char, string>();
    public DevicesFilter(IQueryable<DeviceDetail> devices) {
        _devices = devices;
        _deviceTypesAbbr.Add('p', "phone");
        _deviceTypesAbbr.Add('s', "smartphone");
        _deviceTypesAbbr.Add('t', "tablet");
        _deviceTypesAbbr.Add('w', "smartwatch");
    }

    public IQueryable<DeviceDetail> Filter(string brandsIdsWithComas, string deviceTypesAbbr, int? startYear, int? endYear) {
        var allDevices = _devices
            .Where(p => p.Status.ReleasedDate.Year != null &&
                p.Status.ReleasedDate.Year >= startYear &&
                p.Status.ReleasedDate.Year <= (endYear == 0 ? 3000 : endYear));

        if (!string.IsNullOrWhiteSpace(brandsIdsWithComas) && brandsIdsWithComas != "0") {
            var brandsIds = brandsIdsWithComas
                .Split(',')
                .Select(id => int.Parse(id));
            var brands = Constants.Brands
                .Where(b => brandsIds.Contains(b.ID))
                .Select(b => b.Name);
            var filteredDevices = allDevices.Where(d => brands.Contains(d.Brand));
            allDevices = filteredDevices;
        }
        if (!string.IsNullOrWhiteSpace(deviceTypesAbbr)) {
            var types = deviceTypesAbbr.ToArray();
            var deviceTypes = types.Where(k => _deviceTypesAbbr.ContainsKey(k)).Select(k => _deviceTypesAbbr[k]);
            var filteredDevices = allDevices.Where(d => deviceTypes.Contains(d.Basic.DeviceType));
            allDevices = filteredDevices;
        } else
            return new List<DeviceDetail>().AsQueryable();

        return allDevices;
    }
}
