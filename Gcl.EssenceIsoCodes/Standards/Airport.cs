using Gcl.EssenceIsoCodes.Utils;

namespace Gcl.EssenceIsoCodes.Standards;

/// <summary>
/// Class Airport follows IATA airport code and ICAO code.<br />
/// Reference 1:
/// <see href="https://en.wikipedia.org/wiki/IATA_airport_code" /><br />
/// Reference 2:
/// <see href="https://en.wikipedia.org/wiki/ICAO_airport_code" /><br />
/// </summary>
public class Airport
{
    /// <summary>
    /// Name of airport.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// IATA airport code, a three-letter geocode.
    /// </summary>
    public required string CodeIata { get; init; }

    /// <summary>
    /// ICAO airport code, a four-letter code designating aerodromes.
    /// </summary>
    public required string CodeIcao { get; init; }
    
    /// <summary>
    /// ISO 3166-1 two-letter country code of the airport.
    /// </summary>
    public required string CountryCode { get; init; }

    /// <summary>
    /// This method is used to get all airports.
    /// </summary>
    /// <returns>
    /// Airports with the airport name, IATA code, ICAO code, and country code.
    /// </returns>
    public static async Task<HashSet<Airport>> GetAirportsAsync()
    {
        var lines = await FileManagement.ReadDataFileContentAsync("airports.csv");

        return lines.Skip(1).Select(line =>
            line.Split(',').ToArray()).Select(
            fields => new Airport
            {
                Name = fields[2].Trim(), 
                CodeIata = fields[0].Trim(), 
                CodeIcao = fields[1].Trim(),
                CountryCode = fields[3].Trim()
            }).ToHashSet();
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Airport airport)
        {
            return 
                CodeIata == airport.CodeIata && 
                CodeIcao == airport.CodeIcao;
        }
        
        return false;
    }

    public override int GetHashCode()
    {
        return (CodeIata, CodeIcao).GetHashCode();
    }
}