import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SpocifySnackBarOptions } from "../spocifysnackbaroptions";

const initialOptions: SpocifySnackBarOptions = {
	open: false,
	message: "",
	severity: "info",
	title:undefined,
	action:undefined,
	autoHideDuration:undefined
};

interface State {
	optionSnackBar: SpocifySnackBarOptions;
	optionSnackBarActions: SpocifySnackBarOptions;
}

const initialState: State = {
	optionSnackBar: initialOptions,
	optionSnackBarActions: initialOptions
};

const snackBarSlice = createSlice({
	name: "snackbar",
	initialState: initialState,
	reducers: {
		openSnackBarSpocify: (state, action: PayloadAction<SpocifySnackBarOptions>) => {
			state.optionSnackBar.message = action.payload.message;
			state.optionSnackBar.open = true;
			state.optionSnackBar.severity = action.payload.severity;
			state.optionSnackBar.title = action.payload.title;
			state.optionSnackBar.autoHideDuration = action.payload.autoHideDuration;
		},
		closeSnackBarSpocify: (state) => {
			state.optionSnackBar = initialOptions;
		},
		openSnackBarActionsSpocify: (state, action: PayloadAction<SpocifySnackBarOptions>) => {
			state.optionSnackBarActions.message = action.payload.message;
			state.optionSnackBarActions.title = action.payload.title;
			state.optionSnackBarActions.severity = action.payload.severity;
			state.optionSnackBarActions.autoHideDuration = action.payload.autoHideDuration;
			state.optionSnackBarActions.action = action.payload.action;
			state.optionSnackBarActions.open = true;
		},
		closeSnackBarActionsSpocify: (state) => {
			state.optionSnackBarActions = initialOptions;
		},
		executeAction: (state, action: PayloadAction<boolean>) => {
			console.log("optionAction is ", state.optionSnackBarActions.action);
			if(state.optionSnackBarActions.action !== undefined)
				state.optionSnackBarActions.action(action.payload);
		}
	}
});

export default snackBarSlice.reducer;
export const {
	openSnackBarSpocify,
	closeSnackBarSpocify,
	openSnackBarActionsSpocify,
	closeSnackBarActionsSpocify,
	executeAction,
} = snackBarSlice.actions;