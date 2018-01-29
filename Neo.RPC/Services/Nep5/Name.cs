using System;
using System.Threading.Tasks;
using Neo.JsonRpc.Client;

namespace Neo.RPC.Services.Nep5
{
    public class Name : RpcRequestResponseHandler<DTOs.Invoke>
    {
        private readonly string _scriptHash;

        public Name(IClient client, string scriptHash) : base(client, ApiMethods.invokefunction.ToString())
        {
            if (string.IsNullOrEmpty(scriptHash)) throw new ArgumentNullException(nameof(scriptHash));
            _scriptHash = scriptHash;
        }

        public Task<DTOs.Invoke> SendRequestAsync(object id = null)
        {
            return base.SendRequestAsync(id, _scriptHash, Nep5Methods.name.ToString());
        }

        public RpcRequest BuildRequest(object id = null)
        {
            return base.BuildRequest(id, _scriptHash, Nep5Methods.name.ToString());
        }
    }
}
