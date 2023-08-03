import React from "react";
import { Box, Breadcrumbs, Button, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { RouteConstantsPages } from "../../../core/constants/route.pages.constants";

interface Props {
    subNamePage: string;
}

const BreadCrumbsComponent: React.FC<Props> = ({ subNamePage}) => {
	const navigateOn = useNavigate();
	return (
		<Box component='div' role='presentation'>
			<Breadcrumbs aria-label='breadcrumb'>
				<Button color='inherit' onClick={()=> navigateOn("../"+RouteConstantsPages.home)}>
                    Major Village
				</Button>
				<Typography color='text.primary'>
					{subNamePage}
				</Typography>
			</Breadcrumbs>
		</Box>
	);
};

export default BreadCrumbsComponent;