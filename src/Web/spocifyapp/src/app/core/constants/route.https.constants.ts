const routeApiIdentity = process.env.REACT_APP_ROUTE_API_IDENTITY;
const routeApiAggregator = process.env.REACT_APP_ROUTE_API_AGGREGATOR;
const routeApiJukebox = process.env.REACT_APP_ROUTE_API_JUKEBOX;

export const RouteHttp = {
    login: `${routeApiIdentity}login`,
    getinfouser: `${routeApiIdentity}getinfouser`,
    authorize: `${routeApiIdentity}connect/token`,
    severalbrowse: `${routeApiJukebox}jukebox/severalbrowse/`,
    search: `${routeApiJukebox}jukebox/search/`,
    artist: `${routeApiJukebox}jukebox/artist/`,
    album: `${routeApiJukebox}jukebox/album/`,
    playerstate: `${routeApiJukebox}jukebox/playerstate`,
    playerstartresume: `${routeApiJukebox}jukebox/startresume`,
    playervolume: `${routeApiJukebox}jukebox/playervolume/`,
    playernext: `${routeApiJukebox}jukebox/playernext`,
    playerprevious: `${routeApiJukebox}jukebox/playerprevious`
}

