import React from "react";
import Snackbar from "@mui/material/Snackbar";
import CloseIcon from "@mui/icons-material/Close";
import { Button, CardActions, CardContent, CardHeader, Divider, IconButton, Paper, PaperProps, Stack, Typography } from "@mui/material";
import styles from "./actionssnackbar.module.css";
import { useAppDispatch, useAppSelector } from "../../hooks";
import { closeSnackBarActionsSpocify, executeAction } from "./redux/snackbarslice.slice";
import { TransitionLeft } from "./snackbar.component";

const CardSnackBar = React.forwardRef<HTMLDivElement, PaperProps>(function Alert(
	props,
	ref,
) {
	return (
		<Paper elevation={6} ref={ref} {...props}>
		</Paper>
	);
});

const SnackbarSpocifyAction: React.FC = () => {
	const snackBarState = useAppSelector(state => state.snack.optionSnackBarActions);
	const dispatch = useAppDispatch();

	const returnColor = (color: string) => {
		switch (color) {
		case "success":
			return "green";
		case "info":
			return "blue";
		case "warning":
			return "orange";
		case "error":
			return "red";
		default: return "info";
		}
	};

	return (
		<Stack spacing={2} sx={{ width: "100%" }}>
			<Snackbar
				open={snackBarState.open}
				onClose={() => dispatch(closeSnackBarActionsSpocify())}
				TransitionComponent={TransitionLeft}
				autoHideDuration={snackBarState.autoHideDuration}
				key={"snackbaraction-spocify"}>
				<CardSnackBar sx={{ width: "100%" }}>
					<CardHeader
						action={
							<IconButton aria-label="settings" onClick={
								() => {
									dispatch(executeAction(false));
									dispatch(closeSnackBarActionsSpocify());
								}}>
								<CloseIcon />
							</IconButton>
						}
						title={snackBarState.title}
						style={{ backgroundColor: returnColor(snackBarState.severity), color: "white" }}
					/>
					<CardContent className={styles.cardheader}>
						{snackBarState.message}
					</CardContent>
					<Divider></Divider>
					<CardActions>
						<Button onClick={() => { 
							dispatch(executeAction(true));
							dispatch(closeSnackBarActionsSpocify());
						}}> Accept </Button>
						<Button onClick={
							() => {
								dispatch(executeAction(false));
								dispatch(closeSnackBarActionsSpocify());
							}}> Cancel </Button>
					</CardActions>
				</CardSnackBar>
			</Snackbar>
		</Stack>
	);
};

export default SnackbarSpocifyAction;