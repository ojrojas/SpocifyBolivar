import { createAsyncThunk } from "@reduxjs/toolkit";
import HttpClientApplication from "../../../core/services/api.service";
import { SeveralBrowseRequest } from "../../../core/dtos/spocify/severalbrowse.request";
import { RouteHttp } from "../../../core/constants/route.https.constants";
import { SearchRequest } from "../../../core/dtos/spocify/search.request";

export const severalbrowse = createAsyncThunk<[], SeveralBrowseRequest>(
    "dashboard/severalbrowse", async (request: SeveralBrowseRequest) => {
        const api = new HttpClientApplication();
        let route = `${RouteHttp.severalbrowse}${request.country}/${request.locale}/${request.limit}`;
        const response = await api.Get<any>(route);
        return response;
    });

export const search = createAsyncThunk<[], SearchRequest>(
    "dashboard/search", async (request:SearchRequest) => {
        const api = new HttpClientApplication();
        let route = `${RouteHttp.search}${request.query}/${request.type}/${request.limit}`;
        const response = await api.Get<[]>(route);
        return response;
    });

export const artist = createAsyncThunk<[], string>(
    "dashboard/artist", async (request: string) => {
        const api = new HttpClientApplication();
        let route = `${RouteHttp.artist}${request}`;
        const response = await api.Get<[]>(route);
        return response;
    });