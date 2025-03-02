import { Component, OnInit } from '@angular/core';
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
export class GamePageComponent implements OnInit {

  name: string = '';

  games: any[] = [];

constructor(
  private gameService: GameService
) {}

ngOnInit() {
  this.getAllGames();
}

addGame() {
  const request: CreateGameRequest = {
    name: this.name};

    this.gameService.addGame(request).subscribe(game => {
      console.log("Game added");
    });
  }
      
  getAllGames(): void {
    this.gameService.getAllGames().subscribe({
      next: (games) => {
      console.log('Games:', games)
      this.games = games;
    },
    error: (err) => { 
      console.error('Error fetching games:', err);
    }
  })
  }
}
