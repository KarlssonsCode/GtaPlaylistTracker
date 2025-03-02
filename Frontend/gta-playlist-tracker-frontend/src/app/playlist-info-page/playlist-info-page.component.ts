import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-playlist-info-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './playlist-info-page.component.html',
  styleUrl: './playlist-info-page.component.scss'
})
export class PlaylistInfoPageComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,

  ) {}

  ngOnInit(): void {
  this.route.params.subscribe(params => {
    const playlistId = params['playlistId'];
    this.getPlaylistDetails(playlistId);
  });
  }

  getPlaylistDetails(playlistId: number): void {
    console.log('Playlist ID:', playlistId);
  }
}
