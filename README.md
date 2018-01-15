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


## Overview

This project aims to be a full RPC client for the NEO network created in C# and inspired by [Nethereum](https://github.com/Nethereum/Nethereum). You can use it support your mobile wallet, websites, neo blockchain data gathering, etc. 

### What does it currently do
- RPC Client

### What will it do
- After proper testing, will create a Nuget package for easy C# projects integration


Was develop with decoupling in mind to make maintenance and new RPC methods implemented more quickly:

* Client base - Neo.JsonRpc.Client project
* RPC client implementation - Neo.JsonRpc.RpcClient project
* DTO'S, Services, Helpers - Neo.RPC (main project)
* Tests - Neo.RPC.Tests



## Contributing


## Authors

* **Bruno Freitas** - [BrunoFreitasgit](https://github.com/BrunoFreitasgit)

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/BrunoFreitasgit/Neo-RPC-SharpClient/blob/master/LICENSE) file for details
