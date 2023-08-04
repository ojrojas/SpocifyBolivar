import { Avatar, List, ListItem, ListItemAvatar, ListItemButton, ListItemText } from "@mui/material";
import { Fragment } from "react"
import { Item } from "../../../core/models/spocify/search";

interface Props {
    item:Item
}

export const ItemListSeveralBrowseComponent: React.FC<Props> = ({item}) => {
    let major = 0;
    return (<Fragment>
        <ListItem
            key={item.id}
            disablePadding
        >
            <ListItemButton>
                <ListItemAvatar>
                    <Avatar
                        alt={`Avatar n°${item.id}`}
                        src={`${item.images[major].url}`}
                    />
                </ListItemAvatar>
                <ListItemText id={item.id+item.name} primary={`${item.name}`} />
            </ListItemButton>
        </ListItem>

    </Fragment>)
}