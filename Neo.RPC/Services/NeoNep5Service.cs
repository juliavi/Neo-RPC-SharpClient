using System.Threading.Tasks;
using Neo.JsonRpc.Client;
using Neo.RPC.DTOs;
using Neo.RPC.Helpers;
using Name = Neo.RPC.Services.Nep5.Name;

namespace Neo.RPC.Services
{
    public class NeoNep5Service : RpcClientWrapper
    {
        public NeoNep5Service(IClient client, string scriptHash) : base(client)
        {
            Nep5Name = new Name(client, scriptHash);
        }

        public async Task<string> GetNep5Name()
        {
            string name = string.Empty;
            Invoke result = await Nep5Name.SendRequestAsync();
            if (result != null)
            {
                string nameBytes = result.Stack[0].Value.ToString();
                name = Helper.HextoString(nameBytes);
            }         
            return name;
        }

        public Name Nep5Name { get; set; }
    }
}
