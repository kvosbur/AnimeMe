using AnimeMe.Networking;
using AnimeMe.Networking.NetworkModels.Anime;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AnimeMe.Helpers
{
    class AnimeHelper: AnimeHttpClient
    {
        public async Task<string> postDetail(string animeNameEN, string animeNameJP, string releaseDate, string animeImage)
        {
            var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("animeNameEN", animeNameEN),
                    new KeyValuePair<string, string>("animeNameJP", animeNameJP),
                    new KeyValuePair<string, string>("releaseDate", releaseDate),
                    new KeyValuePair<string, string>("animeImage", animeImage),
                });

            var authCode = Preferences.Get(SharedPreferences.AUTH_CODE, string.Empty);

            HttpResponseMessage result = await post("/anime/detail", formContent, new Dictionary<string, string> { { "authCode", authCode } });
            string content = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                var returnData = JsonConvert.DeserializeObject<AnimeBasePost>(content);

                Console.WriteLine(returnData.message);
                return returnData.message;
            }
        }
    }
}
