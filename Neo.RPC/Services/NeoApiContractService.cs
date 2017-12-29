using Neo.JsonRpc.Client;
using Neo.RPC.Services.Contract;

namespace Neo.RPC.Services
{
    public class NeoApiContractService : RpcClientWrapper
    {
        public NeoApiContractService(IClient client) : base(client)
        {
            GetContractState = new NeoGetContractState(client);
        }

        public NeoGetContractState GetContractState { get; set; }
    }
}
