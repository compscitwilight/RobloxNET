<img src="/resources/logo.png" align="center">
<hr>

Roblox.NET is a C# package that helps you work with the <a href="https://api.roblox.com/docs">Roblox API</a>. It is a recreated version of <a href="https://github.com/REdgars/Roblox.NET">REdgars's Roblox.NET</a>.

## Features


## Examples
Getting the friends of a user
```cs
using RobloxNET;

RobloxUser[] Friends = await RobloxFriendsAPI.GetUserFriendsAsync(1);
```
