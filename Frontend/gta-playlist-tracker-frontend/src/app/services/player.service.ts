import { Injectable } from "@angular/core";
import { CreatePlayerRequest, PlayerClient } from "../apinswag";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class PlayerService {
    constructor(private playerClient: PlayerClient) {}

    createNewPlayer(requestBody: CreatePlayerRequest): Observable<void> {
        return this.playerClient.createPlayer(requestBody);
    }
}