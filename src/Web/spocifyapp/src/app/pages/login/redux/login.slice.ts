import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { login, logincallback, logout } from "./login.action";
import { ILoginApplicationResponse } from "../../../core/dtos/userapplication/loginapplicationresponse";
import { ILoginApplicationRequest } from "../../../core/dtos/userapplication/loginapplicationrequest";
import { DecodeJwt } from "../../../core/services/decodejwt.service";
import { IUser } from "../../../core/models/user/user";

interface State {
    loginApplicationResponse: ILoginApplicationResponse | undefined;
    loginApplicationRequest: ILoginApplicationRequest |  undefined;
    loading:boolean;
    error:any;
    logged: boolean;
    user: IUser | undefined;
}

const InitialState: State = {
    loading: false,
    logged: false,
    error: undefined,
    user : undefined,
    loginApplicationRequest: undefined,
    loginApplicationResponse: undefined
}

const authSlice = createSlice({
    name: "auth",
    initialState: InitialState,
    reducers: {
        updateLogged: (state,action: PayloadAction<boolean>) => {
			state.logged = action.payload;
		},
    },
    extraReducers: builder => {
        builder.addCase(login.pending, (state, action) => {
			state.loading = true;
		});
		builder.addCase(login.fulfilled, (state) => {
			state.loginApplicationRequest = undefined;
			state.loading = false;
		});
		builder.addCase(login.rejected, (state) => {
			state.loading = false;
			state.logged = false;
			state.loginApplicationRequest = undefined;
			state.loginApplicationResponse = undefined;
		});
		builder.addCase(logincallback.pending, (state)=> {
			state.loading = true;
		});
		builder.addCase(logincallback.fulfilled, (state, action) => {
			state.loginApplicationResponse = action.payload;
			// if (state.loginApplicationResponse.access_token !== undefined)
			// 	state.user = DecodeJwt.decodeJwt(state.loginApplicationResponse.access_token);
			state.loading=false;
		});

		builder.addCase(logout.pending, (state) => {
			state.loading = true;
		});
		builder.addCase(logout.fulfilled, (state) => {
			state.loading = false;
			state.logged = false;
			state.loginApplicationResponse = undefined;
			state.loginApplicationRequest = undefined;
		});
		builder.addCase(logout.rejected, (state) => {
			state.logged = false;
			state.loginApplicationResponse = undefined;
			state.loginApplicationRequest = undefined;
			state.loading = false;
		});
    }
});

export const { updateLogged } = authSlice.actions;

export default authSlice.reducer;