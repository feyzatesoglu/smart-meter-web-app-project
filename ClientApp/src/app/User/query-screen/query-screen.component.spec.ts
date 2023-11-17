import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QueryScreenComponent } from './query-screen.component';

describe('QueryScreenComponent', () => {
  let component: QueryScreenComponent;
  let fixture: ComponentFixture<QueryScreenComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [QueryScreenComponent]
    });
    fixture = TestBed.createComponent(QueryScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
