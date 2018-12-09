import { Component, OnInit } from '@angular/core';
import { WarehouseApiService } from '../warehouse-api.service';

const EMPTY_PART_OBJECT = {
  id: 0,
  name: '',
  description: '',
  price: 0,
  mass: 0
}

@Component({
  selector: 'app-parts',
  templateUrl: './parts.component.html',
  styleUrls: ['./parts.component.css']
})
export class PartsComponent implements OnInit {

  emptyObject = EMPTY_PART_OBJECT;

  selectedPart;
  parts: Array<any> = [];
  partToEdit: any = EMPTY_PART_OBJECT;
  
  constructor(private warehouseApiService: WarehouseApiService) {
    this.updateParts();
  }

  ngOnInit() {
  }

  updateParts() {
    this.warehouseApiService.getAllParts().subscribe((data: any) => this.parts = data.parts);
    this.partToEdit = Object.assign({}, EMPTY_PART_OBJECT);
    this.selectedPart = Object.assign({}, EMPTY_PART_OBJECT);
  }

  save() {
    if(this.selectedPart.id === 0) {
      this.warehouseApiService.addPart(this.partToEdit).subscribe(res => this.updateParts());
    } else {
      this.warehouseApiService.updatePart(this.partToEdit).subscribe(res => this.updateParts());
    }
  }

  delete() {
    if(!(this.selectedPart.id === 0)) {
      this.warehouseApiService.removePart(this.partToEdit.id).subscribe(res => this.updateParts());
    }
  }

  selectedPartChanged(event) {
    if(this.selectedPart.id === 0) {
      this.partToEdit = Object.assign({}, EMPTY_PART_OBJECT);
    } else {
      this.partToEdit = this.parts.find((element) => element.id = this.selectedPart.id);
    }
  }

}
