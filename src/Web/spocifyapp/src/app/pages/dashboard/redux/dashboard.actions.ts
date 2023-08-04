import { createAsyncThunk } from "@reduxjs/toolkit";
import HttpClientApplication from "../../../core/services/api.service";
import { RouteHttp } from "../../../core/constants/route.https.constants";
import { SeveralBrowse } from "../../../core/models/spocify/severalbrowse";
import { Search } from "../../../core/models/spocify/search";
import { Artist } from "../../../core/models/spocify/artist";

export const severalbrowse = createAsyncThunk<SeveralBrowse, string>(
    "dashboard/severalbrowse", async (request: string) => {
        const api = new HttpClientApplication();
        let route = `${RouteHttp.severalbrowse}${request}`;
        const response = await api.Get<SeveralBrowse>(route);
        return response;
    });

export const search = createAsyncThunk<Search, string>(
    "dashboard/search", async (request:string) => {
        const api = new HttpClientApplication();
        let route = `${RouteHttp.search}${request}`;
        const response = await api.Get<Search>(route);
        return response;
    });

export const artist = createAsyncThunk<Artist, string>(
    "dashboard/artist", async (request: string) => {
        const api = new HttpClientApplication();
        let route = `${RouteHttp.artist}${request}`;
        const response = await api.Get<Artist>(route);
        return response;
    });