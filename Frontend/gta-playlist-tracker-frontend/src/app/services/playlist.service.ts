import { Injectable } from "@angular/core";
import { CreatePlaylistRequest, PlaylistClient } from "../apinswag";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class PlaylistService {
    constructor(private playlistClient: PlaylistClient) {}

    createPlaylist(requestBody: CreatePlaylistRequest): Observable <void> {
        return this.playlistClient.createPlaylist(requestBody);
    }

    getAllPlaylists(): Observable<any[]> {
        return this.playlistClient.getAllPlaylists();
    }
    
}