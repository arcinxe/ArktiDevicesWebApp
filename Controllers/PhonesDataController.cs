using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArktiPhonesDatabaseUploader;
using Microsoft.AspNetCore.Mvc;

namespace ArktiPhonesWebApp.Controllers {
  [Route ("api/[controller]")]
  public class PhonesDataController : Controller {
    IDeviceRepository _db = new SqlDbRepository ();
    [HttpGet ("[action]")]
    public IEnumerable<ArktiPhonesDatabaseUploader.Models.DeviceDetail> DeviceDetails () {
      var devices = _db.GetDevices ().Take (10).ToList ();
      //   var results = devices.Select(d => new DeviceDetailConvert().Convert(d)).ToList();
      return devices;
    }

    [HttpGet ("[action]")]
    public string testing () {
      return "it seems to be working";
    }

  }
}