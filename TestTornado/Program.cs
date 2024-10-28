
using System.Diagnostics;

namespace TestTornado
{
    class CSRenderExample
    {

        static async Task Main(string[] args)
        {
            do
            {
                string templateSelection = GetTemplateSelection();
                string outputFormat = GetOutputFormat();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                try
                {
                    await ProcessTemplateRequest(templateSelection, outputFormat, stopwatch);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"ERROR: {e.Message}");
                }
                catch (Exception e)
                {
                    HandleException(e);
                }
                if (!AskToContinue())
                    break;
            } while (true);
        }

        private static bool AskToContinue()
        {
            Console.Out.WriteLine("Press any key to continue or type 'exit' to quit:");
            string userInput = Console.ReadLine();
            return userInput?.ToLower() != "exit";
        }

        private static async Task ProcessTemplateRequest(string templateSelection, string outputFormat, Stopwatch stopwatch)
        {
            string outputFile = $"output_{DateTime.Now:yyyyMMddHHmmss}";
            Dictionary<string, Func<(object? data, string template)>> templateDataMapping = MapTemplateGenerator();
            if (!templateDataMapping.TryGetValue(templateSelection, out var dataTemplateFunc))
            {
                throw new ArgumentException("Invalid type specified");
            }
            // Execute the Func to get the data and template only if the type is valid
            var myDataTemplate = dataTemplateFunc.Invoke();
            if (myDataTemplate.data == null)
            {
                throw new ApplicationException("No data prepared");
            }
            DocmosisRequest docmosisRequest = new DocmosisRequest()
            {
                TemplateName = myDataTemplate.template,
                OutputFileName = outputFile,
                OutputFormat = outputFormat,
                InputData = myDataTemplate.data
            };
            var responseStream = await DocmosisClient.SendRequestAsync(docmosisRequest);
            if (responseStream != null)
            {
                await DocumentHandler.SaveToFileAsync(responseStream, $"{outputFile}.{outputFormat}");
                Console.Out.WriteLine($"File saved as {outputFile}");
                Console.Out.WriteLine($"Time Used milliseconds: {stopwatch.ElapsedMilliseconds}");          
            }
        }
           

        private static string GetTemplateSelection()
        {
            Console.WriteLine("Select the form type: \n" +
                                      "'0' for Repeating \n" +
                                      "'1' for GI19FDMSO1 \n" +
                                      "'2' for GNIR24AP01 \n" +
                                      "'3' for EAW18AR01 \n" +
                                      "'4' for HK23NAR1 \n" +
                                      "'5' for prefilled pdf");
            return Console.ReadLine();
            
        }

        private static string GetOutputFormat()
        {
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
            return outputFormat;
        }

        private static void HandleException(Exception e)
        {
            if (e is HttpRequestException httpRequestException)
            {
                Console.WriteLine($"ERROR: {httpRequestException.Message}");
            }
            else
            {
                Console.Error.WriteLine("An error occurred: " + e.Message);
                Console.Error.WriteLine(e.StackTrace);
                Console.Error.WriteLine("If you have a proxy, configure proxy settings at the top of this example.");
            }
        }

        private static Dictionary<string, Func<(object? data, string template)>> MapTemplateGenerator()
        {
            return new Dictionary<string, Func<(object? data, string template)>>
            {
                { "0", () => (TestTornado.Forms.Repeating.DataGenerator.GetData(), "REPEATINGTEMPLATE.DOCX") },
                { "1", () => (TestTornado.Forms.GI19FDMS01.DataGenerator.GetData(), "GI19FDMS01.DOCX") },
                { "2", () => (TestTornado.Forms.GNIR24AP01.DataGenerator.GetData(), "GNIR24AP01.DOCX") },
                { "3", () => (TestTornado.Forms.EAW18AR01.DataGenerator.GetData(), "EAW18AR01.DOCX") },
                { "4", () => (TestTornado.Forms.HK23NAR1.DataGenerator.GetData(), "HK23NAR1.DOCX") },
                { "5", () => (TestTornado.Forms.PrefilledPDF.DataGenerator.GetData(), "pre-filled-pdf.odt") }
            };
        }   
    }
}
