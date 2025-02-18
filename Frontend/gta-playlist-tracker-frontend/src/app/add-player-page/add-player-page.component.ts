import { Component } from '@angular/core';
import { PlayerService } from '../services/player.service';
import { CreatePlayerRequest } from '../apinswag';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-player-page',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './add-player-page.component.html',
  styleUrl: './add-player-page.component.scss'
})
export class AddPlayerPageComponent {
  gamertag: string = '';
  name?: string = '';
  profilePictureUrl?: string = '';

  constructor(
    private playerService: PlayerService	
  ) {}

  createPlayer() {
    const request: CreatePlayerRequest = {
      gamertag: this.gamertag,
      name: this.name,
      profilePictureUrl: this.profilePictureUrl,
    };

    this.playerService.createNewPlayer(request).subscribe({
      next: () => {
        console.log('Player has been created');
      },
      error: (err) => {
        console.error('Something went wrong:', err)
      }
    })

  }
}

