import React from "react";
import { Grid, Paper, Typography } from "@mui/material";
import { useAppDispatch, useAppSelector } from "../../hooks";
import { severalbrowse } from "./redux/dashboard.actions";
import { SeveralBrowseRequest } from "../../core/dtos/spocify/severalbrowse.request";

const DashboardPage: React.FC = () => {
	const dispatch = useAppDispatch();
	const { dashboard, login } = useAppSelector(state => state);

	React.useEffect(() => {
		let request: SeveralBrowseRequest = {
			country: 'CO',
			locale: 'ES_CO',
			limit: 10
		};
		dispatch(severalbrowse(request));
	}, []);

	return (
		<Grid container sx={{ padding: 1, height: "100vh" }} gridRow={1}>
			<Grid item xs={12} md={12} lg={12} xl={12}>
				<Paper elevation={4} sx={{ backgroundColor: "#fff", height: "99%", padding: 5 }}>
					<Typography variant={"h6"} component='h6'>
						Dashboard
					</Typography>
					<ul>
						{dashboard && dashboard.severalbrowses && dashboard.severalbrowses?.categories?.items.map((item:any) => {
							return (<li key={item.id}> <a href={item.href}><img src={item.icons.url} /> {item.name} </a></li>)
						})}
					</ul>
				</Paper>
			</Grid>
		</Grid>
	);
};

export default DashboardPage;