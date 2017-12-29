using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Neo.RPC.Services.Contract
{/// <Summary>
 ///     invoke    
 ///     Returns the result after calling a smart contract at scripthash with the given parameters.
 ///     <note type="important">
 ///     This method is to test your VM script as if they were ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.
 ///     </note>
 /// 
 ///     Parameters
 ///     Scripthash: Smart contract scripthash
 ///     Operation: The operation name (string)
 ///     Params: The parameters to be passed into the smart contract operatio
 /// 
 ///     Example
 ///     Request
 ///     curl -X POST --data '{"jsonrpc":"2.0","method":"invoke",
 ///         "params":["ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
 ///                 balanceOf,
 ///             [
 ///                 {
 ///                     "type": "Hash160",
 ///                     "value": "bfc469dd56932409677278f6b7422f3e1f34481d"
 ///                 }
 ///             ]
 ///         ],
 ///         "id":3}'
 /// 
 ///     Result
 ///     {
 ///     "jsonrpc": "2.0",
 ///     "id": 3,
 ///     "result": {
 ///         "state": "HALT, BREAK",
 ///         "gas_consumed": "0.338",
 ///         "stack": [
 ///             {
 ///                 "type": "ByteArray",
 ///                 "value": "00e1f505"
 ///             }
 ///         ]
 ///     }
 /// }
 /// </Summary>   
    public class NeoInvokeFunction
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("gas_consumed")]
        public string GasConsumed { get; set; }

        [JsonProperty("stack")]
        public List<Stack> Stack { get; set; }
    }

    public class Stack
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
