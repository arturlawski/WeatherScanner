import { ComponentFixture, TestBed } from '@angular/core/testing';
import { WeatherBrowserComponent } from './weathers-browser.component';


describe('WeatherBrowserComponent', () => {
  let component: WeatherBrowserComponent;
  let fixture: ComponentFixture<WeatherBrowserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WeatherBrowserComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeatherBrowserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
