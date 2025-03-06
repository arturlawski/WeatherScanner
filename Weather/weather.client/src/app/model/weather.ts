export interface Weather {
  id: string;
  weatherjson: string;
  latitude: number;
  longitude: number;
}

export interface CreateWeatherRequest {
  latitude: number;
  longitude: number;
}

export interface UpdateWeatherRequest extends CreateWeatherRequest {
  id: string;
}

