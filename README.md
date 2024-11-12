# Meenzen.SteamTools

A Web App that interacts with the Steam API. Allows calculating stats like the total playtime per platform.

## Usage

You can either use the official deployment [steam.mnzn.dev](https://steam.mnzn.dev/) or deploy this app to your own Cloudflare Account.

## Deployment

This project is built primarily for a Cloudflare Pages deployment. The `main` branch is automatically deployed to [steam.mnzn.dev](https://steam.mnzn.dev/).
If you'd like to deploy this app to your own Cloudflare Account, you can do so by forking this repository and creating a new Cloudflare Pages project:

1. Fork this repository
2. Log in to your Cloudflare Account and navigate to the [Workers & Pages](https://dash.cloudflare.com/?to=/:account/workers-and-pages) tab
3. Click "Create application"
4. Select the "Pages" tab
5. Click "Connect to Git", then select your fork of this repository
6. Click "Begin setup"
7. Use the following settings:
   - Production branch: `main`
   - Framework preset: `None`
   - Build command: `./cloudflare-build.sh`
   - Build output directory: `/artifacts/publish/Meenzen.SteamTools/release/wwwroot`
8. Click "Save and Deploy"
9. Profit

## Contributing

Pull requests are welcome. Please use [Conventional Commits](https://www.conventionalcommits.org/) to keep
commit messages consistent.

## Acknowledgements

- [Steam Web API Documentation](https://steamapi.xpaw.me/) by [xPaw](https://github.com/xPaw) provides a great overview of the available Steam API endpoints.

## License

Distributed under the [MIT License](https://choosealicense.com/licenses/mit/). See `LICENSE` for more information.
