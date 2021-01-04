import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicamentTenderComponent } from './medicament-tender.component';

describe('MedicamentTenderComponent', () => {
  let component: MedicamentTenderComponent;
  let fixture: ComponentFixture<MedicamentTenderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MedicamentTenderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MedicamentTenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
