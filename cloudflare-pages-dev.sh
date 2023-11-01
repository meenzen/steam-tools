#!/bin/sh

dotnet publish -c Release src/Meenzen.SteamTools/Meenzen.SteamTools.csproj
npx wrangler pages dev src/Meenzen.SteamTools/bin/Release/net8.0/publish/wwwroot
