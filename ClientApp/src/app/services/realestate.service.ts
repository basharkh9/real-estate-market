import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class RealEstateService {

  constructor(private http: HttpClient) { }

  getCladdings() {
    return this.http.get('/api/claddings');
  }

  getRealEstates(filter) {
    return this.http.get('/api/realestates' + '?' + this.toQueryString(filter));
  }

  create(realestate) {
    delete realestate.id;
    return this.http.post('/api/realestates', realestate);
  }

  getRealEstate(id) {
    return this.http.get('/api/realestates/' + id);   
  }

  update(realestate) {
    return this.http.put('/api/realestates/' + realestate.id, realestate);
  }

  delete(id) {
    return this.http.delete('/api/realestates/' + id);
  }

  toQueryString(obj) {
    var parts = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined) 
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }

    return parts.join('&');
  }
}
