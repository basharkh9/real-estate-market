import { Component, OnInit } from '@angular/core';
import { CladdingService } from 'src/app/services/realestate.service';

@Component({
  selector: 'app-realestate-form',
  templateUrl: './realestate-form.component.html',
  styleUrls: ['./realestate-form.component.css']
})
export class RealestateFormComponent implements OnInit {
  claddings;
  realestate: {};

  constructor(private claddingService: CladdingService) { }

  ngOnInit(): void {
    this.claddingService.getCladdings().subscribe(cladding => {
      this.claddings = cladding; 
    });
  }

}
