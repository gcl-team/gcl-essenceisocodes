using System.Reflection;

namespace Gcl.EssenceIsoCodes.Utils;

internal static class FileManagement
{
    internal static async Task<string[]> ReadDataFileContentAsync(string fileName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var projectName = assembly.GetName().Name!;
        var fileContent = assembly.GetManifestResourceStream($"{projectName}.Data.{fileName}") 
                          ?? throw new Exception($"{fileName} not found!");

        using var fileDataStream = new StreamReader(fileContent);

        var lines = new List<string>();

        while (await fileDataStream.ReadLineAsync() is { } line)
        {
            lines.Add(line);
        }

        return lines.ToArray();
    }
}