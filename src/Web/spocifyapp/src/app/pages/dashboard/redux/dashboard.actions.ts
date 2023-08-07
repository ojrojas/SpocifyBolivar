import { createAsyncThunk } from "@reduxjs/toolkit";
import HttpClientApplication from "../../../core/services/api.service";
import { RouteHttp } from "../../../core/constants/route.https.constants";
import { ISeveralBrowse } from "../../../core/models/spocify/severalbrowse";
import { IArtist, ISearchResponse } from "../../../core/models/spocify/search";
import { IAlbumResponse } from "../../../core/models/spocify/album";

export const severalbrowse = createAsyncThunk<ISeveralBrowse, string>(
    "dashboard/severalbrowse", async (request: string) => {
        const api = new HttpClientApplication();
        let route = `${RouteHttp.severalbrowse}${request}`;
        const response = await api.Get<ISeveralBrowse>(route);
        return response;
    });

export const search = createAsyncThunk<ISearchResponse, string>(
    "dashboard/search", async (request:string) => {
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