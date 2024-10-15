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
          

            try
            {
                Console.WriteLine("Type \n" +
                                "'0' for Repeating \n" +
                                "'1' for GI19FDMSO1 \n" +
                                "'2' for GNIR24AP01");
                string type = Console.ReadLine();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var responseStream = await SendRequestAsync(type);
                if (responseStream != null)
                {
                    await SaveToFileAsync(responseStream, OUTPUT_FILE);
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

            Console.Out.WriteLine($"Time Used milliseconds: {stopwatch.ElapsedMilliseconds}");
            Console.Out.WriteLine("Press any key");
            Console.ReadKey();
        }

        /// Sends the request to the server and returns the response stream.
        private static async Task<Stream> SendRequestAsync(string type)
        {
            using (HttpClient client = new HttpClient())
            {
                string renderRequest = BuildRequest(type);

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
        private static string BuildRequest(string type )
        {
            object? myData=null;
            string template=string.Empty;
            if (type == "0")
            {
                myData = Forms.Repeating.DataGenerator.GetData();
                template = "samples/RepeatingTemplate.docx";
            }
            else if (type == "1")
            {
                myData = TestTornado.Forms.GI19FDMS01.DataGenerator.GetData();
                template = "samples/GI19FDMS01.DOCX";
            }
            else if (type == "2")
            {
                myData = TestTornado.Forms.GNIR24AP01.DataGenerator.GetData();
                template = "samples/GNIR24AP01.DOCX";
            }
           


            var requestObject = new
            {
                accessKey = ACCESS_KEY,
                templateName = template,
                outputName = OUTPUT_FILE,
                outputFormat = OUTPUT_FORMAT,
                data = myData
            };

            return JsonSerializer.Serialize(requestObject, new JsonSerializerOptions { WriteIndented = true });
        }

        private static async Task SaveToFileAsync(Stream content, string outputFilePath)
        {
            await using (var fileStream = File.Create(outputFilePath))
            {
                await content.CopyToAsync(fileStream);
            }

            Console.WriteLine($"Created file: {outputFilePath}");
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
