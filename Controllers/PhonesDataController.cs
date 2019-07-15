using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ArktiPhonesDatabaseUploader;
using Microsoft.AspNetCore.Mvc;

namespace ArktiPhonesWebApp.Controllers {
  [Route ("api/[controller]")]
  public class PhonesDataController : Controller {
    IDeviceRepository _repo = new SqlDbRepository ();
    DeviceContext _db = new DeviceContext ();
    [HttpGet ("[action]")]
    public IEnumerable<ArktiPhonesDatabaseUploader.Models.DeviceDetail> DeviceDetails () {
      var devices = _repo.GetDevices ().Take (10).ToList ();
      //   var results = devices.Select(d => new DeviceDetailConvert().Convert(d)).ToList();
      return devices;
    }

    [HttpGet ("[action]")]
    public string testing () {
      return "it seems to be working";
    }

    [HttpGet ("[action]")]
    public object Brands () {
      return Constants.Brands;
    }

    [HttpGet ("[action]")]
    public object PhonesWithJackDetails (int year, bool withJack, string selectedBrandsIds = "") {
      if (year < 1900)
        return new List<string> ();
      var allDevices = _repo.GetDevices ()
        .Where (p => p.Status.ReleasedDate.Year != null &&
          p.Status.ReleasedDate.Year == year);

      if (!string.IsNullOrWhiteSpace (selectedBrandsIds)) {
        var brandsIds = selectedBrandsIds
          .Split (',')
          .Select (id => int.Parse (id));
        var brands = Constants.Brands
          .Where (b => brandsIds.Contains (b.ID))
          .Select (b => b.Name);
        var filteredDevices = allDevices.Where (d => brands.Contains (d.Brand));
        allDevices = filteredDevices;
      }

      var data = allDevices.Where (p => p.Status.ReleasedDate.Year == year)
        .Where (ph => ph.Communication.AudioJack.HasValue && (!withJack ^ ph.Communication.AudioJack.Value))
        .OrderBy (ph => ph.Brand)
        .ThenBy (ph => ph.Name)
        .Select (ph => new { Name = ph.Name, Brand = ph.Brand, DeviceType = ph.Basic.DeviceType })
        .ToList ();
      var results = new { Year = year, Jack = withJack, devices = data };
      return results;
    }

    [HttpGet ("[action]")]
    public object PhonesWithJack (int startYear = 2006, int endYear = 2019, string selectedBrandsIds = "") {
      // System.Threading.Thread.Sleep(3000);
      var allDevices = _repo.GetDevices ()
        .Where (p => p.Status.ReleasedDate.Year != null &&
          p.Status.ReleasedDate.Year >= startYear &&
          p.Status.ReleasedDate.Year <= endYear);

      if (!string.IsNullOrWhiteSpace (selectedBrandsIds)) {
        var brandsIds = selectedBrandsIds
          .Split (',')
          .Select (id => int.Parse (id));
        var brands = Constants.Brands
          .Where (b => brandsIds.Contains (b.ID))
          .Select (b => b.Name);
        var filteredDevices = allDevices.Where (d => brands.Contains (d.Brand));
        allDevices = filteredDevices;
      }

      var data = allDevices
        .OrderByDescending (p => p.Status.ReleasedDate.Year)
        .GroupBy (p => p.Status.ReleasedDate.Year)
        .Select (p => new {
          Year = p.Key.ToString (),
            Jack = p.Where (ph => ph.Communication.AudioJack.HasValue && ph.Communication.AudioJack.Value).Select (ph => ph.Communication.AudioJack.Value).Count (),
            NoJack = p.Where (ph => ph.Communication.AudioJack == null || !ph.Communication.AudioJack.Value).Select (ph => ph.Communication.AudioJack).Count (),
        }).ToList ();
      return data;
    }

    [HttpGet ("[action]")]
    public object PhonesWithInfraredDetails (int year, bool withInfrared, string selectedBrandsIds = "") {
      if (year < 1900)
        return new List<string> ();
      var allDevices = _repo.GetDevices ()
        .Where (p => p.Status.ReleasedDate.Year != null &&
          p.Status.ReleasedDate.Year == year);

      if (!string.IsNullOrWhiteSpace (selectedBrandsIds)) {
        var brandsIds = selectedBrandsIds
          .Split (',')
          .Select (id => int.Parse (id));
        var brands = Constants.Brands
          .Where (b => brandsIds.Contains (b.ID))
          .Select (b => b.Name);
        var filteredDevices = allDevices.Where (d => brands.Contains (d.Brand));
        allDevices = filteredDevices;
      }

