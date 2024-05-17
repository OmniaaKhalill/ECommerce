import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { addTokenInterceptor } from './interceptor/add-token.interceptor';
import { ReactiveFormsModule } from '@angular/forms';
import { ColorPickerModule } from 'ngx-color-picker';


export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes),provideHttpClient(),BrowserModule,BrowserAnimationsModule,provideHttpClient(withInterceptors([addTokenInterceptor])), ReactiveFormsModule,ColorPickerModule]
};
