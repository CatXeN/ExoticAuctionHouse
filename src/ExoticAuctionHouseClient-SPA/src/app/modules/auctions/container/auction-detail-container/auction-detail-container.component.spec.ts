import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionDetailContainerComponent } from './auction-detail-container.component';

describe('AuctionDetailContainerComponent', () => {
  let component: AuctionDetailContainerComponent;
  let fixture: ComponentFixture<AuctionDetailContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionDetailContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuctionDetailContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
