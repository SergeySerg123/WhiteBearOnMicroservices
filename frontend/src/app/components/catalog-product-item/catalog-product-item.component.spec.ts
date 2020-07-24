import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CatalogProductItemComponent } from './catalog-product-item.component';

describe('CatalogProductItemComponent', () => {
  let component: CatalogProductItemComponent;
  let fixture: ComponentFixture<CatalogProductItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CatalogProductItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CatalogProductItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
