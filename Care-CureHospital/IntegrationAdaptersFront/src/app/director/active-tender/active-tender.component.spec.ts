import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveTenderComponent } from './active-tender.component';

describe('ActiveTenderComponent', () => {
  let component: ActiveTenderComponent;
  let fixture: ComponentFixture<ActiveTenderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActiveTenderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActiveTenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
