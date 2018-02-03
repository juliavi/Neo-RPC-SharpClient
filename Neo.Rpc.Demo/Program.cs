using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Neo.JsonRpc.Client;
using Neo.RPC.Services;

namespace Neo.Rpc.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                InvokeScript().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an exception: {ex.ToString()}");
            }
        }

        public static async Task InvokeScript()
        {
            var client = new RpcClient(new Uri("http://seed5.neo.org:10332"));
            var scriptHash = "08e8c4400f1af2c20c28e0018f29535eb85d15b6"; //TNC token
            var nep5Service = new NeoNep5Service(client, scriptHash);
            var name = await nep5Service.GetName();
            var decimals = await nep5Service.GetDecimals();
            var totalsupply = await nep5Service.GetTotalSupply(decimals);
            var symbol = await nep5Service.GetSymbol();
            var balance = await nep5Service.GetBalance("0x0ff9070d64d19076d08947ba4a82b72709f30baf", decimals);    

            Debug.WriteLine($"Token info: \nName: {name} \nSymbol: {symbol} \nDecimals: {decimals} \nTotalSupply: {totalsupply} \nBalance: {balance}");
        }
    }
}
