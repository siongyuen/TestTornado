using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.Json;

namespace TestTornado
{
    public class Customers
    {
        public List<Customer> customers { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool OutOfStock { get; set; }
    }

 
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

        private static string BuildRequest2()
        {
            var requestObject = new
            {
                accessKey = ACCESS_KEY,
                templateName = TEMPLATE,
                outputName = OUTPUT_FILE,
                outputFormat = OUTPUT_FORMAT,
                data = new[]
                {
                    new Product{
                        Name = "Laptop",
                        Id = "P001",
                        Quantity = 1,
                        Price = 1000m,
                        Discount = 100m,
                        OutOfStock = false
                    }
                }
                
            };

            return JsonSerializer.Serialize(requestObject, new JsonSerializerOptions { WriteIndented = true });
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
                data = new
                {
                    customers = new List<Customer>
            {
                new Customer
                {
                    Name = "约翰亨利 John Henry",
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = "Laptop", Id = "P001", Quantity = 1, Price = 1000m, Discount = 100m, OutOfStock = false
                        },
                        new Product
                        {
                            Name = "Mouse", Id = "P002", Quantity = 2, Price = 25m, Discount = 0m, OutOfStock = false
                        },
                        new Product
                        {
                            Name = "Keyboard", Id = "P003", Quantity = 1, Price = 50m, Discount = 0m, OutOfStock = false
                        },
                         new Product
                        {
                            Name = "Laptop 2", Id = "P004", Quantity = 1, Price = 3000m, Discount = 10m, OutOfStock = false
                        },
                        new Product
                        {
                            Name = "Mouse 2", Id = "P005", Quantity = 2, Price = 25m, Discount = 0m, OutOfStock = false
                        },
                        new Product
                        {
                            Name = "Keyboard 2", Id = "P006", Quantity = 1, Price = 50m, Discount = 0m, OutOfStock = false
                        }
                    }
                },
                new Customer
                {
                    Name = "Jane Smith",
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = "Smartphone", Id = "P004", Quantity = 1, Price = 800m, Discount = 50m, OutOfStock = false
                        },
                        new Product
                        {
                            Name = "Charger", Id = "P005", Quantity = 1, Price = 20m, Discount = 0m, OutOfStock = true
                        },
                             new Product
                        {
                            Name = "Smartphone 2", Id = "P006", Quantity = 1, Price = 800m, Discount = 50m, OutOfStock = false
                        },
                        new Product
                        {
                            Name = "Charger 2", Id = "P005", Quantity = 1, Price = 20m, Discount = 0m, OutOfStock = true
                        }

                    }
                },
                new Customer
                {
                    Name = "Alice Johnson",
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = "Tablet", Id = "P006", Quantity = 1, Price = 300m, Discount = 25m, OutOfStock = false
                        },
                        new Product
                        {
                            Name = "Tablet Case", Id = "P007", Quantity = 1, Price = 30m, Discount = 5m, OutOfStock = false
                        },
                        new Product
                        {
                            Name = "Stylus Pen", Id = "P008", Quantity = 1, Price = 15m, Discount = 0m, OutOfStock = true
                        },
                            new Product
                        {
                            Name = "Tablet 2", Id = "P016", Quantity = 1, Price = 1500m, Discount = 10m, OutOfStock = false
                        },
                        new Product
                        {
                            Name = "Tablet Case 2", Id = "P007", Quantity = 1, Price = 30m, Discount = 5m, OutOfStock = false
                        },
                        new Product
                        {
                            Name = "Stylus Pen 2", Id = "P008", Quantity = 1, Price = 15m, Discount = 0m, OutOfStock = true
                        }
                    }
                }
            }
                }
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