      var data = allDevices.Where (p => p.Status.ReleasedDate.Year == year)
        .Where (ph => !withInfrared ^ ph.Communication.Infrared)
        .OrderBy (ph => ph.Brand)
        .ThenBy (ph => ph.Name)
        .Select (ph => new { Name = ph.Name, Brand = ph.Brand, DeviceType = ph.Basic.DeviceType })
        .ToList ();
      var results = new { Year = year, Infrared = withInfrared, devices = data };
      return results;
    }

    [HttpGet ("[action]")]
    public object PhonesWithInfrared (int startYear = 2006, int endYear = 2019, string selectedBrandsIds = "") {
      var allDevices = _repo.GetDevices ()
        .Where (p => p.Status.ReleasedDate.Year != null &&
          p.Status.ReleasedDate.Year >= startYear &&
          p.Status.ReleasedDate.Year <= endYear);

      if (!string.IsNullOrWhiteSpace (selectedBrandsIds)) {
        var brandsIds = selectedBrandsIds
          .Split (',')
          .Select (id => int.Parse (id));
        var brands = Constants.Brands
          .Where (b => brandsIds.Contains (b.ID))
          .Select (b => b.Name);
        var filteredDevices = allDevices.Where (d => brands.Contains (d.Brand));
        allDevices = filteredDevices;
      }

      var data = allDevices
        .OrderByDescending (p => p.Status.ReleasedDate.Year)
        .GroupBy (p => p.Status.ReleasedDate.Year)
        .Select (p => new {
          Year = p.Key.ToString (),
            Infrared = p.Where (ph => ph.Communication.Infrared).Select (ph => ph.Communication.Infrared).Count (),
            NoInfrared = p.Where (ph => !ph.Communication.Infrared).Select (ph => ph.Communication.Infrared).Count (),
        }).ToList ();
      return data;
    }

    [HttpGet ("[action]")]
    public object PhonesRam (int startYear = 2006, int endYear = 2019, string selectedBrandsIds = "") {
      var allDevices = _repo.GetDevices ()
        .Where (p => p.Status.ReleasedDate.Year != null &&
          p.Status.ReleasedDate.Year >= startYear &&
          p.Status.ReleasedDate.Year <= endYear);

      if (!string.IsNullOrWhiteSpace (selectedBrandsIds)) {
        var brandsIds = selectedBrandsIds
          .Split (',')
          .Select (id => int.Parse (id));
        var brands = Constants.Brands
          .Where (b => brandsIds.Contains (b.ID))
          .Select (b => b.Name);
        var filteredDevices = allDevices.Where (d => brands.Contains (d.Brand));
        allDevices = filteredDevices;
      }

      var data = allDevices
        .OrderByDescending (p => p.Status.ReleasedDate.Year)
        .GroupBy (p => p.Status.ReleasedDate.Year)
        .Select (p => new {
          Year = p.Key.ToString (),
            Memory = p
            .Where (ph => ph.Memory.RandomAccess.HasValue)
            .GroupBy (ph => ph.Memory.RandomAccess > 1000 ? $"{ph.Memory.RandomAccess/1024}GB" : $"<1GB")
            .Select (ph => new {
              RamInMB = ph.Key,
                PhonesAmount = ph.Select (d => d.Memory.RandomAccess).Count ()
            })
        })
        .ToList ();
      return data;
    }

    [HttpGet ("[action]")]
    public object PhonesRamDetails (int year, string ramAmount, string selectedBrandsIds = "") {
      if (year < 1900)
        return new List<string> ();
      var allDevices = _repo.GetDevices ()
        .Where (p => p.Status.ReleasedDate.Year != null &&
          p.Status.ReleasedDate.Year == year);

      if (!string.IsNullOrWhiteSpace (selectedBrandsIds)) {
        var brandsIds = selectedBrandsIds
          .Split (',')
          .Select (id => int.Parse (id));
        var brands = Constants.Brands
          .Where (b => brandsIds.Contains (b.ID))
          .Select (b => b.Name);
        var filteredDevices = allDevices.Where (d => brands.Contains (d.Brand));
        allDevices = filteredDevices;
      }
      var regex = Regex.Match (ramAmount, @"^(\d+)GB");
      var size = regex.Success?regex.Groups[1].Value: "";
      var sizeNumber = int.TryParse (size, out int result) ? result * 1024 : 0;
      var data = allDevices
        .Where (p => p.Memory.RandomAccess.HasValue && (size == "" ? p.Memory.RandomAccess < 1000 : p.Memory.RandomAccess == sizeNumber))
        .Select(p => new { Name = p.Name, Brand = p.Brand, RAM = p.Memory.RandomAccess })
        .OrderBy(p => p.Brand).ThenBy(p => p.RAM)
        .ToList ();
      return data;
    }
  }
}
