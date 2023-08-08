import { TableRow, TableCell, Avatar, Grid, Typography } from "@mui/material";
import { IItem } from "../../../core/models/spocify/search";
import { IAlbumResponse } from "../../../core/models/spocify/album";
import { useAppDispatch } from "../../../hooks";

interface Props {
    item?: IItem;
    album?: IAlbumResponse;
    idx?: number;
}

export const ItemTracksComponent: React.FC<Props> = ({ item, album, idx }) => {
    const dispatch = useAppDispatch();

    const minor = 1;
    const NumberDurationConvert = (duration:number) => {
        const date = new Date(duration);
        const secondsregular = date.getSeconds().toString().padStart(2,'0');
        return `${date.getMinutes()}:${secondsregular}`;
    }

    return (
        <TableRow hover
        onClick={() => {}}
        >
            <TableCell>{idx ?? undefined}</TableCell>
            <TableCell>
                <Grid sx={{ display: "flex", alignItems:'center' }}>
                    <Avatar src={album?.images[minor].url} />
                    <Typography sx={{ padding:1 }}>
                        {item?.name}
                    </Typography>
                </Grid>
            </TableCell>
            <TableCell>{item?.name}</TableCell>
            <TableCell>{album?.release_date}</TableCell>
            <TableCell>{NumberDurationConvert(item?.duration_ms!)}</TableCell>
        </TableRow>
    );
}

