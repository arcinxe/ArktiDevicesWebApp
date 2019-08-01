using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ArktiPhonesDatabaseUploader;
using EntityFrameworkCore.Cacheable;
using Microsoft.AspNetCore.Mvc;

namespace ArktiPhonesWebApp.Controllers {
  [Route("api/[controller]")]
  public class DevicesDataController : Controller {
    IDeviceRepository _repo = new SqlDbRepository();
    DeviceContext _db = new DeviceContext();
    DevicesFilter _filter;

    public DevicesDataController() {
      _filter = new DevicesFilter(_repo.GetDevices());
    }

    [HttpGet("[action]")]
    public IEnumerable<ArktiPhonesDatabaseUploader.Models.DeviceDetail> DeviceDetails() {
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
        .GroupBy(p => p.Status.ReleasedDate.Year)
        .Select(p => new {
          Year = p.Key.ToString(),
            Jack = p.Where(ph => ph.Communication.AudioJack.HasValue && ph.Communication.AudioJack.Value).Select(ph => ph.Communication.AudioJack.Value).Count(),
            NoJack = p.Where(ph => ph.Communication.AudioJack == null || !ph.Communication.AudioJack.Value).Select(ph => ph.Communication.AudioJack).Count(),
        }).ToList();
      return new { Data = data, Keys = new List<string>() { "jack", "noJack" } };
    }

    [HttpGet("[action]")]
    public object MiniJackDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      var withJack = value.Equals("jack", StringComparison.OrdinalIgnoreCase);

      var data = allDevices.Where(p => p.Status.ReleasedDate.Year == year)
        .Where(ph => ph.Communication.AudioJack.HasValue && (!withJack ^ ph.Communication.AudioJack.Value))
        .OrderBy(ph => ph.Brand)
        .ThenBy(ph => ph.Name)
        .Select(ph => new { Name = ph.Name, Brand = ph.Brand, SpecificValue = ph.Communication.AudioJack, DeviceType = ph.Basic.DeviceType, Slug = ph.Basic.Slug })
        .ToList();
      var results = new { Year = year, Jack = withJack, devices = data };
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
            Infrared = p.Where(ph => ph.Communication.Infrared).Select(ph => ph.Communication.Infrared).Count(),
            NoInfrared = p.Where(ph => !ph.Communication.Infrared).Select(ph => ph.Communication.Infrared).Count(),
        }).ToList();
      return new { Data = data, Keys = new List<string>() { "noInfrared", "infrared" } };
    }

    [HttpGet("[action]")]
    public object InfraredDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      var withInfrared = value.Equals("infrared", StringComparison.OrdinalIgnoreCase);
      var data = allDevices.Where(p => p.Status.ReleasedDate.Year == year)
        .Where(ph => !withInfrared ^ ph.Communication.Infrared)
        .OrderBy(ph => ph.Brand)
        .ThenBy(ph => ph.Name)
        .Select(ph => new { Name = ph.Name, Brand = ph.Brand, SpecificValue = ph.Communication.Infrared, DeviceType = ph.Basic.DeviceType, Slug = ph.Basic.Slug })
        .ToList();
      var results = new { Year = year, Infrared = withInfrared, devices = data };
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
            Smartphones = p.Where(ph => ph.Basic.DeviceType == "smartphone").Count(),
            Smartwatches = p.Where(ph => ph.Basic.DeviceType == "smartwatch").Count(),
            Tablets = p.Where(ph => ph.Basic.DeviceType == "tablet").Count(),
            Cellphones = p.Where(ph => ph.Basic.DeviceType == "phone").Count(),
        }).ToList();
      return new { Data = data, Keys = new List<string>() { "smartphones", "smartwatches", "tablets", "cellphones" } };
    }

    [HttpGet("[action]")]
    public object TypesDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      var deviceType = value;
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
      var data = allDevices.Where(p => p.Status.ReleasedDate.Year == year)
        .Where(ph => ph.Basic.DeviceType == deviceType)
        .OrderBy(ph => ph.Brand)
        .ThenBy(ph => ph.Name)
        .Select(ph => new { Name = ph.Name, Brand = ph.Brand, SpecificValue = ph.Basic.DeviceType, DeviceType = ph.Basic.DeviceType, Slug = ph.Basic.Slug })
        .ToList();
      var results = new { Year = year, Type = deviceType, devices = data };
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
            Memory = p
            .Where(ph => ph.Memory.RandomAccess.HasValue)
            .GroupBy(ph => ph.Memory.RandomAccess > 1000 ? $"{ph.Memory.RandomAccess/1024}GB" : $"<1GB")
            .Select(ph => new {
              RamInMB = ph.Key,
                PhonesAmount = ph.Select(d => d.Memory.RandomAccess).Count()
            })
        })
        .Cacheable(TimeSpan.FromSeconds(60));
      return new { Data = data, Keys = new List<string>() { "<1GB", "1GB", "2GB", "3GB", "4GB", "6GB", "8GB", "10GB", "12GB" } };
    }

    [HttpGet("[action]")]
    public object RamDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      var regex = Regex.Match(value, @"^(\d+)GB");
      var size = regex.Success?regex.Groups[1].Value: "";
      var sizeNumber = int.TryParse(size, out int result) ? result * 1024 : 0;
      var data = allDevices
        .Where(p => p.Memory.RandomAccess.HasValue && (size == "" ? p.Memory.RandomAccess < 1000 : p.Memory.RandomAccess == sizeNumber))
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
            ScreenDensity = p
            .Where(ph => ph.Display.PixelDensity.HasValue)
            .GroupBy(ph => ph.Memory.RandomAccess > 1000 ? $"{ph.Memory.RandomAccess/1024}GB" : $"<1GB")
            .Select(ph => new {
              RamInMB = ph.Key,
                PhonesAmount = ph.Select(d => d.Memory.RandomAccess).Count()
            })
        })
        .Cacheable(TimeSpan.FromSeconds(60));
      return data;
    }

    [HttpGet("[action]")]
    public object ScreenDensityDetails(int year, string value, string selectedBrandsIds = "", string deviceTypes = "") {
      var allDevices = _filter.Filter(selectedBrandsIds, deviceTypes, year, year);
      var regex = Regex.Match(value, @"^(\d+)GB");
      var size = regex.Success?regex.Groups[1].Value: "";
      var sizeNumber = int.TryParse(size, out int result) ? result * 1024 : 0;
      var data = allDevices
        .Where(p => p.Memory.RandomAccess.HasValue && (size == "" ? p.Memory.RandomAccess < 1000 : p.Memory.RandomAccess == sizeNumber))
        .Select(p => new { Name = p.Name, Brand = p.Brand, SpecificValue = p.Memory.RandomAccess, DeviceType = p.Basic.DeviceType, Slug = p.Basic.Slug })
        .OrderBy(p => p.Brand).ThenBy(p => p.SpecificValue)
        .ToList();
      return data;
    }
  }
}
