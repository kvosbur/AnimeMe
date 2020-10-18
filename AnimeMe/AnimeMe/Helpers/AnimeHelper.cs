using AnimeMe.Networking;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeMe.Helpers
{
    class AnimeHelper: AnimeHttpClient
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
                Preferences.Set(SharedPreferences.ADMIN_TYPE, returnData.data.adminType);
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
