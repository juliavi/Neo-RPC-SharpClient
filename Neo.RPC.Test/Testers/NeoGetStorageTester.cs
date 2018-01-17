using System;
using System.Threading.Tasks;
using Neo.JsonRpc.Client;
using Neo.RPC.Services.Storage;
using Xunit;

namespace Neo.RPC.Tests.Testers
{
	public class NeoGetStorageTester : RpcRequestTester<string> //todo
	{
		[Fact]
		public async void ShouldReturnStorage()
		{
			var result = await ExecuteAsync();
			Assert.NotNull(result);
		}

		public override async Task<string> ExecuteAsync(IClient client)
		{
			var contractState = new NeoGetStorage(client);
			return await contractState.SendRequestAsync("todo", "todo");
		}

		public override Type GetRequestType()
		{
			return typeof(string);
		}
	}
}
