import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarsEditContainerComponent } from './cars-edit-container.component';

describe('CarsEditContainerComponent', () => {
  let component: CarsEditContainerComponent;
  let fixture: ComponentFixture<CarsEditContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarsEditContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarsEditContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
