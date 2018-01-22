using Neo.JsonRpc.Client;
using Neo.RPC.Services.Contract;

namespace Neo.RPC.Services
{
    public class NeoApiStorageService : RpcClientWrapper
    {
        public NeoApiStorageService(IClient client) : base(client)
        {
            GetStorage = new NeoGetStorage(client);
        }

        public NeoGetStorage GetStorage { get; set; }
    }
}
