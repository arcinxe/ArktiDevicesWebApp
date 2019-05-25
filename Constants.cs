using System.Collections.Generic;
using System.Linq;

namespace ArktiPhonesWebApp {
    public static class Constants {
        public static List<Brand> Brands;

        static Constants () {
            var count = 1;
            var db = new DeviceContext ();

            Brands = db.DeviceDetails
                .Where (d => d.Status.ReleasedDate.Year != null)
                .GroupBy (p => p.Brand)
                .Select (p => new {
                    Name = p.Key,
                        NumberOfDevices = p.Select (ph => ph.Brand).Count ()
                })
                .ToList ()
                .Select (b => new Brand { ID = count++, Name = b.Name, NumberOfDevices = b.NumberOfDevices })
                .OrderBy (p => p.Name)
                .ToList ();
        }
    }
    public class Brand {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOfDevices { get; set; }
    }
}