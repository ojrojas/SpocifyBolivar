import { createSlice } from "@reduxjs/toolkit";
import { album, artist, search, severalbrowse } from "./dashboard.actions";
import { IArtist, ISearchResponse } from "../../../core/models/spocify/search";
import { ISeveralBrowse } from "../../../core/models/spocify/severalbrowse";
import { IAlbumResponse } from "../../../core/models/spocify/album";

interface State {
    loading: boolean;
    severalbrowse: ISeveralBrowse | undefined,
    artist: IArtist | undefined,
    album: IAlbumResponse | undefined;
    search: ISearchResponse | undefined,
    error: any
}

const InitialState: State = {
    loading: false,
    artist: undefined,
    search: undefined,
    album: undefined,
    severalbrowse: undefined,
    error: undefined
}

const dashboardSlice = createSlice({
    name: 'dashboard',
    initialState: InitialState,
    reducers: {},
    extraReducers: builder => {
        builder.addCase(severalbrowse.pending, (state) => {
            state.loading = true;
        })
        builder.addCase(severalbrowse.fulfilled, (state, action) => {
            state.loading = false;
            state.severalbrowse = action.payload;
        })
        builder.addCase(severalbrowse.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error;
            state.severalbrowse = undefined;
        })

        builder.addCase(search.pending, (state) => {
            state.loading = true;
        })
        builder.addCase(search.fulfilled, (state, action) => {
            state.loading = false;
            state.search = action.payload;
        })
        builder.addCase(search.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error;
            state.search = undefined;
        })

        builder.addCase(artist.pending, (state) => {
            state.loading = true;
        })
        builder.addCase(artist.fulfilled, (state, action) => {
            state.loading = false;
            state.artist = action.payload;
        })
        builder.addCase(artist.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error;
            state.artist = undefined;
        })

        builder.addCase(album.pending, (state) => {
            state.loading = true;
        })

        builder.addCase(album.fulfilled, (state, action)=> {
            state.loading = false;
            state.album = action.payload;
        })
        builder.addCase(album.rejected, (state, action) => {
            state.loading = false;
            state.album= undefined;
            state.error = action.error;
        })
    }
})

export default dashboardSlice.reducer;