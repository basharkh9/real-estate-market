import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CladdingService {

  constructor(private http: HttpClient) { }

  getCladdings() {
    return this.http.get('/api/claddings');
  }
}
