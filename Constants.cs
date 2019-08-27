using System;
using System.Collections.Generic;
using System.Linq;

namespace ArktiDevicesWebApp {
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
        public static List<ChartType> ChartTypes = new List<ChartType>();
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

            ChartTypes.Add(new ChartType() { Name = "Device types", Path = "Types" });
            ChartTypes.Add(new ChartType() { Name = "RAM", Path = "Ram" });
            ChartTypes.Add(new ChartType() { Name = "Android versions", Path = "AndroidVersion" });
            ChartTypes.Add(new ChartType() { Name = "Mini jack", Path = "MiniJack" });
            ChartTypes.Add(new ChartType() { Name = "Infrared", Path = "Infrared" });
            ChartTypes.Add(new ChartType() { Name = "Screen size", Path = "ScreenDiagonal" });
            ChartTypes.Add(new ChartType() { Name = "Screen pixel density", Path = "ScreenDensity" });
            ChartTypes.Add(new ChartType() { Name = "USB ports", Path = "UsbPort" });
            ChartTypes.Add(new ChartType() { Name = "USB versions", Path = "UsbVersion" });
        }
    }
    public class Brand {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOfDevices { get; set; }
    }
    public class ChartType {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
