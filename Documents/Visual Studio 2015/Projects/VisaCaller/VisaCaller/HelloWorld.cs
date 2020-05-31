using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisaCaller.Helper;

namespace VisaCaller
{
    class HelloWorld
    {
        private VisaApiClient visaAPIClient;
        public HelloWorld()
        {
            visaAPIClient = new VisaApiClient();
            string strDate = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss");
        }

        public void TestHelloWorld()
        {
            string baseUri = "vdp/";
            string resourcePath = "helloworld";
            string status = visaAPIClient.DoMutualAuthCall(baseUri + resourcePath, "GET", "HELLO WORLD","");
            Console.WriteLine(status);
        }
    }
}
