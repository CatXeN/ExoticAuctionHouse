import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionsListContainerComponent } from './auctions-list-container.component';

describe('AuctionsListContainerComponent', () => {
  let component: AuctionsListContainerComponent;
  let fixture: ComponentFixture<AuctionsListContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionsListContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuctionsListContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
