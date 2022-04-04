import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PossibledriveComponent } from './possibledrive.component';

describe('PossibledriveComponent', () => {
  let component: PossibledriveComponent;
  let fixture: ComponentFixture<PossibledriveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PossibledriveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PossibledriveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
