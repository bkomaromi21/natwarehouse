import { Component, OnInit, ViewChild, Input } from '@angular/core';
import {MatTable} from '@angular/material';

@Component({
  selector: 'app-stock-elements',
  templateUrl: './stock-elements.component.html',
  styleUrls: ['./stock-elements.component.css']
})
export class StockElementsComponent implements OnInit {

  @ViewChild(MatTable) table: MatTable<any>;
  @Input() stockElements: Array<any>;

  displayedColumns: string[] = ['name', 'description', 'mass', 'price', 'priceInEur', 'quantity'];

  constructor() { }

  ngOnInit() {
  }
}
