import React from "react";
import { RouteConstantsPages } from "../../../core/constants/route.pages.constants";
import { MenuItem } from "../../../core/models/menulink.model";
import DashboardIcon from "@mui/icons-material/Dashboard";
import PersonIcon from "@mui/icons-material/Person";
import SettingsIcon from "@mui/icons-material/Settings";

export const MenuLinkList: MenuItem[] = [
	{
		name: "Dashboard",
		icon: <DashboardIcon />,
		route: RouteConstantsPages.home,
		haveSubMenus: false
	},
	{
		name: "Settings",
		icon: <SettingsIcon />,
		route: "",
		haveSubMenus: true,
		subMenus: [
			{
				name: "Users",
				icon: <PersonIcon />,
				route: RouteConstantsPages.home,
				haveSubMenus: false
			}
		]
	}

];