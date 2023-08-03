import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarDetailAccessoriesComponent } from './car-detail-accessories.component';

describe('CarDetailAccessoriesComponent', () => {
  let component: CarDetailAccessoriesComponent;
  let fixture: ComponentFixture<CarDetailAccessoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarDetailAccessoriesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarDetailAccessoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
