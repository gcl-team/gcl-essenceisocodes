using Gcl.EssenceIsoCodes.Utils;

namespace Gcl.EssenceIsoCodes.Iso.Iso4217;

/// <summary>
/// Class Currency follows ISO 4217 standard – Alphabetic codes and numeric codes for the representation of
/// currencies.<br />
/// Reference:
/// <see href="https://en.wikipedia.org/wiki/ISO_4217#Active_codes_(list_one)" />
/// </summary>
public class Currency
{
    /// <summary>
    /// Name of currency.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Three-letter currency codes.
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// Three-digit currency codes. The code is usually the same as the numeric code assigned to the corresponding
    /// country by ISO 3166-1.
    /// </summary>
    public required string NumericCode { get; init; }

    /// <summary>
    /// This method is used to get all currencies.
    /// </summary>
    /// <returns>
    /// An array of <c>Currency</c> with the currency name, three-letter code, and numeric code.
    /// </returns>
    public static readonly Currency[] Currencies = GetCurrencies();

    private static Currency[] GetCurrencies()
    {
        var currenciesDataFilePath = FileManagement.GetDataFilePath("currencies.csv");

        var lines = File.ReadAllLines(currenciesDataFilePath);

        return lines.Skip(1).Select(line =>
            line.Split(',').ToArray()).Select(
            fields => new Currency
            {
                Name = fields[1], 
                Code = fields[0], 
                NumericCode = fields[2]
            }).ToArray();
    }
}