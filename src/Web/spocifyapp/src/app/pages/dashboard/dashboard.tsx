import React from "react";
import { Grid, Paper, Typography } from "@mui/material";
import { useAppDispatch, useAppSelector } from "../../hooks";
import { search } from "./redux/dashboard.actions";
import { ListSeveralBrowseComponent } from "./components/list.several.browse";
import { DisplaySelectedComponent } from "./components/display.selected";

const DashboardPage: React.FC = () => {
	const dispatch = useAppDispatch();
	const { dashboard } = useAppSelector(state => state);

	React.useEffect(() => {
		dispatch(search('q=rock&type=album'));
	}, []);

	return (
		<Grid container sx={{ padding: 1 }} gridRow={1}>
			<Grid item xs={12}>
				<Paper elevation={2} sx={{ width:'100%', backgroundColor: "#fff", padding: 5, borderRadius: 3, height: '100%' }}>
					<Typography variant={"h6"} component='h6'>
						Dashboard
					</Typography>
					<Grid container columns={{ xs: 4, sm: 8, md: 12 }} style={{ borderRadius: 5 }}>
						<Grid item container spacing={.5}>
							<Grid item xs={12} md={6} lg={6} color={'var(--color1)'} style={{ backgroundColor: 'var(--background2)', padding: 5, borderRadius: 8 }}>
								{dashboard && dashboard.search && <ListSeveralBrowseComponent key={"severals"} search={dashboard.search} />}
							</Grid>
							<Grid item xs={12} md={6} lg={6} color={'var(--color1)'} style={{ backgroundColor: 'var(--background1)', padding: 5, borderRadius: 8 }}>
								{<DisplaySelectedComponent />}
							</Grid>
						</Grid>
					</Grid>
				</Paper>
			</Grid>
		</Grid>
	);
};

export default DashboardPage;