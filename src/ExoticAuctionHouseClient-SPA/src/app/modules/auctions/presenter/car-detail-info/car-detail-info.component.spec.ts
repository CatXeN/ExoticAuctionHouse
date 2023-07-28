import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarDetailInfoComponent } from './car-detail-info.component';

describe('CarDetailInfoComponent', () => {
  let component: CarDetailInfoComponent;
  let fixture: ComponentFixture<CarDetailInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarDetailInfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarDetailInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
