import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import { IAlbumResponse } from "../../../core/models/spocify/album";

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
                        <TableRow>
                            <TableCell>{idx+1}</TableCell>
                            <TableCell>{item.name}</TableCell>
                            <TableCell>{item.name}</TableCell>
                            <TableCell>{album?.release_date}</TableCell>
                            <TableCell>{item.duration_ms}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
}