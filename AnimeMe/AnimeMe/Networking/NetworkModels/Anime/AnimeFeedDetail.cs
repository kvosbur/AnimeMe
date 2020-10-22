using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeMe.Networking.NetworkModels.Anime
{
    class AnimeFeedDetail
    {
        public string id { get; set; }
        public string nameEnglish { get; set; }
        public string nameJapanese { get; set; }
        public int songCount { get; set; }
        public string image { get; set; }
    }
}
