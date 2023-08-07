import { Box, Card, CardContent, CardMedia, CssBaseline, ListItem, ListItemButton, Tooltip, Typography } from "@mui/material";
import { Fragment } from "react"
import { IItem } from "../../../core/models/spocify/search";
import { useAppDispatch } from "../../../hooks";
import { album, artist } from "../redux/dashboard.actions";

interface Props {
    item: IItem
}

export const ItemListSeveralBrowseComponent: React.FC<Props> = ({ item }) => {
    const dispatch = useAppDispatch();    
    let major = 0;

    const onSelectedItem = (item:IItem)=> {
        dispatch(album(item.id));
        dispatch(artist(item.artists[major].id));
    }

    return (<Fragment>
        <CssBaseline />
        <ListItem
            key={item.id}
            disablePadding>
            <ListItemButton onClick={() => onSelectedItem(item)}>
                <Card sx={{ display: 'flex', width: '100%', height: 100 }}>
                    <CardMedia
                        component={'img'}
                        sx={{ width: 160 }}
                        image={item.images[major].url}
                    />
                    <Box sx={{ display: 'flex', flexDirection: 'column' }}>
                        <CardContent>
                            <Tooltip title={item.name}>
                                <Typography component="div" variant="subtitle1">
                                    {item.name.length > 24 ? `${item.name.substring(0, 23)}...` : item.name}
                                </Typography>
                            </Tooltip>
                            <Typography variant="caption" color="text.secondary" component="div">
                                {item.artists[major].name}
                            </Typography>
                            <Typography variant="caption" color="text.secondary" component="div">
                                {item.release_date}
                            </Typography>
                        </CardContent>
                    </Box>
                </Card>
            </ListItemButton>
        </ListItem>

    </Fragment>)
}