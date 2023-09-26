using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace http_server
{
    public class Appsetting
    {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("port")]
        public int Port { get; set; }
        [JsonProperty("static_Files_Path")]
        public string staticPathFiles { get; set; }
    }

}
