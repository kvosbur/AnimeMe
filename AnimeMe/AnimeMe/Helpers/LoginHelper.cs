﻿using AnimeMe.Networking;
using AnimeMe.Networking.NetworkModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AnimeMe.Helpers
{

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

        public async Task<LoginResponse> getLoginWithAuth(string authCode)
        {

            HttpResponseMessage result = await get("/user/loginWithAuth", new Dictionary<string, string> { { "authCode", authCode } });

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                LoginReturn returnData = JsonConvert.DeserializeObject<LoginReturn>(content);

                Console.WriteLine(returnData.message + " " + returnData.data.adminType);
                Preferences.Set(SharedPreferences.ADMIN_TYPE, returnData.data.adminType);
                return returnData;
            }
            return null;
        }

        public async Task<LoginResponse> postRegister(string email, string username, string password)
        {
            var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                });

            HttpResponseMessage result = await post("/user/register", formContent);
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
