using Newtonsoft.Json;
using Ditch.EOS.Models;

namespace Eos.Airdrop.Manager.Contract.EosioToken.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Transfer
    {
        [JsonProperty("from")]
        public BaseName From {get; set;}

        [JsonProperty("to")]
        public BaseName To {get; set;}

        [JsonProperty("quantity")]
        public Asset Quantity {get; set;}

        [JsonProperty("memo")]
        public string Memo {get; set;}

    }
}
