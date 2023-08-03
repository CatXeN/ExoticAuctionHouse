import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MobileMenuListComponent } from './mobile-menu-list.component';

describe('MobileMenuListComponent', () => {
  let component: MobileMenuListComponent;
  let fixture: ComponentFixture<MobileMenuListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MobileMenuListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MobileMenuListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
