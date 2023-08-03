import React from "react";
import { SpocifySnackBarOptions } from "../../components/snackbar/spocifysnackbaroptions";
import { useAppSelector } from "../../hooks";

export const SnackBarSpocifyContext = React.createContext<SpocifySnackBarOptions>({
	message: "",
	severity: "info",
	title: undefined,
	autoHideDuration: undefined,
	action: undefined
});

interface Props {
    children: React.ReactNode;
}

export const SnackBarSpocifyProvider:React.FC<Props> = ({children}) => {
	const {optionSnackBar, optionSnackBarActions} = useAppSelector(state => state.snack);
	return (<SnackBarSpocifyContext.Provider value={{
		title: optionSnackBar.title ?? optionSnackBarActions.title,
		autoHideDuration: optionSnackBar.autoHideDuration ?? optionSnackBarActions.autoHideDuration,
		message: optionSnackBar.message ?? optionSnackBarActions.message,
		severity: optionSnackBar.severity ?? optionSnackBarActions.severity,
		action: optionSnackBar.action ?? optionSnackBarActions.action,
		open: optionSnackBar.open ?? optionSnackBarActions.open,
	}}>
		{children}
	</SnackBarSpocifyContext.Provider>);
};

