import { createAsyncThunk } from "@reduxjs/toolkit";
import { RouteHttp } from "../../../core/constants/route.https.constants";
import { ILoginApplicationResponse } from "../../../core/dtos/userapplication/loginapplicationresponse";
import { ILoginApplicationRequest } from "../../../core/dtos/userapplication/loginapplicationrequest";
import HttpClientApplication from "../../../core/services/api.service";

export const login = createAsyncThunk("auth/login", async () => {
	window.location.href = RouteHttp.login
});

export const logincallback = createAsyncThunk<ILoginApplicationResponse, ILoginApplicationRequest>(
	"auth/logincallback", async (logincallback: ILoginApplicationRequest) => {
		const api = new HttpClientApplication();

		let formData = new URLSearchParams();
		formData.append("grant_type", "password");
		formData.append("username", logincallback.useriddata);
		formData.append("password", "logincallback");
		formData.append("scope", "jukebox");
		formData.append("client_id", "spocifyweb-client");
		formData.append("client_secret", "25d91591-0e59-4241-8086-6f5202e5a409");
		const response = await api.Login<ILoginApplicationResponse>(RouteHttp.authorize, formData);
		return response;
	});

export const logout = createAsyncThunk("auth/logged", async () => {
	return false;
});