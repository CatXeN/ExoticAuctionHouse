import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchasedCarsPresenterComponent } from './purchased-cars-presenter.component';

describe('PurchasedCarsPresenterComponent', () => {
  let component: PurchasedCarsPresenterComponent;
  let fixture: ComponentFixture<PurchasedCarsPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchasedCarsPresenterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurchasedCarsPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
