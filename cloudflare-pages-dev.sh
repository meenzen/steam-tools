#!/usr/bin/env bash

dotnet publish -c Release
npx wrangler pages dev artifacts/publish/Meenzen.SteamTools/release/wwwroot
