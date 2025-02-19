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
  profilePicture?: File;
  profilePicturePreview?: string;
  playerId?: number;

  constructor(
    private playerService: PlayerService	
  ) {}

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.profilePicture = file;

      const reader = new FileReader();
      reader.onload = (e: any) => this.profilePicturePreview = e .target.result;
      reader.readAsDataURL(file);
    }
  }

  createPlayer() {
    const request: CreatePlayerRequest = {
      gamertag: this.gamertag,
      name: this.name,
      profilePictureUrl: ''
    };

    this.playerService.createNewPlayer(request).subscribe(player => {
      if (this.profilePicture) {
        this.uploadProfilePicture();
      }
    });
  }

  uploadProfilePicture() {
    if (!this.profilePicture || !this.playerId) return;  

    const formData = new FormData();
    formData.append("file", this.profilePicture);

    this.playerService.uploadProfilePicture(this.playerId, this.profilePicture).subscribe({
      next: () => console.log("Upload successful"),
      error: err => console.error("Upload failed", err)
    });
}
}
