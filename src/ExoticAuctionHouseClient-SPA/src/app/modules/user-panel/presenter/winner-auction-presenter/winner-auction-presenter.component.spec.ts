import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WinnerAuctionPresenterComponent } from './winner-auction-presenter.component';

describe('WinnerAuctionPresenterComponent', () => {
  let component: WinnerAuctionPresenterComponent;
  let fixture: ComponentFixture<WinnerAuctionPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WinnerAuctionPresenterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WinnerAuctionPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
