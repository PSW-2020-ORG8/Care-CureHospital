import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InactiveTenderComponent } from './inactive-tender.component';

describe('InactiveTenderComponent', () => {
  let component: InactiveTenderComponent;
  let fixture: ComponentFixture<InactiveTenderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InactiveTenderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InactiveTenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
