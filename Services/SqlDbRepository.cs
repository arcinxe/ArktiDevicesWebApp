using System.Collections.Generic;
using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
using Microsoft.Extensions.Configuration;
namespace ArktiDevicesDatabaseUploader {
    public class SqlDbRepository : IDeviceRepository {
        private readonly DeviceContext _db;

        public SqlDbRepository () {
            _db = new DeviceContext ();
        }
        public Models.DeviceDetail AddDevice (Models.DeviceDetail device) {
            _db.DeviceDetails.Add (device);
            _db.SaveChanges ();
            return device;
        }
        public IEnumerable<Models.DeviceDetail> AddDevices (IEnumerable<Models.DeviceDetail> devices) {

            _db.DeviceDetails.AddRange (devices);
            _db.SaveChanges ();
            return devices;
        }
        public IQueryable<Models.DeviceDetail> GetDevices () {
            return _db.DeviceDetails;
        }

        public void RemoveDevice (int id) {
            var deviceToRemove = _db.DeviceDetails.FirstOrDefault (d => d.Basic.GsmArenaNumber == id);
            _db.DeviceDetails.Remove (deviceToRemove);
            _db.SaveChanges ();
        }

        public void UpdateDevice (int id, DeviceDetail device) {
            var newDevice = _db.DeviceDetails.FirstOrDefault (d => d.Basic.GsmArenaNumber == id);
            _db.Entry (newDevice).CurrentValues.SetValues (device);
            _db.SaveChanges ();
        }
    }
}