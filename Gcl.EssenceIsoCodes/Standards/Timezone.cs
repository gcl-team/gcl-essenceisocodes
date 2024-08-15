using Gcl.EssenceIsoCodes.Utils;

namespace Gcl.EssenceIsoCodes.Standards;

/// <summary>
/// Class Timezone follows IANA tz database time zones. It shows Standard Time (SDT)
/// and Daylight Saving Time (DST) offsets from UTC in hours and minutes.<br />
/// Reference:
/// <see href="https://en.wikipedia.org/wiki/List_of_tz_database_time_zones" /><br />
/// </summary>
public class Timezone
{
    /// <summary>
    /// Identifier of timezone.
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// SDT offset from UTC in hours and minutes.
    /// </summary>
    public required TimeSpan StandardTimeOffset { get; init; }

    /// <summary>
    /// DST offset from UTC in hours and minutes.
    /// </summary>
    public required TimeSpan DaylightSavingTimeOffset { get; init; }

    /// <summary>
    /// This method is used to get all timezones.
    /// </summary>
    /// <returns>
    /// An array of <c>Timezone</c> with the tz identifier and UTC offsets.
    /// </returns>
    public static async Task<Timezone[]> GetTimezonesAsync()
    {
        var lines = await FileManagement.ReadDataFileContentAsync("timezones.csv");

        return lines.Skip(1).Select(line =>
            line.Split(',').ToArray()).Select(
            fields => new Timezone
            {
                Id = fields[0].Trim(), 
                StandardTimeOffset = ParseTimeSpanText(fields[1].Trim()),
                DaylightSavingTimeOffset = ParseTimeSpanText(fields[2].Trim())
            }).ToArray();
    }

    private static TimeSpan ParseTimeSpanText(string timeSpanText)
    {
        return TimeSpan.Parse(timeSpanText[0] == '+' ? timeSpanText[1..] : timeSpanText);
    }
}