using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MereNear.Services.ApiService.Common
{
    public class BaseHttpResponse
    {
        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }

        [JsonProperty("response_message")]
        public string ResponseMessage { get; set; }
    }
}
