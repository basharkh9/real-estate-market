import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class FeedbackService {
    constructor(private http: HttpClient) { }

    getFeedbacks() {
        return this.http.get('/api/feedbacks');
    }
}