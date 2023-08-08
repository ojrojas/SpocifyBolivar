import { IExternalUrls, IItem } from "./search";

export interface IPlayerPlayResumeRequest {
    context_uri: string;
    position_ms: number;
    offset: IOffSet;
}

export interface IOffSet {
    position: number;
}

export interface IActions {
    interrupting_playback: boolean;
    pausing: boolean;
    resuming: boolean;
    seeking: boolean;
    skipping_next: boolean;
    skipping_prev: boolean;
    toggling_repeat_context: boolean;
    toggling_shuffle: boolean;
    toggling_repeat_track: boolean;
    transferring_playback: boolean;
}

export interface IContext {
    type: string;
    href: string;
    external_urls: IExternalUrls;
    uri: string;
}

export interface IDevice {
    id: string;
    is_active: boolean;
    is_private_session: boolean;
    is_restricted: boolean;
    name: string;
    type: string;
    volume_percent: number;
}

export interface IPlayerStateResponse {
    device: IDevice;
    repeat_state: string;
    shuffle_state: boolean;
    context: IContext;
    timestamp: number;
    progress_ms: number;
    is_playing: boolean;
    item: IItem;
    currently_playing_type: string;
    actions: IActions;
}
