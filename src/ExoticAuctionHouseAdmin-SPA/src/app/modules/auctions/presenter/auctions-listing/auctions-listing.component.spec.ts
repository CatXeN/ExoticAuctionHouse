import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionsListingComponent } from './auctions-listing.component';

describe('AuctionsListingComponent', () => {
  let component: AuctionsListingComponent;
  let fixture: ComponentFixture<AuctionsListingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionsListingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuctionsListingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
