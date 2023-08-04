import { List } from "@mui/material";
import { Fragment } from "react"
import { ItemListSeveralBrowseComponent } from "./item.list.several.browse";
import { Item, Search } from "../../../core/models/spocify/search";

interface Props {
    search: Search
}

export const ListSeveralBrowseComponent: React.FC<Props> = ({ search }) => {
    return (<Fragment>

        <List dense sx={{ width: '100%', maxWidth: 360, bgcolor: 'background.paper' }}>
            {search && search.albums?.items.map((item: Item, idx) => {
                return (
                    <ItemListSeveralBrowseComponent key={item.name+item.id+idx} item={item} />
                );
            })}
        </List>
    </Fragment>);
}