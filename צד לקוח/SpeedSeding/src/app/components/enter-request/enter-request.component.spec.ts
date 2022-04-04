import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnterRequestComponent } from './enter-request.component';

describe('EnterRequestComponent', () => {
  let component: EnterRequestComponent;
  let fixture: ComponentFixture<EnterRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EnterRequestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EnterRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
