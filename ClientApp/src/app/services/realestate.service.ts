import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RealestateService {

  constructor(private http: HttpClient) { }

  getRealEstate() {
    return this.http.get('/api/realestates/cladding');
  }
}
