import { Injectable } from "@angular/core";
import { CreatePlayerRequest, FileParameter, PlayerClient } from "../apinswag";
import { Observable } from "rxjs";

export interface Player {
    id: number;
    gamertag: string;
    name?: string;
    profilePictureUrl?: string;
}

@Injectable({ providedIn: 'root' })
export class PlayerService {
    constructor(private playerClient: PlayerClient) {}

    createNewPlayer(requestBody: CreatePlayerRequest): Observable<void> {
        return this.playerClient.createPlayer(requestBody);
    }

    getAllPlayers():Observable<any[]> {
        return this.playerClient.getAllPlayers();
    }

    uploadProfilePicture(playerId: number, file: File): Observable<any> {
        const fileParameter: FileParameter = {
            data: file,
            fileName: file.name
        };

        return this.playerClient.uploadProfilePicture(playerId, fileParameter);
    }
}