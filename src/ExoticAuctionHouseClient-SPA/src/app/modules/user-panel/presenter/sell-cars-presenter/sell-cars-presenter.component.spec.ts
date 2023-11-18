import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SellCarsPresenterComponent } from './sell-cars-presenter.component';

describe('SellCarsPresenterComponent', () => {
  let component: SellCarsPresenterComponent;
  let fixture: ComponentFixture<SellCarsPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SellCarsPresenterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SellCarsPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
