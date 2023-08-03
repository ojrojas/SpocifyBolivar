export type ThemeType = "dark" | "light";

export enum ColorApp {
    GREEN_LETTERS =  "#016d38",
    GREEN_FONTS = "#06915C",
    YELLOW_FONTS = "#ffdc5d",
    YELLOW_LETTERS = "#ffdc5d",
    DARK_GREY = "#A9A9A9",
    LIGHT_GREY= "#D3D3D3",
    WHITE = "#fff",
    BLACK = "#1b1b1b"
}

export interface Theme {
    "--primary": ColorApp.GREEN_LETTERS;
    "--secondary": ColorApp.YELLOW_LETTERS;
    "--background1": ColorApp.GREEN_FONTS;
    "--background2": ColorApp.YELLOW_FONTS;
    "--color1": ColorApp.BLACK;
    "--color2": ColorApp.WHITE;
}