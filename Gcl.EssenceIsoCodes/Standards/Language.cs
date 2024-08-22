using Gcl.EssenceIsoCodes.Utils;

namespace Gcl.EssenceIsoCodes.Standards;

/// <summary>
/// Class Language follows ISO 639 standard – A standardized nomenclature used to classify languages.<br />
/// We focus at macrolanguage which is a group of mutually intelligible speech varieties, or dialect 
/// continuum, that have no traditional name in common, and which may be considered distinct 
/// languages by their speakers.<br />
/// In addition, we also refer to the IETF BCP 47 language tag which is a standardized code used to identify
/// human languages on the Internet.<br />
/// Reference 1:
/// <see href="https://en.wikipedia.org/wiki/ISO_639_macrolanguage#List_of_macrolanguages" /><br />
/// Reference 2:
/// <see href="https://en.wikipedia.org/wiki/IETF_language_tag" /><br />
/// </summary>
public class Language
{
    /// <summary>
    /// Name of language.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// ISO 639-1:2002, code for the representation of names of languages.
    /// </summary>
    public required string CodeIso1 { get; init; }

    /// <summary>
    /// ISO 639-2:1998, code for the representation of names of languages.
    /// </summary>
    public required string CodeIso2 { get; init; }

    /// <summary>
    /// ISO 639-3:2007, code for the representation of names of languages.
    /// </summary>
    public required string CodeIso3 { get; init; }
    
    /// <summary>
    /// IETF BCP 47 language tag.
    /// </summary>
    public required string CodeIetf { get; init; }

    /// <summary>
    /// This method is used to get all languages.
    /// </summary>
    /// <returns>
    /// Languages with the language name, ISO 639-1, ISO 639-2, and ISO 639-3 codes.
    /// </returns>
    public static async Task<HashSet<Language>> GetLanguagesAsync()
    {
        var lines = await FileManagement.ReadDataFileContentAsync("languages.csv");

        return lines.Skip(1).Select(line =>
            line.Split(',').ToArray()).Select(
            fields => new Language
            {
                Name = fields[3].Trim(), 
                CodeIso1 = fields[0].Trim(), 
                CodeIso2 = fields[1].Trim(), 
                CodeIso3 = fields[2].Trim(), 
                CodeIetf = fields[3].Trim()
            }).ToHashSet();
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Language language)
        {
            return
                CodeIso1 == language.CodeIso1 &&
                CodeIso2 == language.CodeIso2 &&
                CodeIso3 == language.CodeIso3 &&
                CodeIetf == language.CodeIetf;
        }
        
        return false;
    }

    public override int GetHashCode()
    {
        return (CodeIso1, CodeIso2, CodeIso3, CodeIetf).GetHashCode();
    }
}