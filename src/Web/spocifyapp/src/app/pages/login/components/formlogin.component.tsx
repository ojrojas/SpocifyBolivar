import React from "react";
import { Button, colors, Grid, Paper, Typography } from "@mui/material";
import styles from '../components/formlogin.module.css';
import { useAppDispatch, useAppSelector } from "../../../hooks";
import { login } from "../redux/login.action";
import { updateLogged } from "../redux/login.slice";
import { RouteConstantsPages } from "../../../core/constants/route.pages.constants";
import { useNavigate } from "react-router-dom";
import { openSnackBarSpocify } from "../../../components/snackbar/redux/snackbarslice.slice";
import logoIcon from '../../../../assets/icons/seguros-icons.svg';

const FormLoginComponent: React.FC = () => {
	const dispatch = useAppDispatch();
	const navigateOn = useNavigate();
	const { logged } = useAppSelector(state => state.login);


	React.useEffect(() => {
		if (logged) navigateOn(RouteConstantsPages.home);
		else dispatch(updateLogged(false));
	}, [dispatch, navigateOn, logged]);

	const onSubmit = (async () => await dispatch(login()).unwrap().then(async () => {
	}).catch(response => {
		dispatch(openSnackBarSpocify({
			message: response.message,
			severity: "error",
			title: "Login"
		}));
	}));

	return (
		<React.Fragment>
			<Grid container className={styles.container}>
				<Paper elevation={12}>
					<Grid className={styles.form}>
						<img src={logoIcon}/>
						<Typography variant={"body2"} color={colors.blue[400]}>
							Sign In
						</Typography>
						<Typography variant={"h5"} component='span' color={"var(--primary)"}>
							Spocify Bolivar
						</Typography>
						<hr className={styles.lines} />
						<p style={{ textAlign: 'center', color: 'green' }}>
							This app use external login real spotify, use only test environment
						</p>
						<Grid className={styles.buttons}>
							<Button
								onClick={onSubmit}
								variant="outlined"
								color='primary'
								type="button">
								Sign In
							</Button>
						</Grid>
					</Grid>
				</Paper>
			</Grid>
		</React.Fragment>
	);
};

export default FormLoginComponent;