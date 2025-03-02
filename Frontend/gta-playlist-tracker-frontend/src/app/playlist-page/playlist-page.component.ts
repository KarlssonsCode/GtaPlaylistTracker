import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PlaylistService } from '../services/playlist.service';
import { GameService } from '../services/game.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-playlist-page',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './playlist-page.component.html',
  styleUrl: './playlist-page.component.scss'
})
export class PlaylistPageComponent implements OnInit {

  name: string = '';
  gameId: number = 0;
  raceAmount: number = 0;

  games: any[] = [];
  playlists: any[] = [];

  constructor(private playlistService: PlaylistService,private gameService: GameService, private router: Router) {

  }

  ngOnInit() {
    this.getAllPlaylists();
    this.getAllGames();
  }

  updateScore(event: any) {
    this.raceAmount = event.target.value;
  }

  navigateToPlaylistInfoPage(id: number): void {
    this.router.navigate(['/playlist-info', id]);
  }

  createPlaylist() {
    const request = {
      name: this.name,
      gameId: this.gameId,
      races: this.raceAmount} ;
      this.playlistService.createPlaylist(request).subscribe(() => { console.log("Playlist created"); }) };
      


  getAllPlaylists() {
    this.playlistService.getAllPlaylists().subscribe({next: (playlists) => {
      console.log('Playlist',playlists);
      this.playlists = playlists;
    },
    error: (err) => {
      console.error('Error fetching playlists:', err);
  }})};

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
