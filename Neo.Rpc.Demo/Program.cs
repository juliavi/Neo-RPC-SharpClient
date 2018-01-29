using System;
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
            var scriptHash = "b951ecbbc5fe37a9c280a76cb0ce0014827294cf";
            var nep5Service = new NeoNep5Service(client, scriptHash);
            var result = await nep5Service.GetNep5Name();
        }
    }
}
