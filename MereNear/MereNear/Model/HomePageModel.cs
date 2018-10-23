using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MereNear.Model
{
    public class HomePageModel
    {
        public string category_id { get; set; }

        [JsonProperty("name")]
        public string CategoryName { get; set; }

        [JsonProperty("image")]
        public string CategoryImage { get; set; }
    }

    public class GetCatApiModel
    {
        public bool status { get; set; }
        public List<HomePageModel> data { get; set; }
        public string message { get; set; }
    }
}
