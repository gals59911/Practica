using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string a_token = "";
            var client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri("https://localhost:7030/api/auth/token");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var tokenRequest = new TokenRequest
                {
                    username = "correct_username",
                    password = "correct_password",
                    grant_type = "password"
                };
                var content = new StringContent(JsonConvert.SerializeObject(tokenRequest), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("token", content);
                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = await response.Content.ReadAsStringAsync();
                    a_token = tokenResponse.Substring(17, 36);
                    //Console.WriteLine(a_token);
                    Console.WriteLine(tokenResponse);
                }
                else
                {
                    Console.WriteLine($"Error: { response.ReasonPhrase}");
                }
                
            }
            catch
            {
                Console.WriteLine("Неверный логин или пароль");
            }
            Console.WriteLine("Выберите:\n 1) Справочник кодов для датчиков \n 2) Передача текущих данных \n 3) Передача архивных данных");
            switch (int.Parse(Console.ReadLine()))
            {

                case 1:

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", a_token);
                    HttpResponseMessage r1 = await client.GetAsync("https://localhost:7030/api/data/voc");
                    if (r1.IsSuccessStatusCode)
                    {

                        string con = await r1.Content.ReadAsStringAsync();
                        Console.WriteLine("Ответ сервера:");
                        Console.WriteLine(con);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при отправке запроса. Код ошибки: " + r1.StatusCode);
                    }
                    break;

                case 2:
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", a_token);
                    OnlineDataRequest requestData = new OnlineDataRequest
                    {
                        Rig = 1,
                        Codes = new int[] { 6, 7 },
                        Values = new double[] { 29.5, 30.5 }
                    };

                    string json = JsonConvert.SerializeObject(requestData);
                    var c = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage r2 = await client.PostAsync("https://localhost:7030/api/data/online", c);
                    if (r2.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Запрос успешно отправлен");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при отправке запроса. Код ошибии: " + r2.StatusCode);
                    }
                    break;

                case 3:
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", a_token);
                    ArchiveDataRequest request_Data = new ArchiveDataRequest
                    {
                        Rig = 1,
                        Codes = new int[] { 6, 7 },
                        Data= new List<ArchiveDataEntry> { new ArchiveDataEntry {Date = 154562890800, Values=new double[] { 29.5, 1.5 } }, 
                            new ArchiveDataEntry { Date = 1545628909000, Values = new double[] { 30.5, 1.5 } }, }
                    };

                    string jso = JsonConvert.SerializeObject(request_Data);
                    var co = new StringContent(jso, Encoding.UTF8, "application/json");

                    HttpResponseMessage r3 = await client.PostAsync("https://localhost:7030/api/data/archive", co);
                    if (r3.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Запрос успешно отправлен");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при отправке запроса. Код ошибии: " + r3.StatusCode);
                    }
                    break;




                default:

                    Console.WriteLine("Такой опции нет");
                    break;

            }




        }
        public class OnlineDataRequest
        {
            public int Rig { get; set; }
            public int[] Codes { get; set; }
            public double[] Values { get; set; }
        }
       

        public class ArchiveDataEntry
        {
            public long Date { get; set; }
            public double[] Values { get; set; }
        }
        public class ArchiveDataRequest
        {
            public int Rig { get; set; }
            public int[] Codes { get; set; }
            public List<ArchiveDataEntry> Data { get; set; }
        }
        public class TokenRequest
        {
            public string username { get; set; }
            public string password { get; set; }
            public string grant_type { get; set; }
        }
    }
}
