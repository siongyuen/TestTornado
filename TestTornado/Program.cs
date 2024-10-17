using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using TestTornado.Forms.Repeating;

namespace TestTornado
{
    class CSRenderExample
    {
        private static string DWS_RENDER_URL = "http://localhost:8080/api/render";

        // Set your access key here. The access key is only required if configured in Tornado.
        private const string ACCESS_KEY = "";
        // The output format we want to produce (pdf, doc, odt, and more exist)
        private const string OUTPUT_FORMAT = "docx";       
        // The name of the file we are going to write the document to
        private const string OUTPUT_FILE = "Output." + OUTPUT_FORMAT;



static async Task Main(string[] args)
    {
        Console.WriteLine("Select the form type: \n" +
                          "'0' for Repeating \n" +
                          "'1' for GI19FDMSO1 \n" +
                          "'2' for GNIR24AP01 \n" +
                          "'3' for EAW18AR01 \n" +
                          "'4' for HK23NAR1 ");
        string type = Console.ReadLine();

            Console.WriteLine("Select the output file format: \n" +
                              "'1' for PDF \n" +
                              "'2' for DOCX");
                          
        string formatChoice = Console.ReadLine();
        string outputFormat = formatChoice switch
        {
            "1" => "PDF",
            "2" => "DOCX",    
            _ => "DOCX" // Default format
        };

        do
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                    string outputFile = $"output_{DateTime.Now:yyyyMMddHHmmss}";
                    var responseStream = await SendRequestAsync(type, outputFile, outputFormat);
                if (responseStream != null)
                {                   
                    await SaveToFileAsync(responseStream, $"{outputFile}.{outputFormat}");
                    Console.WriteLine($"File saved as {outputFile}");
                    Console.Out.WriteLine($"Time Used milliseconds: {stopwatch.ElapsedMilliseconds}");
                    }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Unable to connect to Docmosis: " + e.Message);
                Console.Error.WriteLine(e.StackTrace);
                Console.Error.WriteLine("If you have a proxy, configure proxy settings at the top of this example.");
            }       

            // Prompt to continue or exit
            Console.WriteLine("Press Enter to generate another document or type 'exit' to quit.");
            type = Console.ReadLine();
            if (type.ToLower() == "exit")
            {
                break; // Exit the loop and end the program
            }

        } while (true);
    }



    /// Sends the request to the server and returns the response stream.
    private static async Task<Stream> SendRequestAsync(string type, string outputFile, string outputFormat )
        {
            using (HttpClient client = new HttpClient())
            {
                string renderRequest = BuildRequest(type, outputFile, outputFormat);

                // Prepare the request content
                StringContent content = new StringContent(renderRequest, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync(DWS_RENDER_URL, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStreamAsync();
                }
                else
                {
                    await ProcessError(response);
                    return null;
                }
            }
        }

        /// Build the request in JSON format.
        private static string BuildRequest(string type, string outputFile, string outputFormat)
        {
            var dataTemplateMap = new Dictionary<string, (object? data, string template)>
                {
                    { "0", (Forms.Repeating.DataGenerator.GetData(), "samples/RepeatingTemplate.docx") },
                    { "1", (TestTornado.Forms.GI19FDMS01.DataGenerator.GetData(), "samples/GI19FDMS01.DOCX") },
                    { "2", (TestTornado.Forms.GNIR24AP01.DataGenerator.GetData(), "samples/GNIR24AP01.DOCX") },
                    { "3", (TestTornado.Forms.EAW18AR01.DataGenerator.GetData(), "samples/EAW18AR01.docx") },
                    { "4", (TestTornado.Forms.HK23NAR1.DataGenerator.GetData(), "samples/HK23NAR1.docx") }
                };

            if (!dataTemplateMap.TryGetValue(type, out var myDataTemplate))
            {
                throw new ArgumentException("Invalid type specified");
            }

            var requestObject = new
            {
                accessKey = ACCESS_KEY,
                templateName = myDataTemplate.template,
                outputName = outputFile,
                outputFormat = outputFormat,
                data = myDataTemplate.data
            };

            return JsonSerializer.Serialize(requestObject, new JsonSerializerOptions { WriteIndented = true });
        }


        private static async Task SaveToFileAsync(Stream content, string outputFilePath)
        {
            await using (var fileStream = File.Create(outputFilePath))
            {
                await content.CopyToAsync(fileStream);
            }
            OpenDocxFile(outputFilePath);
        }

        private static void OpenDocxFile(string filePath)
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

        /// Handle error responses
        private static async Task ProcessError(HttpResponseMessage response)
        {
            Console.Error.WriteLine($"Our call failed: status = {response.StatusCode}");
            Console.Error.WriteLine($"message: {response.ReasonPhrase}");
            string errorMessage = await response.Content.ReadAsStringAsync();
            Console.Error.WriteLine(errorMessage);
        }
    }


}
