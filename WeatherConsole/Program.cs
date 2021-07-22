using System;
using System.Threading.Tasks;
using Weather.bll;

namespace WeatherConsole
{
    class Program
    {
        private static string ExitKey = "exit";
        static async Task Main(string[] args)
        {

            FileManager fileManager = new FileManager();
            RequestManager requestManager = new RequestManager();

            string inputText = string.Empty;

            while (inputText != ExitKey)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Please input city or write 'exit' to exit");
                Console.ResetColor();
                inputText = Console.ReadLine();
                if (inputText == ExitKey)
                {
                    return;
                }

                var data = fileManager.ReadDataJSON(inputText);
                if(data==null)
                {
                    data = await requestManager.GetDataFromApi(inputText);
                    if (data != null)
                        fileManager.SaveDataJSON(inputText, data);
                }
                if (data == null)
                {
                    Console.Beep(5000,1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" City not exist in our records");
                    Console.ResetColor();
                }
                    
                else
                    Console.WriteLine(data.ToString());

            }
        }
    }
}
