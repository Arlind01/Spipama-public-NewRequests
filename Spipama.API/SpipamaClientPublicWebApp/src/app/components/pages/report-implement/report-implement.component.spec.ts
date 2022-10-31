import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportImplementComponent } from './report-implement.component';

describe('ReportImplementComponent', () => {
  let component: ReportImplementComponent;
  let fixture: ComponentFixture<ReportImplementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportImplementComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportImplementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
