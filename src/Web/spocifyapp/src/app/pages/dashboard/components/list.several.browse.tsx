import { List } from "@mui/material";
import { ItemListSeveralBrowseComponent } from "./item.list.several.browse";
import { IItem, ISearchResponse } from "../../../core/models/spocify/search";

interface Props {
    search: ISearchResponse
}

export const ListSeveralBrowseComponent: React.FC<Props> = ({ search }) => {
    return (
        <List dense sx={{ width: '100%',borderRadius:5 }}>
            {search && search.albums?.items.map((item: IItem, idx) => {
                return (
                    <ItemListSeveralBrowseComponent key={item.name + item.id + idx} item={item} />
                );
            })}
        </List>
    );
}