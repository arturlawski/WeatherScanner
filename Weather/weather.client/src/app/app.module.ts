import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from "@angular/material/table";
import { ToastrModule } from "ngx-toastr";
import { MatButtonModule } from "@angular/material/button";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatPaginatorModule } from "@angular/material/paginator";
import { WeatherBrowserComponent } from './weathers/weathers-browser/weathers-browser.component';
import { CreateOrUpdateWeatherComponent } from './weathers/create-or-update-weather/create-or-update-weather.component';

const MATERIAL = [
  MatTableModule,
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatPaginatorModule
]

@NgModule({
  declarations: [
    AppComponent,
    WeatherBrowserComponent,
    CreateOrUpdateWeatherComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'weathers', pathMatch: 'full' },
      { path: 'weathers', component: WeatherBrowserComponent },
      { path: 'weathers/new', component: CreateOrUpdateWeatherComponent},
      { path: 'weathers/:id/edit', component: CreateOrUpdateWeatherComponent},
      {path: '**', redirectTo: 'weathers'}
    ]),
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ...MATERIAL,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
