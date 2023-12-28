import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LastQueriesScreenComponent } from './last-queries-screen.component';

describe('LastQueriesScreenComponent', () => {
  let component: LastQueriesScreenComponent;
  let fixture: ComponentFixture<LastQueriesScreenComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LastQueriesScreenComponent]
    });
    fixture = TestBed.createComponent(LastQueriesScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
