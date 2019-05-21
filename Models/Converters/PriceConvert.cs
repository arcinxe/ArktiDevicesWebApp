using System.Linq;
using ArktiPhonesDatabaseUploader.Models;
public class PriceConvert : IConverter<Price, PriceDefault> {
    public PriceDefault Convert(Price sourceObject) {
        var result = new PriceDefault() {
            Value = sourceObject.Value,
            Currency = sourceObject.Currency,
            EstimatedInEuro = sourceObject.EstimatedInEuro
        };

        return result;
    }

    public Price Convert(PriceDefault sourceObject) {
        var result = new Price() {
            Value = sourceObject.Value,
            Currency = sourceObject.Currency,
            EstimatedInEuro = sourceObject.EstimatedInEuro
        };

        return result;
    }
}
