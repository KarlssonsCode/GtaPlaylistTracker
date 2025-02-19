import { Component, OnInit } from '@angular/core';
import { PlayerService } from '../services/player.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-start-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './start-page.component.html',
  styleUrl: './start-page.component.scss'
})
export class StartPageComponent implements OnInit{
  players: any[] = [];

  constructor( private playerService: PlayerService,) {

  }

  ngOnInit(): void {
    this.fetchPlayers();
  }

  fetchPlayers(): void {
    this.playerService.getAllPlayers().subscribe({
      next: (players) => {
        console.log('Players:', players)
        this.players = players;
      },
      error: (err) => {
        console.error('Error fetching players:', err);
      }
    })
  }
}
