using System;
using System.Collections.Generic;
using System.Linq;

namespace ArktiDevicesWebApp {
    public static class Constants {
        public static List<Brand> Brands;
        public static List<List<Brand>> GroupedBrands = new List<List<Brand>>();
        public static Dictionary<string, List<string>> ColorThemes = new Dictionary<string, List<string>>();
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
            ColorThemes.Add("RAM", new List<string> { "#0091B2", "#00E0B6", "#00DB5F", "#00D60D", "#42D200", "#8DCD00", "#C8BB00", "#C36D00", "#BF2200" });
            ColorThemes.Add("2", new List<string> { "#3399ff", "#f20051" });
            ColorThemes.Add("2inverted", new List<string> { "#f20051", "#3399ff" });
            ColorThemes.Add("5", new List<string> { "#d92b2b", "#ffaa00", "#44ff33", "#4dd2ff", "#a61199" });
            ColorThemes.Add("6", new List<string> { "#e52600", "#3df200", "#2633bf", "#ffb31a", "#00d2e6", "#f230a2" });
            ColorThemes.Add("10", new List<string> { "#ff5500", "#6aff00", "#248fb3", "#d900b5", "#bf8613", "#009933", "#3399ff", "#f20051", "#b1bf13", "#49f2e4", "#2b3ad9" });
            ColorThemes.Add("4", new List<string> { "#cc553d", "#62b312", "#4dd2ff", "#701f99" });
            ColorThemes.Add("twilight", new List<string> { "#240041", "#480544", "#6D0B47", "#B5154D", "#A3124C", "#DA2B52", "#FF4057", "#FF615C", "#ff8260" });
            // ColorThemes.Add("twilight4", new List<string> { "#FF8260", "#FF4057", "#480544", "#6D0B47" });
            // ColorThemes.Add("twilight4", new List<string> { "#A3124C", "#FF6B61", "#FF4057", "#D12952" });
            ColorThemes.Add("twilight4", new List<string> { "#A3124C", "#D12952", "#FF615C", "#FF987C" });
            ChartTypes.Add(new ChartType() { Name = "RAM", Path = "Ram", Colors = ColorThemes["RAM"] });
            ChartTypes.Add(new ChartType() { Name = "Infrared", Path = "Infrared", Colors = ColorThemes["2inverted"] });
            ChartTypes.Add(new ChartType() { Name = "Mini jack", Path = "MiniJack", Colors = ColorThemes["2"] });
            ChartTypes.Add(new ChartType() { Name = "Device types", Path = "Types", Colors = ColorThemes["twilight4"] });
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
        public List<string> Colors { get; set; }

    }
}
