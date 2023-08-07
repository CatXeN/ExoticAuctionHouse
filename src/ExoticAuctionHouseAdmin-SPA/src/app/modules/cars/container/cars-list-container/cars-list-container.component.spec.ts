import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarsListContainerComponent } from './cars-list-container.component';

describe('CarsListContainerComponent', () => {
  let component: CarsListContainerComponent;
  let fixture: ComponentFixture<CarsListContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarsListContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarsListContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
