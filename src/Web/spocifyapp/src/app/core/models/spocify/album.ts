import { IArtist, ICopyright, IExternalIds, IExternalUrls, IImage, IRestrictions, ITracks } from "./search";

export interface ILinkedFrom {
    external_urls: IExternalUrls;
    href: string;
    id: string;
    type: string;
    uri: string;
}

export interface IAlbumResponse {
    album_type: string;
    total_tracks: number;
    available_markets: string[];
    external_urls: IExternalUrls;
    href: string;
    id: string;
    images: IImage[];
    name: string;
    release_date: string;
    release_date_precision: string;
    restrictions: IRestrictions;
    type: string;
    uri: string;
    copyrights: ICopyright[];
    external_ids: IExternalIds;
    genres: string[];
    label: string;
    popularity: number;
    artists: IArtist[];
    tracks: ITracks;
}