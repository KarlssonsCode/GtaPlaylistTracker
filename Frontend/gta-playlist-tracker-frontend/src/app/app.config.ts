import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { API_BASE_URL, GameClient, PlayerClient, PlaylistClient } from './apinswag';
import { provideHttpClient } from '@angular/common/http';
import { environment } from '../environments/enviroment.development';

export const appConfig: ApplicationConfig = {
  providers: [
    PlayerClient,
    GameClient,
    PlaylistClient,
    {provide:API_BASE_URL, useValue: environment.API_URL},
    provideRouter(routes),
    provideHttpClient()]
};
