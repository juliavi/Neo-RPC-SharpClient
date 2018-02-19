<p align="center">
  <img
    src="http://res.cloudinary.com/vidsy/image/upload/v1503160820/CoZ_Icon_DARKBLUE_200x178px_oq0gxm.png"
    width="125px;">
</p>

<h1 align="center">Neo-RPC-SharpClient</h1>

<p align="center">
  Modular RPC client for C# <b>NEO</b> blockchain.
</p>

<p align="center">
  <b>Still on testing phase, do not use it on the MainNet!</b>
</p>


</p>


## Update
This project is now available as a nuget [package](https://www.nuget.org/packages/Neo.RPC)!

## Overview

This project aims to be a full RPC client for the NEO network created in C# and inspired by [Nethereum](https://github.com/Nethereum/Nethereum). You can use it support your mobile wallet, websites, neo blockchain data gathering, etc. 

### What does it currently do
- RPC Client

### What will it do
- After proper testing, will create a Nuget package for easy C# projects integration


Develop with decoupling in mind to make maintenance and new RPC methods implemented more quickly:

* Client base - Neo.JsonRpc.Client project
* RPC client implementation - Neo.JsonRpc.RpcClient project
* DTO'S, Services, Helpers - Neo.RPC (main project)
* Tests - Neo.RPC.Tests
* Demo - Simple demonstration project

## Quick Start

Setup the rpc client node

```C#
var rpcClient = new RpcClient(new Uri("http://seed5.neo.org:10332"));
var NeoApiService = new NeoApiService(rpcClient);
```

With **NeoApiService** you have all the methods available, organized by:
Accounts,
Assets,
Block,
Contract,
Node,
Transaction

Then you just need to choose the wanted service, call ```SendRequestAsync()``` and pass the necessary parameters if needed.
e.g.

```C#
var accountsService = NeoApiService.Accounts;
var state = accountsService.GetAccountState.SendRequestAsync("ADDRESS HERE");
```

If you don't need all the services, you can simply create an instance of the desired service.

```C#
var blockService = new NeoApiBlockService(new RpcClient(new Uri("http://seed5.neo.org:10332")));
var bestBlockHash  = await blockService.GetBestBlockHash.SendRequestAsync();
```

All rpc calls return a DTO or a simple type like string or int.

You can also create a service to query NEP5 tokens. 
**Note** For the results to be human readable, these methods do not return the original result from the rpc node.

```C#
var client = new RpcClient(new Uri("http://seed5.neo.org:10332"));
var scriptHash = "08e8c4400f1af2c20c28e0018f29535eb85d15b6"; //TNC token
var nep5Service = new NeoNep5Service(client, scriptHash);
var name = await nep5Service.GetName();
var decimals = await nep5Service.GetDecimals();
var totalsupply = await nep5Service.GetTotalSupply(decimals);
var symbol = await nep5Service.GetSymbol();
var balance = await nep5Service.GetBalance("0x0ff9070d64d19076d08947ba4a82b72709f30baf", decimals);

Token info: 
Name: Trinity Network Credit 
Symbol: TNC 
Decimals: 8 
TotalSupply: 1000000000 
Balance: 1457.82
```

## Contributing


## Authors

* **Bruno Freitas** - [BrunoFreitasgit](https://github.com/BrunoFreitasgit)

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/BrunoFreitasgit/Neo-RPC-SharpClient/blob/master/LICENSE) file for details
