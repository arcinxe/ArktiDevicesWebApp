using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    public object PhonesWithJack (int startYear = 2007, int endYear = 2018, string selectedBrandsIds = "") {
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
            NoJack = p.Where (ph => ph.Communication.AudioJack.HasValue && !ph.Communication.AudioJack.Value).Select (ph => ph.Communication.AudioJack.Value).Count ()
        }).ToList ();
      return data;
    }
  }
}