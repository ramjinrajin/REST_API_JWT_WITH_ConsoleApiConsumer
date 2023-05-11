using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//install https://www.nuget.org/packages/RestSharp
//Install https://www.nuget.org/packages/Newtonsoft.Json/
namespace ConsoleApp1
{

  
     
    class Response
    {
        public string token { get; set; }
        public string expiration { get; set; }
    }


    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public string TemperatureC { get; set; }

        public string TemperatureF { get; set; }

        public string Summary { get; set; }
    }






    class Program
    {
        static void Main(string[] args)
        {

            var client = new RestClient("http://localhost:59921/");
            var request = new RestRequest("api/Authenticate/login", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddJsonBody(new { username = "Ramjin", password = "K2kb2bdbgv@1" });
   
            IRestResponse response = client.Execute(request);
 
         
           Response res= JsonConvert.DeserializeObject<Response>(response.Content);

       
            var request2 = new RestRequest("api/WeatherForecast/Get", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            request2.AddHeader("Authorization", $"Bearer {res.token}");
       

            IRestResponse dataResponse = client.Execute(request2);
            List<WeatherForecast> whetherData = JsonConvert.DeserializeObject<List<WeatherForecast>>(dataResponse.Content);

            Console.WriteLine(JsonConvert.SerializeObject(whetherData));
            Console.ReadLine();
          

        }       


        public void header()
        {
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Content-Length", "295");
            //request.AddHeader("Host", "localhost:59921");
            //request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36");
            //request.AddHeader("Accept", "*/*");
            //request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            //request.AddHeader("Connection", "keep-alive");
        }


    }
}
 