using Neo.JsonRpc.Client;
using Neo.RPC.DTOs;
using Neo.RPC.Services.Account;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Neo.RPC.Tests.Testers.Account
{
    public class NeoGetBalanceTester : RpcRequestTester<WalletBalance>
    {
        const string NEOASSETID = "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b";

        [Fact]
        public async void ShouldReturnWalletBalance()
        {
            var result = await ExecuteAsync();
            Assert.NotNull(result);
        }

        public override async Task<WalletBalance> ExecuteAsync(IClient client)
        {
            var balance = new NeoGetBalance(client);
            return await balance.SendRequestAsync(NEOASSETID);
        }

        public override Type GetRequestType()
        {
            return typeof(WalletBalance);
        }
    }
}
