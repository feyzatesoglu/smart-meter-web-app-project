import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WanComponent } from './wan.component';

describe('WanComponent', () => {
  let component: WanComponent;
  let fixture: ComponentFixture<WanComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WanComponent]
    });
    fixture = TestBed.createComponent(WanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
