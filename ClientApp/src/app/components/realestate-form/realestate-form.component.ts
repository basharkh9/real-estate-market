import { Component, OnInit } from '@angular/core';
import { RealestateService } from 'src/app/services/realestate.service';

@Component({
  selector: 'app-realestate-form',
  templateUrl: './realestate-form.component.html',
  styleUrls: ['./realestate-form.component.css']
})
export class RealestateFormComponent implements OnInit {
  realestates;

  constructor(private realestateService: RealestateService) { }

  ngOnInit(): void {
    this.realestateService.getRealEstate().subscribe(realestate => {
      this.realestates =realestate; 
    });
  }

}
