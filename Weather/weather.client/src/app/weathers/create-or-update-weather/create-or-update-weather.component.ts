import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { filter, map, Subject, switchMap, takeUntil } from "rxjs";
import { ToastrService } from "ngx-toastr";
import { FormBuilder, FormControl, Validators } from "@angular/forms";
import { Weather, CreateWeatherRequest, UpdateWeatherRequest } from '../../model/weather';
import { WeatherService } from '../../service/weather.service';

@Component({
  selector: 'app-create-or-update-weather',
  templateUrl: './create-or-update-weather.component.html',
  styleUrls: ['./create-or-update-weather.component.css']
})
export class CreateOrUpdateWeatherComponent implements OnInit {
  weather: Weather;
  showErrors = false;
  ngUnsubscribe = new Subject<void>();

  formGroup = this.fb.group({
    latitude: new FormControl<number | null>(null, {
      validators: [
        Validators.required,
        Validators.min(-90),
        Validators.max(90),
      ],
    }),
    longitude: new FormControl<number | null>(null, {
      validators: [
        Validators.required,
        Validators.min(-180),
        Validators.max(180),
      ],
    }),
  });

  constructor(
    private route: ActivatedRoute,
    private weatherService: WeatherService,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.route.params.pipe(
      takeUntil(this.ngUnsubscribe),
      map(params => params['id']),
      filter(id => !!id),
      switchMap(id => this.weatherService.getWeather(id))
    ).subscribe({
      next: (weather => {
        this.weather = weather;
        this.patchForm();
      })
    })
  }

  submit() {
    this.formGroup.markAllAsTouched();
    this.showErrors = true;
    if (!this.formGroup.valid) {
      return;
    }
    if (this.weather?.id) {
      this.updateWeather();
      return;
    }
    this.createWeather();
  }

  redirectToWeathersBrowser() {
    this.router.navigate(['browser']);
  }

  private createWeather() {
    this.weatherService.createWeather(this.getCreateupdateWeatherRequest()).subscribe({
      next: (_) => {
        this.toastr.success('Weather has been created');
        this.router.navigate(['weathers']);
      }
    })
  }

  private getCreateupdateWeatherRequest(): CreateWeatherRequest {
    return {
      longitude: this.formGroup.controls.longitude.value!,
      latitude: this.formGroup.controls.latitude.value!,
    };
  }

  private updateWeather() {
    this.weatherService.updateWeather(this.getUpdateWeatherRequest()).subscribe({
      next: (_) => {
        this.toastr.success('Weather has been updated');
        this.router.navigate(['weathers']);
      }
    })
  }

  private getUpdateWeatherRequest(): UpdateWeatherRequest {
    return {
      id: this.weather.id,
      latitude: this.weather.latitude!,
      longitude: this.weather.longitude!
    };
  }

  private patchForm() {
    this.formGroup.patchValue({
      longitude: this.weather.longitude,
      latitude: this.weather.latitude,
    })
  }
}
