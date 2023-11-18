import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainPanelContainerComponent } from './main-panel-container.component';

describe('MainPanelContainerComponent', () => {
  let component: MainPanelContainerComponent;
  let fixture: ComponentFixture<MainPanelContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MainPanelContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MainPanelContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
