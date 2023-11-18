import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyPaymentsPresenterComponent } from './my-payments-presenter.component';

describe('MyPaymentsPresenterComponent', () => {
  let component: MyPaymentsPresenterComponent;
  let fixture: ComponentFixture<MyPaymentsPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyPaymentsPresenterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyPaymentsPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
