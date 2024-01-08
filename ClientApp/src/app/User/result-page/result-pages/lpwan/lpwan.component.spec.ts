import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LpwanComponent } from './lpwan.component';

describe('LpwanComponent', () => {
  let component: LpwanComponent;
  let fixture: ComponentFixture<LpwanComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LpwanComponent]
    });
    fixture = TestBed.createComponent(LpwanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
