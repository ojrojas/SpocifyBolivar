const routeApiIdentity = process.env.REACT_APP_ROUTE_API_IDENTITY;
const routeApiAggregator = process.env.REACT_APP_ROUTE_API_AGGREGATOR;
const routeApiJukebox = process.env.REACT_APP_ROUTE_API_JUKEBOX;

export const RouteHttp = {
    login: `${routeApiIdentity}login`,
    authorize: `${routeApiIdentity}connect/token`,
    severalbrowse: `${routeApiJukebox}jukebox/severalbrowse/`,
    search: `${routeApiJukebox}jukebox/search/`,
    artist: `${routeApiJukebox}jukebox/artist/`
}

