import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionsEditContainerComponent } from './auctions-edit-container.component';

describe('AuctionsEditContainerComponent', () => {
  let component: AuctionsEditContainerComponent;
  let fixture: ComponentFixture<AuctionsEditContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionsEditContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuctionsEditContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
