import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { WarehouseApiService } from '../warehouse-api.service';

@Component({
  selector: 'app-stock-element-editor',
  templateUrl: './stock-element-editor.component.html',
  styleUrls: ['./stock-element-editor.component.css']
})
export class StockElementEditorComponent implements OnInit {

  @Input() parts: Array<any>;
  @Output() dataChanged = new EventEmitter<boolean>();

  selectedPart: any;
  quantity: number;

  constructor(private warehouseApiService: WarehouseApiService) { }

  ngOnInit() {
  }

  public increase () {
    this.warehouseApiService.increaseStockElement({partId: this.selectedPart.id, changedQuantity: this.quantity}).subscribe((data: any) => this.dataChanged.emit(true));
  }

  public decrease () {
    this.warehouseApiService.decreaseStockElement({partId: this.selectedPart.id, changedQuantity: this.quantity}).subscribe((data: any) => this.dataChanged.emit(true));
  }

}
