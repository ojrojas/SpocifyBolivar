import React from "react"
import { Card, CardContent, Grid, Paper, Typography } from "@mui/material";
import { IArtist } from "../../../core/models/spocify/search";
import { IAlbumResponse } from "../../../core/models/spocify/album";

interface Props {
    artist?: IArtist,
    album?: IAlbumResponse;
}

export const ItemAlbumComponent: React.FC<Props> = ({ album, artist }) => {
    const major = 0
    return (
        <Paper elevation={1}>
            <Card sx={{ display: "flex", flexDirection: 'column' }}>
                <Grid sx={{ flex: 5, justifyContent: 'flex-start' }}>
                    <CardContent sx={{height: 600 , backgroundImage: `url(${album?.images[major].url})`,objectFit:'contain', backgroundRepeat:'no-repeat', backgroundSize:'cover' }}>
                        <Typography variant="h5" color={'white'}>{album?.name}</Typography>
                        <Typography variant="h6" color={'white'}>{artist?.name}</Typography>
                    </CardContent>
                </Grid>
            </Card>
        </Paper>
    );
}