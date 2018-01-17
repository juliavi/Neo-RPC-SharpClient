using System;
using System.Threading.Tasks;
using Neo.JsonRpc.Client;
using Neo.RPC.DTOs;
using Neo.RPC.Services.Transactions;
using Xunit;

namespace Neo.RPC.Tests.Testers
{
    public class NeoGetTransactionOutputTester : RpcRequestTester<TransactionOutput>
	{
		[Fact]
		public async void ShouldReturnRawTransaction()
		{
			var result = await ExecuteAsync();
			Assert.NotNull(result);
		}

		public override async Task<TransactionOutput> ExecuteAsync(IClient client)
		{
			var transactionOutput = new NeoGetTransactionOutput(client);
			return await transactionOutput.SendRequestAsync("902bdc8ffaf5f4d7d89d344160d444c1e378e22b6924d18c11131afd1d3312a1"); // todo move to settings
		}

		public override Type GetRequestType()
		{
			return typeof(TransactionOutput);
		}
	}
}
