using System.Linq;
using ArktiDevicesDatabaseUploader.Models;
public class MaterialConvert : IConverter<Material, MaterialDefault> {
    public MaterialDefault Convert (Material sourceObject) {
        var result = new MaterialDefault () {
            Back = sourceObject.Back,
            Front = sourceObject.Frame,
            Frame = sourceObject.Frame,
            Body = sourceObject.Body
        };

        return result;
    }

    public Material Convert (MaterialDefault sourceObject) {
        var result = new Material () {
            Back = sourceObject.Back,
            Front = sourceObject.Frame,
            Frame = sourceObject.Frame,
            Body = sourceObject.Body
        };

        return result;
    }
}
