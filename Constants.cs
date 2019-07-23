using System;
using System.Collections.Generic;
using System.Linq;

namespace ArktiPhonesWebApp
{
    public static class Constants {
        public static List<Brand> Brands;
        public static List<List<Brand>> GroupedBrands = new List<List<Brand>>();
        private static List<string> PopularBrands = new List<string>() {
            "samsung",
            "huawei",
            "apple",
            "xiaomi",
            "oppo",
            "vivo",
            "lg",
            "lenovo",
            "nokia",
            "google",
            "asus",
            "oneplus",
            "sony",
            "realme",
            "honor",
            "blackberry",
            "htc",
            "motorola"
        };
        static Constants() {
            var count = 1;
            var db = new DeviceContext();

            Brands = db.DeviceDetails
                .Where(d => d.Status.ReleasedDate.Year != null)
                .GroupBy(p => p.Brand)
                .Select(p => new {
                    Name = p.Key,
                        NumberOfDevices = p.Select(ph => ph.Brand).Count()
                })
                .ToList()
                .Select(b => new Brand { ID = count++, Name = b.Name, NumberOfDevices = b.NumberOfDevices })
                .OrderBy(p => p.Name)
                .ToList();
            var popularBrands = Brands.Where(b => PopularBrands.Contains(b.Name, StringComparer.OrdinalIgnoreCase)).ToList();
            var restOfBrands = Brands.Where(b => !PopularBrands.Contains(b.Name, StringComparer.OrdinalIgnoreCase)).ToList();
            GroupedBrands.Add(popularBrands);
            GroupedBrands.Add(restOfBrands);
        }
    }
    public class Brand {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOfDevices { get; set; }
    }
}
