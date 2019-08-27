using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ArktiDevicesDatabaseUploader;
using EntityFrameworkCore.Cacheable;
using Microsoft.AspNetCore.Mvc;

namespace ArktiDevicesWebApp.Controllers {
  [Route("api/[controller]")]
  public class DevicesDataController : Controller {
    IDeviceRepository _repo = new SqlDbRepository();
    DeviceContext _db = new DeviceContext();
    DevicesFilter _filter;

    public DevicesDataController() {
      _filter = new DevicesFilter(_repo.GetDevices());
    }

    [HttpGet("[action]")]
    public IEnumerable<ArktiDevicesDatabaseUploader.Models.DeviceDetail> DeviceDetails() {
      var devices = _repo.GetDevices().Take(10).ToList();
      //   var results = devices.Select(d => new DeviceDetailConvert().Convert(d)).ToList();
      return devices;
    }

    [HttpGet("[action]")]
    public object TestFilter(int? startYear = 0, int? endYear = 0, string brandsIds = "", string deviceTypes = "") {
      return _filter.Filter(brandsIds, deviceTypes, startYear, endYear)
        .Select(d => new { Name = d.Name, Brand = d.Brand, Type = d.Basic.DeviceType, ReleaseYear = d.Status.ReleasedDate.Year });
    }

    [HttpGet("[action]")]
    public string testing() {
      return "it seems to be working";
    }

    [HttpGet("[action]")]
    public object ChartTypes() {
      var ChartTypes = new List<ChartType>();
      return Constants.ChartTypes;
    }

    [HttpGet("[action]")]
    public object Brands() {
      return Constants.Brands;
    }

    [HttpGet("[action]")]
    public object GroupedBrands() {
      return Constants.GroupedBrands;
    }

    [HttpGet("[action]")]
    public object MiniJack(int startYear = 0, int endYear = 0, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, startYear, endYear);

      var data = allDevices
        .OrderByDescending(p => p.Status.ReleasedDate.Year)
        .Where(p => p.Communication.AudioJack.HasValue)
        .GroupBy(p => p.Status.ReleasedDate.Year)
        .Select(p => new {
          Year = p.Key.ToString(),
            Data = p
            .GroupBy(ph => ph.Communication.AudioJack)
            .Select(ph => new {
              Type = ph.Key.Value? "audio jack": "no audio jack",
                PhonesAmount = ph.Select(d => d.Basic.DeviceType).Count()
            })
        });
      return new { Data = data, unit = "" };
    }

