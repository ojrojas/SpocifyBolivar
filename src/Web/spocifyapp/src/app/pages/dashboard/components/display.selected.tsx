import React from "react"
import { Card, CardContent, Grid, Paper, Typography } from "@mui/material";
import { ListContentAlbumComponent } from "./listcontent.album";
import { useAppSelector } from "../../../hooks";

export const DisplaySelectedComponent: React.FC = () => {
    const {artist, album} = useAppSelector(state => state.dashboard);
    const major = 0;
    return (<Grid container>
            <Grid container sx={{ display: "flex" }} spacing={.5}>
                <Grid item xs={12} md={12}>
                    <Paper elevation={1}>
                        <Card sx={{display:"flex", flexDirection:'column'}}>
                            <Grid sx={{flex:5, justifyContent:'flex-start'}}></Grid>
                            <CardContent sx={{height:300 , backgroundImage: `url(${album?.images[major].url})`, position:'relative'}}>
                                <Typography variant="h5">{album?.name}</Typography>
                                <Typography variant="h6">{artist?.name}</Typography>
                            </CardContent>
                        </Card>
                    </Paper>
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