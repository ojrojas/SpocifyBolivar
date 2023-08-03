import { CssBaseline } from "@mui/material";
import React from "react";
import { RouterProvider } from "react-router-dom";
import SnackbarSpocifyAction from "./app/components/snackbar/actionssnackbar";
import SnackbarSpocify from "./app/components/snackbar/snackbar.component";
import { SnackBarSpocifyProvider } from "./app/core/context/snackbar.context";
import { useTheme } from "./app/hooks";
import router from "./app/routes/route.component";

function App() {
	const { theme } = useTheme();
	return (
		<div style={{ ...theme as React.CSSProperties }}>
			<SnackBarSpocifyProvider>
				<CssBaseline />
				<RouterProvider router={router} />
				<SnackbarSpocify />
				<SnackbarSpocifyAction />
			</SnackBarSpocifyProvider>
		</div>
	);
}

export default App;