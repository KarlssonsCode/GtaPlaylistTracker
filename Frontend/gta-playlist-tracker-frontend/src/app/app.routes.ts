import { Routes } from '@angular/router';
import { StartPageComponent } from './start-page/start-page.component';
import { PlaylistPageComponent } from './playlist-page/playlist-page.component';
import { PlayerPageComponent } from './player-page/player-page.component';
import { GamePageComponent } from './game-page/game-page.component';
import { AddPlayerPageComponent } from './add-player-page/add-player-page.component';

export const routes: Routes = [
    {
        path: '',
        component: StartPageComponent,
        title: 'StartPage'
    },

    {
        path: 'playlist',
        component: PlaylistPageComponent,
        title: 'PlaylistPage'
    },

    {
        path:'add-player',
        component: AddPlayerPageComponent,
        title: 'AddPlayerPage'
    },

    {
        path: 'player',
        component: PlayerPageComponent,
        title: 'PlayerPage'
    },

    {
        path: 'game',
        component: GamePageComponent,
        title: 'GamePage'
    }
];
