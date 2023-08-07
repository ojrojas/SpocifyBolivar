import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { getinfouser, login, logincallback, logout } from "./login.action";
import { IApplicationUser } from "../../../core/models/user/user";
import { ILoginApplicationResponse } from "../../../core/models/userapplication/loginapplicationresponse";
import { ILoginApplicationRequest } from "../../../core/models/userapplication/loginapplicationrequest";

interface State {
    loginApplicationResponse: ILoginApplicationResponse | undefined;
    loginApplicationRequest: ILoginApplicationRequest |  undefined;
    loading:boolean;
    error:any;
    logged: boolean;
    user: IApplicationUser | undefined;
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
			state.loading=false;
		});
		builder.addCase(logincallback.rejected, (state) => {
			state.loading = false;
			state.loginApplicationResponse = undefined;
			state.logged = false;
		})

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

		builder.addCase(getinfouser.pending, (state) => {
			state.loading = true;
		})
		builder.addCase(getinfouser.fulfilled, (state, action)=>{
			state.user = action.payload;
			state.loading = false;
		})
		builder.addCase(getinfouser.rejected, (state, action) => {
			state.logged = false;
			state.loading = false;
			state.loginApplicationRequest = undefined;
		});
    }
});

export const { updateLogged } = authSlice.actions;

export default authSlice.reducer;