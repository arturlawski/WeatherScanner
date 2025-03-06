import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ToastrService } from "ngx-toastr";
import { catchError, EMPTY, forkJoin, switchMap, tap } from "rxjs";
import { Router } from "@angular/router";
import { Weather } from '../../model/weather';
import { WeatherService } from '../../service/weather.service';

@Component({
  selector: 'app-weathers-browser',
  templateUrl: './weathers-browser.component.html',
  styleUrls: ['./weathers-browser.component.css']
})
export class WeatherBrowserComponent implements OnInit {
  columnsToDisplay: string[] = ['latitude', 'longitude','weatherJson', 'actions'];
  weathers: Weather[] = [];
  totalWeathersCount: number;

  skip: number = 0;
  pageSize: number = 10;

  constructor(
    private weathersService: WeatherService,
    private toastrService: ToastrService,
    private router: Router,
    private cdr: ChangeDetectorRef
  ) {
  }

  ngOnInit(): void {
    forkJoin([
      this.weathersService.getWeathersCount(),
      this.weathersService.getWeathers(this.skip, this.pageSize)
    ]).subscribe({
      next: (([count, weathers]) => {
        this.totalWeathersCount = count;
        this.weathers = weathers;
      })
    })
  }

  removeWeather(weatherId: string) {
    if (confirm('Are you sure you want to delete this weather?')) {
      this.weathersService.deleteWeather(weatherId).pipe(
        catchError((err) => {
          this.toastrService.error('An error occured while trying to delete the weather');
          return EMPTY;
        }),
        tap(_ => {
          this.toastrService.success('Weather has been deleted');
        }),
        switchMap(_ => this.weathersService.getWeathers(this.skip, this.pageSize))
      ).subscribe({
        next: (weathers) => {
          this.totalWeathersCount--;
          this.weathers = weathers;
        }
      })
    }
  }

  redirectToEditOrCreate(weatherId?: string) {
    if (weatherId) {
      this.router.navigate(['weathers', weatherId, 'edit']);
    } else {
      this.router.navigate(['weathers', 'new']);
    }
  }

  onPaginatorClicked(event: any) {
    this.skip = this.pageSize * event.pageIndex;
    this.weathersService.getWeathers(this.skip, this.pageSize).subscribe({
      next: (weathers) => {
        this.weathers = weathers;
        this.cdr.markForCheck();
      }
    })
  }
}
