import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BottleDialogComponent } from './bottle-dialog.component';

describe('BottleDialogComponent', () => {
  let component: BottleDialogComponent;
  let fixture: ComponentFixture<BottleDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BottleDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BottleDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
