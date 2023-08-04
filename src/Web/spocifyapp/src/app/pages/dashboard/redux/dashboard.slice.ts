import { createSlice } from "@reduxjs/toolkit";
import { artist, search, severalbrowse } from "./dashboard.actions";
import { Artist } from "../../../core/models/spocify/artist";
import { Search } from "../../../core/models/spocify/search";
import { SeveralBrowse } from "../../../core/models/spocify/severalbrowse";

interface State {
    loading: boolean;
    severalbrowse: SeveralBrowse | undefined,
    artist: Artist | undefined,
    search: Search | undefined,
    error: any
}

const InitialState: State = {
    loading: false,
    artist: undefined,
    search: undefined,
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
    }
})

export default dashboardSlice.reducer;