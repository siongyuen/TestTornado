using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TestTornado
{
    class CSRenderExample
    {
        private static string DWS_RENDER_URL = "http://localhost:8080/api/render";

        // Set your access key here. The access key is only required if configured in Tornado.
        private const string ACCESS_KEY = "";

        // The output format we want to produce (pdf, doc, odt, and more exist)
        private const string OUTPUT_FORMAT = "docx";

        // The name of the template (stored in Tornado) to use
        private const string TEMPLATE = "samples/RepeatingTemplate.DOCX";

        // The name of the file we are going to write the document to
        private const string OUTPUT_FILE = "RepeatingTemplate." + OUTPUT_FORMAT;

        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                var responseStream = await SendRequestAsync();
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
        private static async Task<Stream> SendRequestAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string renderRequest = BuildRequest();

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
        private static string BuildRequest()
        {
            var requestObject = new
            {
                accessKey = ACCESS_KEY,
                templateName = TEMPLATE,
                outputName = OUTPUT_FILE,
                outputFormat = OUTPUT_FORMAT,
                data =  DataGenerator.GetData()
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
