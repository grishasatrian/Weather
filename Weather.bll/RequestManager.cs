using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Weather.bll
{
    
    public class RequestManager
    {
        private const string ApiUri = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid=3334ccf4d292ce24b2e21adebefa94d2&units=metric";
        private HttpClient client;
        public RequestManager()
        {
            client = new HttpClient();
        }

        
        public async Task<WeatherDataModel> GetDataFromApi(string cityName)
        {
            try
            {
                var response = await client.GetAsync(string.Format(ApiUri, cityName));
                response.EnsureSuccessStatusCode();
                var strData = await response.Content.ReadAsStringAsync();
                var retValue = deserializeJsonString(strData);
                return retValue;
            }
            catch
            {

            }
            return null;
        }

        private WeatherDataModel deserializeJsonString(string json)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var deserializer = new DataContractJsonSerializer(typeof(WeatherDataModel));
                return (WeatherDataModel)deserializer.ReadObject(ms);
            }
        }
    }
}
