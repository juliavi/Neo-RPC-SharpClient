using System.Threading.Tasks;
using Neo.JsonRpc.Client;
using Neo.RPC.Helpers;
using Neo.RPC.Services.Nep5;

namespace Neo.RPC.Services
{
    public class NeoNep5Service : RpcClientWrapper
    {
        public NeoNep5Service(IClient client, string scriptHash) : base(client)
        {
            GetTokenName = new TokenName(client, scriptHash);
        }

        public async Task<string> GetNep5Name()
        {
            string name = string.Empty;
            var result = await GetTokenName.SendRequestAsync();
            if (result != null)
            {
                string nameBytes = result.Stack[0].Value.ToString();
                name = Helper.HextoString(nameBytes);
            }         
            return name;
        }

		public async Task<string> GetNep5TotalSupply()
		{
			string name = string.Empty;
			var result = await GetTokenName.SendRequestAsync();
			if (result != null)
			{
				string nameBytes = result.Stack[0].Value.ToString();
				name = Helper.HextoString(nameBytes);
			}
			return name;
		}

		public TokenName GetTokenName { get; set; }
		public TokenTotalSupply GetTokenTotalSupply { get; set; }
    }
}
