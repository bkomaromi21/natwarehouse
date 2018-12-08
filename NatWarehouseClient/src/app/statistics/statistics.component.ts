import { Component, OnInit } from '@angular/core';
import { WarehouseApiService } from '../warehouse-api.service';

const EMPTY_STATISTICS_OBJECT = {
  heaviestPart: {name: ''},
  mostFrequentPart: {name: ''},
  sumMass: 0,
  sumPrice: 0
}

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {

  statistics: any = EMPTY_STATISTICS_OBJECT;

  constructor(private warehouseApiService: WarehouseApiService) {
    this.warehouseApiService.getStatistics().subscribe((data: any) => {
      if (data && data.heaviestPart && data.heaviestPart.name) {
        this.statistics = data;
      } else {
        this.statistics = EMPTY_STATISTICS_OBJECT;
      }
      
  })};

  ngOnInit() {
  }

}
