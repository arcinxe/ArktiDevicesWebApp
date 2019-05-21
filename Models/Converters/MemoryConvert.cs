using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class MemoryConvert : IConverter<Memory, MemoryDefault> {
    public MemoryDefault Convert(Memory sourceObject) {
        var result = new MemoryDefault() {
            RandomAccess = sourceObject.RandomAccess,
            ReadOnly = sourceObject.ReadOnly,
            Internal = sourceObject.Internal,
            CardType = sourceObject.CardType,
            CardMaxSize = sourceObject.CardMaxSize
        };

        return result;
    }

    public Memory Convert(MemoryDefault sourceObject) {
        var result = new Memory() {
            RandomAccess = sourceObject.RandomAccess,
            ReadOnly = sourceObject.ReadOnly,
            Internal = sourceObject.Internal,
            CardType = sourceObject.CardType,
            CardMaxSize = sourceObject.CardMaxSize
        };

        return result;
    }
}
