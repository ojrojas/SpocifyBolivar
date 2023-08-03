import { ColorApp, Theme, ThemeType } from "../models/theme.model";

export const THEMES: Record<ThemeType, Theme> = {
	light: {
		"--primary": ColorApp.GREEN_LETTERS,
		"--secondary": ColorApp.YELLOW_LETTERS,
		"--background1": ColorApp.GREEN_FONTS,
		"--background2": ColorApp.YELLOW_FONTS,
		"--color1": ColorApp.BLACK,
		"--color2" :ColorApp.WHITE
	},
	dark: {
		"--primary": ColorApp.GREEN_LETTERS,
		"--secondary": ColorApp.YELLOW_LETTERS,
		"--background1": ColorApp.GREEN_FONTS,
		"--background2": ColorApp.YELLOW_FONTS,
		"--color1": ColorApp.BLACK,
		"--color2": ColorApp.WHITE
	}
};