using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Weather.bll
{
    public class FileManager
    {
        public void SaveDataJSON(string cityName, WeatherDataModel data)
        {
            lock (this)
            {
                string fileName = $"{cityName}_{DateTime.Now.ToString("MM-dd-yyyy")}.wdr";

                if (System.IO.File.Exists(fileName))
                    throw new Exception("The File Already Exists!");

                DataContractJsonSerializer formatter = new DataContractJsonSerializer(data.GetType());
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    formatter.WriteObject(fs, data);
                }
            }
        }
        public WeatherDataModel ReadDataJSON(string cityName)
        {
            string fileName = $"{cityName}_{DateTime.Now.ToString("MM-dd-yyyy")}.wdr";
            if (System.IO.File.Exists(fileName))
            {
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(WeatherDataModel));
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    return (WeatherDataModel)formatter.ReadObject(fs);
                }
            }
            return null;
        }
    }
}
