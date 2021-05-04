import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PhotoService {

  constructor(private http: HttpClient) { }

  upload(realEstateId, photo) {
    var formData = new FormData();
    formData.append('file', photo);
    return this.http.post(`/api/realestates/${realEstateId}/photos`, formData);
  }

  getPhotos(realEstateId) {
    return this.http.get(`/api/realestates/${realEstateId}/photos`);
  }
}