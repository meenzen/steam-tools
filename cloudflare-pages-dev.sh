#!/bin/sh

dotnet publish -c Release
npx wrangler pages dev publish/Meenzen.SteamTools/release/wwwroot
