import React from "react";
import { Grid, Paper, Typography } from "@mui/material";
import { useAppDispatch, useAppSelector } from "../../hooks";
import { search } from "./redux/dashboard.actions";
import { ListSeveralBrowseComponent } from "./components/list.several.browse";

const DashboardPage: React.FC = () => {
	const dispatch = useAppDispatch();
	const { dashboard } = useAppSelector(state => state);

	React.useEffect(() => {
		dispatch(search('q=rock&type=album'));
	}, []);

	return (
		<Grid container sx={{ padding: 1, height: "100vh" }} gridRow={1}>
			<Grid item xs={12} md={12} lg={12} xl={12}>
				<Paper elevation={4} sx={{ backgroundColor: "#fff", height: "99%", padding: 5 }}>
					<Typography variant={"h6"} component='h6'>
						Dashboard
					</Typography>
					<Grid item xs={12} md={12} lg={12} xl={12} >
						{ dashboard && dashboard.search && <ListSeveralBrowseComponent key={"severals"} search={ dashboard.search} /> }
					</Grid>
				</Paper>
			</Grid>
		</Grid>
	);
};

export default DashboardPage;