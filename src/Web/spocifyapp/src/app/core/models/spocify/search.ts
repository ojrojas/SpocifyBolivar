import { ILinkedFrom } from "./album";

export interface IAlbum {
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
  album_group: string;
  artists: IArtist[];
}

export interface IAlbums {
  href: string;
  limit: number;
  next: string;
  offset: number;
  previous: string;
  total: number;
  items: IItem[];
}

export interface IArtist {
  external_urls: IExternalUrls;
  href: string;
  id: string;
  name: string;
  type: string;
  uri: string;
  followers: IFollowers;
  genres: string[];
  images: IImage[];
  popularity: number;
  limit: number;
  next: string;
  offset: number;
  previous: string;
  total: number;
  items: IItem[];
}

export interface IAudiobooks {
  href: string;
  limit: number;
  next: string;
  offset: number;
  previous: string;
  total: number;
  items: IItem[];
}

export interface IAuthor {
  name: string;
}

export interface ICopyright {
  text: string;
  type: string;
}

export interface IEpisodes {
  href: string;
  limit: number;
  next: string;
  offset: number;
  previous: string;
  total: number;
  items: IItem[];
}

export interface IExternalIds {
  isrc: string;
  ean: string;
  upc: string;
}

export interface IExternalUrls {
  spotify: string;
}

export interface IFollowers {
  href: string;
  total: number;
}

export interface IImage {
  url: string;
  height: number;
  width: number;
}

export interface IItem {
  album: IAlbum;
  artists: IArtist[];
  available_markets: string[];
  disc_number: number;
  duration_ms: number;
  explicit: boolean;
  external_ids: IExternalIds;
  external_urls: IExternalUrls;
  href: string;
  id: string;
  is_playable: boolean;
  linked_from: ILinkedFrom;
  restrictions: IRestrictions;
  name: string;
  popularity: number;
  preview_url: string;
  track_number: number;
  type: string;
  uri: string;
  is_local: boolean;
  followers: IFollowers;
  genres: string[];
  images: IImage[];
  album_type: string;
  total_tracks: number;
  release_date: string;
  release_date_precision: string;
  copyrights: ICopyright[];
  label: string;
  album_group: string;
  collaborative: boolean;
  description: string;
  owner: IOwner;
  public: boolean;
  snapshot_id: string;
  tracks: ITracks;
  html_description: string;
  is_externally_hosted: boolean;
  languages: string[];
  media_type: string;
  publisher: string;
  total_episodes: number;
  audio_preview_url: string;
  language: string;
  resume_point: IResumePoint;
  authors: IAuthor[];
  edition: string;
  narrators: INarrator[];
  total_chapters: number;
}

export interface INarrator {
  name: string;
}

export interface IOwner {
  external_urls: IExternalUrls;
  followers: IFollowers;
  href: string;
  id: string;
  type: string;
  uri: string;
  display_name: string;
}

export interface IPlaylists {
  href: string;
  limit: number;
  next: string;
  offset: number;
  previous: string;
  total: number;
  items: IItem[];
}

export interface IRestrictions {
  reason: string;
}

export interface IResumePoint {
  fully_played: boolean;
  resume_position_ms: number;
}

export interface ISearchResponse {
  tracks: ITracks;
  artists: IArtist;
  albums: IAlbums;
  playlists: IPlaylists;
  shows: IShows;
  episodes: IEpisodes;
  audiobooks: IAudiobooks;
}

export interface IShows {
  href: string;
  limit: number;
  next: string;
  offset: number;
  previous: string;
  total: number;
  items: IItem[];
}

export interface ITracks {
  href: string;
  limit: number;
  next: string;
  offset: number;
  previous: string;
  total: number;
  items: IItem[];
}

export interface ISearchRequest {
  Query: string;
  Type: string;
  Market: string;
  Limit: number;
  OffSet: number;
}