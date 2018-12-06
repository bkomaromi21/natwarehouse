import { Component, OnInit, ViewChild, Input, OnChanges, SimpleChanges } from '@angular/core';
import {MatTable} from '@angular/material';

@Component({
  selector: 'app-stock-elements',
  templateUrl: './stock-elements.component.html',
  styleUrls: ['./stock-elements.component.css']
})
export class StockElementsComponent implements OnInit, OnChanges {

  @ViewChild(MatTable) table: MatTable<any>;
  @Input() stockElements: Array<any>;

  displayedColumns: string[] = ['name', 'description', 'price', 'priceInEur'];

  constructor() { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    //if(changes && this.table && changes.stockElements) {
    //  this.table.renderRows();
    //}
  }

}