    [HttpGet("[action]")]
    public object MiniJackDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      if (!string.IsNullOrWhiteSpace(value)) {
        var withJack = value.Equals("audio jack", StringComparison.OrdinalIgnoreCase);
        allDevices = allDevices.Where(ph => ph.Communication.AudioJack.HasValue && (!withJack ^ ph.Communication.AudioJack.Value));
      }
      var data = allDevices.Where(p => p.Status.ReleasedDate.Year == year)
        .OrderBy(ph => ph.Brand)
        .ThenBy(ph => ph.Name)
        .Select(ph => new { Name = ph.Name, Brand = ph.Brand, SpecificValue = ph.Communication.AudioJack, DeviceType = ph.Basic.DeviceType, Slug = ph.Basic.Slug })
        .ToList();
      return data;
    }

    [HttpGet("[action]")]
    public object Infrared(int startYear = 0, int endYear = 0, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, startYear, endYear);

      var data = allDevices
        .OrderByDescending(p => p.Status.ReleasedDate.Year)
        .GroupBy(p => p.Status.ReleasedDate.Year)
        .Select(p => new {
          Year = p.Key.ToString(),
            Data = p
            .GroupBy(ph => ph.Communication.Infrared)
            .Select(ph => new {
              Type = ph.Key? "infrared": "no infrared",
                PhonesAmount = ph.Select(d => d.Basic.DeviceType).Count()
            })
        });
      return new { Data = data, unit = "" };
    }

    [HttpGet("[action]")]
    public object InfraredDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      if (!string.IsNullOrWhiteSpace(value)) {
        var withInfrared = value.Equals("infrared", StringComparison.OrdinalIgnoreCase);
        allDevices = allDevices.Where(ph => !withInfrared ^ ph.Communication.Infrared);
      }
      var data = allDevices.Where(p => p.Status.ReleasedDate.Year == year)
        .OrderBy(ph => ph.Brand)
        .ThenBy(ph => ph.Name)
        .Select(ph => new { Name = ph.Name, Brand = ph.Brand, SpecificValue = ph.Communication.Infrared, DeviceType = ph.Basic.DeviceType, Slug = ph.Basic.Slug })
        .ToList();
      return data;
    }

    [HttpGet("[action]")]
    public object Types(int startYear = 0, int endYear = 0, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, startYear, endYear);

      var data = allDevices
        .OrderByDescending(p => p.Status.ReleasedDate.Year)
        .GroupBy(p => p.Status.ReleasedDate.Year)
        .Select(p => new {
          Year = p.Key.ToString(),
            Data = p
            .GroupBy(ph => ph.Basic.DeviceType)
            .Select(ph => new {
              Type = ph.Key == "phone" ? "cellphones" : (ph.Key == "smartwatch" ? "smartwatches" : ph.Key + "s"),
                PhonesAmount = ph.Select(d => d.Basic.DeviceType).Count()
            })
        });
      return new { Data = data, unit = "" };
    }

    [HttpGet("[action]")]
    public object TypesDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      var deviceType = value;
      if (!string.IsNullOrWhiteSpace(value)) {
        switch (value) {
          case "smartphones":
            deviceType = "smartphone";
            break;
          case "smartwatches":
            deviceType = "smartwatch";
            break;
          case "cellphones":
            deviceType = "phone";
            break;
          case "tablets":
            deviceType = "tablet";
            break;
        }

        allDevices = allDevices.Where(ph => ph.Basic.DeviceType == deviceType);
      }
      var data = allDevices.Where(p => p.Status.ReleasedDate.Year == year)
        .OrderBy(ph => ph.Brand)
        .ThenBy(ph => ph.Name)
        .Select(ph => new { Name = ph.Name, Brand = ph.Brand, SpecificValue = ph.Basic.DeviceType, DeviceType = ph.Basic.DeviceType, Slug = ph.Basic.Slug })
        .ToList();
      // var results = new { Year = year, Type = deviceType, devices = data };
      return data;
    }

    [HttpGet("[action]")]
    public object Ram(int startYear = 0, int endYear = 0, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, startYear, endYear);

      var data = allDevices
        .OrderBy(p => p.Status.ReleasedDate.Year)
        .GroupBy(p => p.Status.ReleasedDate.Year)
        .Select(p => new {
          Year = p.Key.ToString(),
            Data = p
            .Where(ph => ph.Memory.RandomAccess.HasValue)
            .GroupBy(ph => ph.Memory.RandomAccess > 1000 ? $"{ph.Memory.RandomAccess/1024}GB" : $"<1GB")
            .Select(ph => new {
              RamInMB = ph.Key,
                PhonesAmount = ph.Select(d => d.Memory.RandomAccess).Count()
            })
        })
        .Where(d => d.Data.Count() > 0)
        .Cacheable(TimeSpan.FromSeconds(60));
      return new { Data = data, unit = "M|GB" };
    }

    [HttpGet("[action]")]
    public object RamDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      if (!string.IsNullOrWhiteSpace(value)) {
        var regex = Regex.Match(value, @"^(\d+)GB");
        var size = regex.Success?regex.Groups[1].Value: "";
        var sizeNumber = int.TryParse(size, out int result) ? result * 1024 : 0;
        allDevices = allDevices.Where(p => p.Memory.RandomAccess.HasValue && (size == "" ? p.Memory.RandomAccess < 1000 : p.Memory.RandomAccess == sizeNumber));
      }
      var data = allDevices
        .Select(p => new { Name = p.Name, Brand = p.Brand, SpecificValue = p.Memory.RandomAccess, DeviceType = p.Basic.DeviceType, Slug = p.Basic.Slug })
        .OrderBy(p => p.Brand).ThenBy(p => p.SpecificValue)
        .ToList();
      return data;
    }

    [HttpGet("[action]")]
    public object ScreenDensity(int startYear = 0, int endYear = 0, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, startYear, endYear);

      var data = allDevices
        .OrderBy(p => p.Status.ReleasedDate.Year)
        .GroupBy(p => p.Status.ReleasedDate.Year)
        .Select(p => new {
          Year = p.Key.ToString(),
            Data = p
            .Where(ph => ph.Display.PixelDensity.HasValue)
            .GroupBy(ph => (int) ph.Display.PixelDensity / 100)
            .Select(ph => new {
              PixelsPerInchOver100 = ph.Key > 0 ? ph.Key.ToString() + "00 ppi" : "<100 ppi",
                PhonesAmount = ph.Select(d => d.Memory.RandomAccess).Count(),
                // Phones = ph.Select(d => d.Name)
            })
        })
        .Where(d => d.Data.Count() > 0)
        .Cacheable(TimeSpan.FromSeconds(60));
      return new { Data = data, unit = " ppi" };
    }

    [HttpGet("[action]")]
    public object ScreenDensityDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      if (!string.IsNullOrWhiteSpace(value)) {
        var least = value.Contains("<");

        var density = least?0 : int.Parse(value.Remove(value.Length - 4, 4));
        var upperDensity = density + 99;
        allDevices = allDevices.Where(p => p.Display.PixelDensity.HasValue && p.Display.PixelDensity >= density && p.Display.PixelDensity < upperDensity);
      }
      var data = allDevices
        .Select(p => new { Name = p.Name, Brand = p.Brand, SpecificValue = p.Display.PixelDensity, DeviceType = p.Basic.DeviceType, Slug = p.Basic.Slug })
        .OrderBy(p => p.Brand).ThenBy(p => p.SpecificValue)
        .ToList();
      return data;
    }

    [HttpGet("[action]")]
    public object ScreenDiagonal(int startYear = 0, int endYear = 0, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, startYear, endYear);

      var data = allDevices
        .Where(p => p.Status.ReleasedDate.Year != null)
        .OrderByDescending(p => p.Status.ReleasedDate.Year)
        .GroupBy(p => p.Status.ReleasedDate.Year)
        .Select(p => new {
          Year = p.Key.ToString(),
            Data = p
            .Where(ph => ph.Display.Diagonal.HasValue)
            .GroupBy(ph => (int) ph.Display.Diagonal < 1 ? "<1\"" : (int) ph.Display.Diagonal + "\"")
            .Select(ph => new {
              Diagonal = ph.Key,
                PhonesAmount = ph.Select(d => d.Display.Diagonal).Count(),
            })
        })
        .Where(d => d.Data.Count() > 0)
        .Cacheable(TimeSpan.FromSeconds(60));
      return new { Data = data, unit = "\"" };
    }

    [HttpGet("[action]")]
    public object ScreenDiagonalDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      if (!string.IsNullOrWhiteSpace(value)) {
        var least = value.Contains("<");

        var diagonal = least?0 : int.Parse(value.Remove(value.Length - 1, 1));
        allDevices = allDevices.Where(p => p.Display.Diagonal >= diagonal && p.Display.Diagonal < diagonal + 1);
      }
      var data = allDevices
        .Select(p => new { Name = p.Name, Brand = p.Brand, SpecificValue = p.Display.Diagonal, DeviceType = p.Basic.DeviceType, Slug = p.Basic.Slug })
        .OrderBy(p => p.Brand).ThenBy(p => p.SpecificValue)
        .ToList();
      return data;
    }

    [HttpGet("[action]")]
    public object AndroidVersion(int startYear = 0, int endYear = 0, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, startYear, endYear);

      var data = allDevices
        .Where(p => p.Status.ReleasedDate.Year != null)
        .OrderByDescending(p => p.Status.ReleasedDate.Year)
        .GroupBy(p => p.Status.ReleasedDate.Year)
        .Select(p => new {
          Year = p.Key.ToString(),
            Data = p
            .Where(ph => ph.OperatingSystem.Version != null && ph.OperatingSystem.Name == "android")
            .GroupBy(ph => ph.OperatingSystem.VersionName)
            .Select(ph => new {
              value = ph.Key,
                PhonesAmount = ph.Select(d => d.OperatingSystem.Version).Count(),
                // Phones = ph.Select(d => d.Name)
            })
        })
        .Where(d => d.Data.Count() > 0)
        .Cacheable(TimeSpan.FromSeconds(60));
      return new { Data = data, unit = "" };
    }

    [HttpGet("[action]")]
    public object AndroidVersionDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      allDevices = allDevices.Where(d => d.OperatingSystem.Name == "android");
      if (!string.IsNullOrWhiteSpace(value)) {
        allDevices = allDevices.Where(p => p.OperatingSystem.VersionName == value);
      }
      var data = allDevices
        .Select(p => new { Name = p.Name, Brand = p.Brand, SpecificValue = p.OperatingSystem.VersionName, DeviceType = p.Basic.DeviceType, Slug = p.Basic.Slug })
        .OrderBy(p => p.Brand).ThenBy(p => p.SpecificValue)
        .ToList();
      return data;
    }

    [HttpGet("[action]")]
    public object UsbVersion(int startYear = 0, int endYear = 0, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, startYear, endYear);

      var data = allDevices
        .Where(p => p.Status.ReleasedDate.Year != null)
        .OrderByDescending(p => p.Status.ReleasedDate.Year)
        .GroupBy(p => p.Status.ReleasedDate.Year)
        .Select(p => new {
          Year = p.Key.ToString(),
            Data = p
            .Where(ph => ph.Communication.Usb.Version != null)
            .GroupBy(ph => ph.Communication.Usb.Version)
            .Select(ph => new {
              Usb = ph.Key,
                PhonesAmount = ph.Select(d => d.Communication.Usb.Version).Count(),
                // Phones = ph.Select(d => d.Name)
            })
        })
        .Where(d => d.Data.Count() > 0)
        .Cacheable(TimeSpan.FromSeconds(60));
      return new { Data = data, unit = "" };
    }

    [HttpGet("[action]")]
    public object UsbVersionDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      if (!string.IsNullOrWhiteSpace(value)) {
        allDevices = allDevices.Where(p => p.Communication.Usb.Version == value);
      }
      var data = allDevices
        .Select(p => new { Name = p.Name, Brand = p.Brand, SpecificValue = p.Communication.Usb.Version, DeviceType = p.Basic.DeviceType, Slug = p.Basic.Slug })
        .OrderBy(p => p.Brand).ThenBy(p => p.SpecificValue)
        .ToList();
      return data;
    }


    
    [HttpGet("[action]")]
    public object UsbPort(int startYear = 0, int endYear = 0, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, startYear, endYear);

      var data = allDevices
        .Where(p => p.Status.ReleasedDate.Year != null)
        .OrderByDescending(p => p.Status.ReleasedDate.Year)
        .GroupBy(p => p.Status.ReleasedDate.Year)
        .Select(p => new {
          Year = p.Key.ToString(),
            Data = p
            .Where(ph => ph.Communication.Usb.Connector != null)
            .GroupBy(ph => ph.Communication.Usb.Connector=="pop-port"?"proprietary":ph.Communication.Usb.Connector)
            .Select(ph => new {
              Usb = ph.Key,
                PhonesAmount = ph.Select(d => d.Communication.Usb.Connector).Count(),
                // Phones = ph.Select(d => d.Name)
            })
        })
        .Where(d => d.Data.Count() > 0)
        .Cacheable(TimeSpan.FromSeconds(60));
      return new { Data = data, unit = "" };
    }

    [HttpGet("[action]")]
    public object UsbPortDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      if (!string.IsNullOrWhiteSpace(value)) {
        allDevices = allDevices.Where(p => p.Communication.Usb.Connector == value);
      }
      var data = allDevices
        .Select(p => new { Name = p.Name, Brand = p.Brand, SpecificValue = p.Communication.Usb.Connector, DeviceType = p.Basic.DeviceType, Slug = p.Basic.Slug })
        .OrderBy(p => p.Brand).ThenBy(p => p.SpecificValue)
        .ToList();
      return data;
    }
  }
}
