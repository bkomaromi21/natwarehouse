import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-stock-element-editor',
  templateUrl: './stock-element-editor.component.html',
  styleUrls: ['./stock-element-editor.component.css']
})
export class StockElementEditorComponent implements OnInit {

  @Input() parts: Array<any>;

  constructor() { }

  ngOnInit() {
  }

}
