import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { GameClient, PlayerClient, PlaylistClient } from './apinswag';
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    PlayerClient,
    GameClient,
    PlaylistClient,
    provideRouter(routes),
    provideHttpClient()]
};
