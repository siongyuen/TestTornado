using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Diagnostics;
using TestTornado.Models;

namespace TestTornado
{
    
 
    /// 

    /// This sample code shows a render of the "WelcomeTemplate.docx" template using JSON format
    /// instruction and data via the local Tornado server (localhost:8080).
    ///
    /// If you wish to test via a web proxy server, see the PROXY_* settings below to enable it.
    /// 

    ///
    /// Copyright Docmosis 2015
    ///
    class CSRenderExample
    {
        private static string DWS_RENDER_URL = "http://localhost:8080/api/render";

        // Set your access key here.  The access key is only required if configured in Tornado.
        private const string ACCESS_KEY = "";

        // The output format we want to produce (pdf, doc, odt and more exist)
        private const string OUTPUT_FORMAT = "docx";

        // the name of the template (stored in Tornado) to use
        private const string TEMPLATE = "samples/RepeatingTemplate.DOCX";

        // the name of the file we are going to write the document to
        private const string OUTPUT_FILE = "RepeatingTemplate." + OUTPUT_FORMAT;

        // Proxy settings if needed to reach the internet
        private const string PROXY_HOST = "";
        private const string PROXY_PORT = "";
        private const string PROXY_USER = "";
        private const string PROXY_PASSWD = "";

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            HttpWebResponse response;
            try
            {
                response = sendRequest();
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        SaveToFileAsync(response.GetResponseStream(), OUTPUT_FILE);
                    }
                    else
                    {
                        processError(response);
                    }
                }
                finally
                {
                    response.Close();
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("ERROR:" + e.Message);
                using (WebResponse webResponse = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webResponse;
                    processError(httpResponse);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Unable to connect to Docmosis: " + e.Message);
                Console.Error.WriteLine(e.StackTrace);
                Console.Error.WriteLine("If you have a proxy, configure proxy settings at the top of this example.");
                Console.ReadKey();
                System.Environment.Exit(2);
            }
            Console.Out.WriteLine($"Time Used miliseconds: {stopwatch.ElapsedMilliseconds}"); 
            Console.Out.WriteLine("Press any key");
            Console.ReadKey();
        }

        /// 

        /// Sends the request to the server and returns the response.
        /// 

        /// 
        /// the response returned by the server
        /// 
        static HttpWebResponse sendRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(DWS_RENDER_URL);
            if (PROXY_HOST.Length != 0)
            {
                WebProxy proxy = new WebProxy(PROXY_HOST + ":" + PROXY_PORT, true);
                if (PROXY_USER.Length != 0)
                {
                    proxy.Credentials = new NetworkCredential(PROXY_USER, PROXY_PASSWD);
                }
                Console.WriteLine(proxy.Address);
                request.Proxy = proxy;
            }

            string renderRequest = BuildRequest();
        
            byte[] data = new UTF8Encoding().GetBytes(renderRequest);

            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = data.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);

            return (HttpWebResponse)request.GetResponse();
        }

        /// 

        /// Build the request in JSON format. You can do it in XML if you prefer (code not shown here).
        /// 

        private static string BuildRequest()
        {
            var requestObject = new
            {
                accessKey = ACCESS_KEY,
                templateName = TEMPLATE,
                outputName = OUTPUT_FILE,
                outputFormat = OUTPUT_FORMAT,
                data = DataGenerator.GetCustomers()
            };
            return JsonSerializer.Serialize(requestObject, new JsonSerializerOptions { WriteIndented = true });
        }


        private static async Task SaveToFileAsync(Stream content, string outputFilePath)
        {
            // Ensure that resources are properly disposed of when done
            await using (var fileStream = File.Create(outputFilePath))
            {
                // Asynchronously copy the content to the output file
                await content.CopyToAsync(fileStream);
            }

            Console.WriteLine($"Created file: {outputFilePath}");
        }


        /// 

        ///  Something went wrong in the call to the service, tell the user about it
        /// 

        ///The response causing errors
        private static void processError(HttpWebResponse response)
        {
            Console.Error.WriteLine("Our call failed: status = {0}", response.StatusCode);
            Console.Error.WriteLine("message:" + response.StatusDescription);
            StreamReader errorReader = new StreamReader(response.GetResponseStream());
            String msg;
            while ((msg = errorReader.ReadLine()) != null)
            {
                Console.Error.WriteLine(msg);
            }
        }
    }
}