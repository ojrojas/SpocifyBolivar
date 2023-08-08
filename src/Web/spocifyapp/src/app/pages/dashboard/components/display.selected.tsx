import React, { useEffect } from "react"
import { Grid, Paper } from "@mui/material";
import { ListContentAlbumComponent } from "./listcontent.album";
import { useAppDispatch, useAppSelector } from "../../../hooks";
import { ItemAlbumComponent } from "./item.album";

export const DisplaySelectedComponent: React.FC = () => {
    const { artist, album } = useAppSelector(state => state.dashboard);
    const dispatch = useAppDispatch();

    return (<Grid container>
        <Grid container sx={{ display: "flex" }} spacing={.5}>
            <Grid item xs={12} md={12}>
                <ItemAlbumComponent artist={artist} album={album} />
            </Grid>
            <Grid item xs={12} md={12}>
                <Paper elevation={1}>
                    <ListContentAlbumComponent album={album} />
                </Paper>
            </Grid>
        </Grid>

    </Grid>
    );
}