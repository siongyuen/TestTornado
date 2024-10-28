using System.Text;
using System.Text.Json;

namespace TestTornado
{
    public class DocmosisClient

    {
        private static string DWS_RENDER_URL = "http://my-docmosis.westeurope.azurecontainer.io:8080/api/render";
        // Set your access key here. The access key is only required if configured in Tornado.
        private const string ACCESS_KEY = "";
        // The output format we want to produce (pdf, doc, odt, and more exist)
        private const string OUTPUT_FORMAT = "docx";
        // The name of the file we are going to write the document to
        private const string OUTPUT_FILE = "Output." + OUTPUT_FORMAT;
        /// Sends the request to the server and returns the response stream.
        public static async Task<Stream> SendRequestAsync(DocmosisRequest docmosisRequest)
        {

            using (HttpClient client = new HttpClient())
            {
                string renderRequest = BuildRequest(docmosisRequest);

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
        private static string BuildRequest(DocmosisRequest docmosisRequest)
        {
         

            var requestObject = new
            {
                accessKey = ACCESS_KEY,
                templateName = docmosisRequest.TemplateName,
                outputName = docmosisRequest.OutputFileName,
                outputFormat = docmosisRequest.OutputFormat,
                data = docmosisRequest.InputData
            };

            return JsonSerializer.Serialize(requestObject, new JsonSerializerOptions { WriteIndented = true });
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
