import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CreateOrUpdateWeatherComponent } from './create-or-update-weather.component';

describe('CreateOrUpdateWeatherComponent', () => {
  let component: CreateOrUpdateWeatherComponent;
  let fixture: ComponentFixture<CreateOrUpdateWeatherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateOrUpdateWeatherComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateOrUpdateWeatherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
