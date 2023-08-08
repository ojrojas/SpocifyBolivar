import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import { IAlbumResponse } from "../../../core/models/spocify/album";
import { ItemTracksComponent } from "./item.tracks";

interface Props {
    album?: IAlbumResponse
}
export const ListContentAlbumComponent: React.FC<Props> = ({ album }) => {
    return (
        <TableContainer>
            <Table size="small">
                <TableHead>
                    <TableRow>
                        <TableCell>#</TableCell>
                        <TableCell>Title</TableCell>
                        <TableCell>Album</TableCell>
                        <TableCell>Release Date</TableCell>
                        <TableCell>Duration</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {album && album.tracks && album.tracks.items && album.tracks.items.map((item, idx) => (
                        <ItemTracksComponent key={idx+album.id} item={item} album={album} idx={idx+1} />
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
}