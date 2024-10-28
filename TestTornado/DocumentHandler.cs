using System.Diagnostics;

namespace TestTornado
{
    public class DocumentHandler
    {

        public static async Task SaveToFileAsync(Stream content, string outputFilePath)
        {
            await using (var fileStream = File.Create(outputFilePath))
            {
                await content.CopyToAsync(fileStream);
            }
            OpenDocxFile(outputFilePath);
        }

        public static void OpenDocxFile(string filePath)
        {
            try
            {
                // Use Process.Start to open the file with the default application
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening file: {ex.Message}");
            }
        }
    }
}
