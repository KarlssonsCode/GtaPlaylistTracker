import { Component } from '@angular/core';
import { CreateGameRequest } from '../apinswag';
import { GameService } from '../services/game.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-game-page',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './game-page.component.html',
  styleUrl: './game-page.component.scss'
})
export class GamePageComponent {

  name: string = '';

constructor(
  private gameService: GameService
) {}

addGame() {
  const request: CreateGameRequest = {
    name: this.name};

    this.gameService.addGame(request).subscribe(game => {
      console.log("Game added");
    });
  }
      
}
