using AnimeMe.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AnimeMe.Helpers
{
    public class LoginData
    {
        public string authCode { get; set; }
        public int adminType { get; set; }
    }

    public class LoginResponse
    {
        public string message { get; set; }
        public int statusCode { get; set; }
    }

    public class LoginReturn : LoginResponse
    {
        
        public LoginData data { get; set; }
    }

    public class LoginErrorResponse : LoginResponse
    {
        public string data { get; set; }
    }

    public class LoginHelper : AnimeHttpClient
    {

        public async Task<LoginResponse> postLogin(string username, string password)
        {
            var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                });

            HttpResponseMessage result = await post("/user/login", formContent);
            string content = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                LoginReturn returnData = JsonConvert.DeserializeObject<LoginReturn>(content);

                Console.WriteLine(returnData.message + " " + returnData.data.authCode);
                Preferences.Set(SharedPreferences.AUTH_CODE, returnData.data.authCode);
                Preferences.Set(SharedPreferences.ADMIN_TYPE, returnData.data.authCode);
                return returnData;
            }
            else
            {
                LoginErrorResponse returnData = JsonConvert.DeserializeObject<LoginErrorResponse>(content);

                Console.WriteLine(returnData.message + " " + returnData.statusCode);
                return returnData;
            }

            
        } 
    }
}
