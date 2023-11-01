const steamapi = "api.steampowered.com"

export async function onRequest(context) {
    /** @type {Request} */
    const request = context.request;
    const url = new URL(request.url);

    url.hostname = steamapi;
    url.protocol = "https";
    url.pathname = url.pathname.replace("/api/proxy", "");

    let response = await fetch(url.toString(), request);
    return response;
}