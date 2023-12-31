import React from "react";
import Box from "@mui/material/Box";
import SwipeableDrawer from "@mui/material/SwipeableDrawer";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import AppBarSearchComponent from "./../appbar/appbar.component";
import { Outlet, useNavigate } from "react-router-dom";
import { Collapse, colors, CssBaseline, Divider, Grid, styled, Tooltip, Typography } from "@mui/material";
import { MenuLinkList } from "./constants/menuslink";
import styles from "./drawercomponent.module.css";
import { useAppDispatch, useAppSelector } from "../../hooks";
import { MenuItem } from "../../core/models/menulink.model";
import { ExpandLess, ExpandMore } from "@mui/icons-material";
import { RouteConstantsPages } from "../../core/constants/route.pages.constants";
import { getinfouser } from "../../pages/login/redux/login.action";
import { updateLogged } from "../../pages/login/redux/login.slice";
import { closeSnackBarSpocify } from "../snackbar/redux/snackbarslice.slice";

const DrawerHeader = styled("div")(({ theme }) => ({
	display: "flex",
	alignItems: "center",
	justifyContent: "flex-end",
	padding: theme.spacing(0, 1),
	...theme.mixins.toolbar,
}));

const SwipeableTemporaryDrawer: React.FC = () => {
	const [state, setState] = React.useState<boolean>(false);
	const { logged } = useAppSelector(login => login.login);
	const [expanded, setExpanded] = React.useState<string | false>(false);
	const navigateOn = useNavigate();
	const dispatch = useAppDispatch();

	React.useEffect(() => {
		if (!logged){
			dispatch(closeSnackBarSpocify());
			navigateOn(RouteConstantsPages.login);
		}
		else{
			dispatch(getinfouser()).unwrap().then(response =>{
				console.log(response);
				navigateOn(RouteConstantsPages.home);
			}).catch(error => {
				dispatch(updateLogged(false));
				dispatch(closeSnackBarSpocify());
				navigateOn(RouteConstantsPages.login);
				console.error(error)
			})
		}
	}, []);

	const haveSubMenusOnNavigate = (menuItem: MenuItem) => {
		if (menuItem.subMenus) {
			if (expanded)
				setExpanded(false);
			else
				setExpanded(menuItem.haveSubMenus ? menuItem.name : false);
		} else {
			setState(false);
			setExpanded(false);
			navigateOn(menuItem.route);
		}
	};

	const toggleDrawer =
		(open: boolean) =>
			(event: React.KeyboardEvent | React.MouseEvent) => {
				if (event && event.type === "keydown" &&
					((event as React.KeyboardEvent).key === "Tab" || (event as React.KeyboardEvent).key === "Shift")) {
					return;
				}
				setState(open);
			};

	const list = () => (
		<Box
			style={{backgroundColor: 'var(--background2)'}}
			sx={{ width: 230 }}
			role="presentation">
			<CssBaseline />
			<DrawerHeader>
				{state ? <Typography style={{ textAlign: "center", width: "100%", backgroundColor:"var(--background1)" }} variant='h6' component={"span"}>
					Spocify
				</Typography> : null}
			</DrawerHeader>
			<Divider />
			<List>
				{MenuLinkList.map((menu, index) => (
					<ListItem key={menu.name + index} disablePadding sx={{ display: "block", }}>
						<Tooltip title={menu.name} placement='right'>
							<ListItemButton
								onClick={() => { haveSubMenusOnNavigate(menu); }}
								sx={{
									minHeight: 48,
									justifyContent: state ? "initial" : "center",
									px: 2.5,
								}}>
								<ListItemIcon
									sx={{
										minWidth: 0,
										mr: state ? 3 : "auto",
										justifyContent: "center",
									}}>
									{menu.icon}
								</ListItemIcon>
								<ListItemText primary={menu.name} sx={{ opacity: state ? 1 : 0, color: colors.grey[800] }} />
								{menu.haveSubMenus ? (menu.name === expanded ? <ExpandLess /> : <ExpandMore />) : null}
							</ListItemButton>
						</Tooltip>
						<Collapse in={menu.name === expanded} timeout="auto" unmountOnExit>
							<List component="div" disablePadding>
								{menu.subMenus && menu.subMenus.map((menuItem, index) => (
									<Tooltip key={menuItem.name + index} title={menuItem.name} placement='right'>
										<ListItemButton sx={{ pl: 4 }} onClick={() => haveSubMenusOnNavigate(menuItem)}>
											<ListItemIcon>
												{menuItem.icon}
											</ListItemIcon>
											<ListItemText primary={menuItem.name} />
										</ListItemButton>
									</Tooltip>
								))}
							</List>
						</Collapse>
					</ListItem>
				))}
			</List>
		</Box >
	);

	return (
		<React.Fragment>
			<SwipeableDrawer
				anchor={"left"}
				open={state}
				onClose={toggleDrawer(false)}
				onOpen={toggleDrawer(true)}>
				{list()}
			</SwipeableDrawer>
			<Box component={"div"} >
				<AppBarSearchComponent onClick={toggleDrawer(true)} />
				<Grid className={styles.containerdrawer}>
					<Grid item xs={12} md={12} sm={12} lg={12}>
						<Outlet />
					</Grid>
				</Grid>
			</Box>
		</React.Fragment>
	);
};

export default SwipeableTemporaryDrawer;