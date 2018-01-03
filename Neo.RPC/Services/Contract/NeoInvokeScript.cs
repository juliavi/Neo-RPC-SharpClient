using Neo.JsonRpc.Client;

namespace Neo.RPC.Services.Contract
{
	public class NeoInvokeScript : RpcRequestResponseHandler<DTOs.Invoke>
	{
		public NeoInvokeScript(IClient client) : base(client, ApiMethods.invokescript.ToString())
		{
		}
	}
}
