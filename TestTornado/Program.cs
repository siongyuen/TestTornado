﻿using System;
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
          
                Console.WriteLine("Type \n" +
                                  "'0' for Repeating \n" +
                                  "'1' for GI19FDMSO1 \n" +
                                  "'2' for GNIR24AP01 \n" +
                                  "'3' for EAW18AR01 \n" +
                                  "'4' for HK23NAR1 ");
                string type = Console.ReadLine();
            do
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                try
                {
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
                type = Console.ReadLine();

            } while (true);
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
        private static string BuildRequest(string type)
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
                outputName = OUTPUT_FILE,
                outputFormat = OUTPUT_FORMAT,
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
