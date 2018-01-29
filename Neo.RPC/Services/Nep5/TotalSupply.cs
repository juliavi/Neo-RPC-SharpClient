using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Neo.JsonRpc.Client;

namespace Neo.RPC.Services.Nep5
{
    public class TotalSupply : RpcRequestResponseHandler<BigInteger>
    {
        public TotalSupply(IClient client, string methodName) : base(client, methodName)
        {
        }
    }
}
