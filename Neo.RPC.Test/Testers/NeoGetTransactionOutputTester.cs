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
        public async void ShouldReturnTransactionOutput()
        {
            var result = await ExecuteAsync();
            Assert.NotNull(result);
        }

        public override async Task<TransactionOutput> ExecuteAsync(IClient client)
        {
            var transactionOutput = new NeoGetTransactionOutput(client);
            return await transactionOutput.SendRequestAsync(
                "5175ae08bc12988cb55c7ec5978245763d946658383b2ff51899ac244c894f32"); // todo move to settings
        }

        public override Type GetRequestType()
        {
            return typeof(TransactionOutput);
        }
    }
}