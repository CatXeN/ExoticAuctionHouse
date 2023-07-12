import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BetContainerComponent } from './bet-container.component';

describe('BetContainerComponent', () => {
  let component: BetContainerComponent;
  let fixture: ComponentFixture<BetContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BetContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BetContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
