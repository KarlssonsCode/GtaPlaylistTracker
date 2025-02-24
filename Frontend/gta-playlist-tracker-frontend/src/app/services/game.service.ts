import { Injectable } from "@angular/core";
import { CreateGameRequest, GameClient } from "../apinswag";
import { Observable } from "rxjs";



@Injectable({ providedIn: 'root' })
export class GameService {
    constructor(private gameClient: GameClient) {}

    addGame(requestBody: CreateGameRequest): Observable<void> {
        return this.gameClient.addGame(requestBody);
    }

    getAllGames(): Observable<any[]> {
        return this.gameClient.getAllGames();
    }

}