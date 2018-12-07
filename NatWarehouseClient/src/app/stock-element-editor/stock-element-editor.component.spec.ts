import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StockElementEditorComponent } from './stock-element-editor.component';

describe('StockElementEditorComponent', () => {
  let component: StockElementEditorComponent;
  let fixture: ComponentFixture<StockElementEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StockElementEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StockElementEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
