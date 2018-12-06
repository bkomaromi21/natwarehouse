import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class WarehouseApiService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  public getAll() {
    return this.http.get(this.accessPointUrl + 'stockelements/getall', {headers: this.headers});
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