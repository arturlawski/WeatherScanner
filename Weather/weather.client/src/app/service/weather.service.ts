import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { CreateWeatherRequest, UpdateWeatherRequest, Weather } from "../model/weather";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  apiEndpoint :string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiEndpoint = baseUrl + 'api/weathers';
  }

  getWeathers(skip: number, take: number): Observable<Weather[]> {
    let params = new HttpParams();
    params = params.set('skip', skip.toString());
    params = params.set('take', take.toString());
    return this.http.get<Weather[]>(`${this.apiEndpoint}`, { params: params });
  }

  getWeather(weatherId: string): Observable<Weather> {
    return this.http.get<Weather>(`${this.apiEndpoint}/${weatherId}`);
  }

  deleteWeather(weatherId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiEndpoint}/${weatherId}`);
  }

  updateWeather(request: UpdateWeatherRequest): Observable<Weather> {
    return this.http.put<Weather>(`${this.apiEndpoint}/${request.id}`, request);
  }

  createWeather(request: CreateWeatherRequest): Observable<Weather> {
    return this.http.post<Weather>(`${this.apiEndpoint}`, request);
  }

  getWeathersCount(): Observable<number> {
    return this.http.get<number>(`${this.apiEndpoint}/count`);
  }
}
