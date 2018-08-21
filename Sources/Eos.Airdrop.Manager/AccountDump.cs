using System;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Eos.Airdrop.Manager
{
    public class AccountDump
    {
        public DateTime CreationTime { get; set; }

        public string AccountName { get; set; }

        public Asset TotalEos { get; set; }

        public AirdropState AirdropState { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Asset Airdrop { get; set; }
        
        public string Exception { get; set; }
    }


    [JsonConverter(typeof(EnumConverter))]
    [Flags]
    public enum AirdropState : byte
    {
        None = 0,
        Selected = 1,
        Skeeped = 2,
        Started = 4,
        Ready = 8,
        Error = 16,
    }
}
