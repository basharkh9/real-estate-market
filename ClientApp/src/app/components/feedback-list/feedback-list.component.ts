import { Component, OnInit } from '@angular/core';
import { FeedbackService } from 'src/app/services/feedback.service';

@Component({
  selector: 'app-feedback-list',
  templateUrl: './feedback-list.component.html',
  styleUrls: ['./feedback-list.component.css']
})
export class FeedbackListComponent implements OnInit {
  feedbacks: any[];
  constructor(private feedbackService: FeedbackService) { }

  ngOnInit(): void {
    this.feedbackService.getFeedbacks().subscribe(
      r => {
        this.feedbacks = r as any[];
      }
    );
  }

}
