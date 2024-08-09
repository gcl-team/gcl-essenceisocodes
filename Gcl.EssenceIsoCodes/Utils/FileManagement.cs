namespace Gcl.EssenceIsoCodes.Utils;

public class FileManagement
{
    public static string GetDataFilePath(string fileName)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(basePath, "Data", fileName);

        return filePath;
    }
}