using Gcl.EssenceIsoCodes.Utils;

namespace Gcl.EssenceIsoCodes.Standards;

/// <summary>
/// Class Country follows ISO 3166-1 standard – Codes for the representation of names of countries and 
/// their subdivisions.<br />
/// Reference:
/// <see href="https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes" />
/// </summary>
public class Country
{
    /// <summary>
    /// Name of country, dependent territory, or special area of geographical interest.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Two-letter country codes which are also used to create the ISO 3166-2 country subdivision codes 
    /// and the Internet country code top-level domains.
    /// </summary>
    public required string TwoLetterCode { get; init; }

    /// <summary>
    /// Three-letter country codes which may allow a better visual association between the codes and the 
    /// country names.
    /// </summary>
    public required string ThreeLetterCode { get; init; }

    /// <summary>
    /// Three-digit country codes which are identical to those developed and maintained by the United Nations 
    /// Statistics Division, with the advantage of script (writing system) independence, and hence useful for 
    /// people or systems using non-Latin scripts.
    /// </summary>
    public required string NumericCode { get; init; }

    /// <summary>
    /// This method is used to get all countries.
    /// </summary>
    /// <returns>
    /// An array of <c>Country</c> with the country name, two-letter code, three-letter code, and 
    /// numeric code.
    /// </returns>
    public static async Task<Country[]> GetCountriesAsync()
    {
        var lines = await FileManagement.ReadDataFileContentAsync("countries.csv");

        return lines.Skip(1).Select(line =>
            line.Split(',').ToArray()).Select(
                fields => new Country
                {
                    Name = fields[0], 
                    TwoLetterCode = fields[1], 
                    ThreeLetterCode = fields[2], 
                    NumericCode = fields[3]
                }).ToArray();
    }
}