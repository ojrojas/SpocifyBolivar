import { createSlice } from "@reduxjs/toolkit";
import { artist, search, severalbrowse } from "./dashboard.actions";

interface State {
    loading: boolean;
    severalbrowses: any,
    artists: any,
    searches: any,
    error:any
}

const InitialState: State = {
    loading: false,
    artists: undefined,
    searches: undefined,
    severalbrowses: undefined,
    error:undefined
}

const dashboardSlice = createSlice({
    name: 'dashboard',
    initialState: InitialState,
    reducers:{},
    extraReducers: builder => {
        builder.addCase(severalbrowse.pending, (state) => {
            state.loading = true;
        })
        builder.addCase(severalbrowse.fulfilled, (state, action) => {
            state.loading= false;
            state.severalbrowses = action.payload;
        })
        builder.addCase(severalbrowse.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error;
            state.severalbrowses = undefined;
        })

        builder.addCase(search.pending, (state) => {
            state.loading = true;
        })
        builder.addCase(search.fulfilled, (state, action) => {
            state.loading= false;
            state.searches = action.payload;
        })
        builder.addCase(search.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error;
            state.searches = undefined;
        })

        builder.addCase(artist.pending, (state) => {
            state.loading = true;
        })
        builder.addCase(artist.fulfilled, (state, action) => {
            state.loading= false;
            state.artists = action.payload;
        })
        builder.addCase(artist.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error;
            state.artists = undefined;
        })
    }
})

export default dashboardSlice.reducer;