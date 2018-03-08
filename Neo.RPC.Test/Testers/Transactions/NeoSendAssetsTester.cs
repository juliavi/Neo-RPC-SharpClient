using Neo.JsonRpc.Client;
using Neo.RPC.Services;
using System;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;

namespace Neo.RPC.Tests.Testers.Transactions
{
    public class NeoSendAssetsTester : RpcRequestTester<Transaction>
    {
        const string NEOASSETID = "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b";
        const string ADDRESS = "AK4if54jXjSiJBs6jkfZjxAastauJtjjse";

        [Fact]
        public async void ShouldReturnWalletBalance()
        {
            var result = await ExecuteAsync();
            Assert.NotNull(result);
        }

        public override async Task<Transaction> ExecuteAsync(IClient client)
        {
            var sendAssets = new NeoSendAssets(client);
            return await sendAssets.SendRequestAsync(NEOASSETID, ADDRESS, 1);
        }

        public override Type GetRequestType()
        {
            return typeof(Transaction);
        }
    }
}
