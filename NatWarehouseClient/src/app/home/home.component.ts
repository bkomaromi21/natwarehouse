import { Component, OnInit } from '@angular/core';
import { WarehouseApiService } from '../warehouse-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  stockElements: Array<any> = [];
  parts: Array<any> = [];

  constructor(private warehouseApiService: WarehouseApiService) {
    this.warehouseApiService.getAllStockElements().subscribe((data: any) => this.stockElements = data.stockElements);
    this.warehouseApiService.getAllParts().subscribe((data: any) => this.parts = data.parts);
  }

  ngOnInit() {
  }

  onDataChanged() {
    this.warehouseApiService.getAllStockElements().subscribe((data: any) => this.stockElements = data.stockElements);
  }

}
