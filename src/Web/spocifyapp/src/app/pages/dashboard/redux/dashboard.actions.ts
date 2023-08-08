import { createAsyncThunk } from "@reduxjs/toolkit";
import HttpClientApplication from "../../../core/services/api.service";
import { RouteHttp } from "../../../core/constants/route.https.constants";
import { ISeveralBrowse } from "../../../core/models/spocify/severalbrowse";
import { IArtist, ISearchResponse } from "../../../core/models/spocify/search";
import { IAlbumResponse } from "../../../core/models/spocify/album";
import { IPlayerPlayResumeRequest, IPlayerStateResponse } from "../../../core/models/spocify/player";

export const severalbrowse = createAsyncThunk<ISeveralBrowse, string>(
    "dashboard/severalbrowse", async (request: string) => {
        const api = new HttpClientApplication();
        let route = `${RouteHttp.severalbrowse}${request}`;
        const response = await api.Get<ISeveralBrowse>(route);
        return response;
    });

export const search = createAsyncThunk<ISearchResponse, string>(
    "dashboard/search", async (request: string) => {
        const api = new HttpClientApplication();
        let route = `${RouteHttp.search}${request}`;
        const response = await api.Get<ISearchResponse>(route);
        return response;
    });

export const artist = createAsyncThunk<IArtist, string>(
    "dashboard/artist", async (request: string) => {
        const api = new HttpClientApplication();
        let route = `${RouteHttp.artist}${request}`;
        const response = await api.Get<IArtist>(route);
        return response;
    });

export const album = createAsyncThunk<IAlbumResponse, string>(
    "dashboard/album", async (request: string) => {
        const api = new HttpClientApplication();
        let route = `${RouteHttp.album}${request}`;
        const response = await api.Get<IAlbumResponse>(route);
        return response;
    });

export const playerstate = createAsyncThunk<IPlayerStateResponse>(
    "dashboard/playerstate", async () => {
    const api = new HttpClientApplication();
    const route = `${RouteHttp.playerstate}`;
    const response = await api.Get<IPlayerStateResponse>(route);
    return response;
});

export const playerstartorresume = createAsyncThunk<any, IPlayerPlayResumeRequest>(
    "dashboard/playerstartresume", async (request: IPlayerPlayResumeRequest) => {
    const api = new HttpClientApplication();
    const route = `${RouteHttp.playerstate}`;
    const response = await api.Post<IPlayerStateResponse>(route, request);
    return response;
});

export const playervolume = createAsyncThunk<any, number>(
    "dashboard/playervolume", async (volume:number) => {
    const api = new HttpClientApplication();
    const route = `${RouteHttp.playervolume+volume}`;
    const response = await api.Get<any>(route);
    return response;
});

export const playernext = createAsyncThunk<any>(
    "dashboard/playernext", async () => {
    const api = new HttpClientApplication();
    const route = `${RouteHttp.playernext}`;
    const response = await api.Get<any>(route);
    return response;
});

export const playerprevious = createAsyncThunk<any>(
    "dashboard/playerprevious", async () => {
    const api = new HttpClientApplication();
    const route = `${RouteHttp.playerprevious}`;
    const response = await api.Get<any>(route);
    return response;
});