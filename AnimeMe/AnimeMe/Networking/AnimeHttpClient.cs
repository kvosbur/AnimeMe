﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnimeMe.Networking
{
    public class AnimeHttpClient
    {

        private HttpClient httpClient;
        private Uri BASE_URL = new Uri("https://kevinvosburgh.com:40000");

        public AnimeHttpClient()
        {
            httpClient = new HttpClient();
        }

        protected async Task<string> get(string path, Dictionary<string, string> headers)
        {
            Uri uri = new Uri(BASE_URL, path);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            foreach(KeyValuePair<string, string> header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            HttpResponseMessage responseMessage = await httpClient.SendAsync(request);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsStringAsync();
            }
            return null;
        }

        protected async Task<string> get(string path)
        {
            Uri uri = new Uri(BASE_URL, path);

            HttpResponseMessage responseMessage = await httpClient.GetAsync(uri);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsStringAsync();
            }
            return null;
        }

        protected async Task<HttpResponseMessage> post(string path, FormUrlEncodedContent content)
        {
            Uri uri = new Uri(BASE_URL, path);


            HttpResponseMessage responseMessage = await httpClient.PostAsync(uri, content);
            return responseMessage;
        }
    }
}
