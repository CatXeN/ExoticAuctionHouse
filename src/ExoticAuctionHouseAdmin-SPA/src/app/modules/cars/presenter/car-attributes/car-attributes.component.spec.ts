import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarAttributesComponent } from './car-attributes.component';

describe('CarAttributesComponent', () => {
  let component: CarAttributesComponent;
  let fixture: ComponentFixture<CarAttributesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarAttributesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarAttributesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
