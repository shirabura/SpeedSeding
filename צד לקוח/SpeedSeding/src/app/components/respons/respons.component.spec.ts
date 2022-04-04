import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResponsComponent } from './respons.component';

describe('ResponsComponent', () => {
  let component: ResponsComponent;
  let fixture: ComponentFixture<ResponsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResponsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResponsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
