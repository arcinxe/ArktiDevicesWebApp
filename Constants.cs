using System.Collections.Generic;
using System.Linq;

namespace ArktiPhonesWebApp {
    public static class Constants {
        public static List<Brand> Brands;

        static Constants () {
            var count = 1;
            var db = new DeviceContext ();
            Brands = db.DeviceDetails.Select (d => d.Brand)
                .Distinct ()
                .OrderBy (b => b)
                .ToList ()
                .Select (d => new Brand { ID = count++, Name = d })
                .ToList ();
        }
    }
    public class Brand {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}