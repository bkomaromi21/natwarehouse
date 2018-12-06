import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StockElementsComponent } from './stock-elements.component';

describe('StockElementsComponent', () => {
  let component: StockElementsComponent;
  let fixture: ComponentFixture<StockElementsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StockElementsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StockElementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
