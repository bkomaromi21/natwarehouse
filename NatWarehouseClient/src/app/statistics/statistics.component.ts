import { Component, OnInit } from '@angular/core';
import { WarehouseApiService } from '../warehouse-api.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {

  statistics: any = { heaviestPart: {}, mostFrequenPart: {}};

  constructor(private warehouseApiService: WarehouseApiService) {
    this.warehouseApiService.getStatistics().subscribe((data: any) => this.statistics = data);
  }

  ngOnInit() {
  }

}
