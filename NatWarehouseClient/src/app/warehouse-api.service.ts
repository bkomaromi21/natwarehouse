import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class WarehouseApiService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  public getAllStockElements() {
    return this.http.get(this.accessPointUrl + 'stockelements/getall', {headers: this.headers});
  }

  public getAllParts() {
    return this.http.get(this.accessPointUrl + 'parts/getall', {headers: this.headers});
  }

  public getStatistics() {
    return this.http.get(this.accessPointUrl + 'statistics/get', {headers: this.headers});
  }

  public increaseStockElement(payload) {
    return this.http.put(this.accessPointUrl + 'stockelements/increase', payload, {headers: this.headers});
  }

  public decreaseStockElement(payload) {
    return this.http.put(this.accessPointUrl + 'stockelements/decrease', payload, {headers: this.headers});
  }

  public addPart(payload) {
    return this.http.post(this.accessPointUrl, payload, {headers: this.headers});
  }

  public removePart(payload) {
    return this.http.delete(this.accessPointUrl + '/' + payload.id, {headers: this.headers});
  }

  public updatePart(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.id, payload, {headers: this.headers});
  }
}