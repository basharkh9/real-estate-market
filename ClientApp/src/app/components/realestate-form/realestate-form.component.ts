import { SaveRealEstate } from './../../models/realestate';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RealEstateService } from 'src/app/services/realestate.service';

@Component({
  selector: 'app-realestate-form',
  templateUrl: './realestate-form.component.html',
  styleUrls: ['./realestate-form.component.css']
})
export class RealestateFormComponent implements OnInit {
  cladding: any[]; 
  claddings;
  realestate: SaveRealEstate = {
    id: 0,
    claddingId: 0,
    area: 0,
    level: 0,
    numberOfRooms: 0,
    price: 0,
    isBooked: false,
    address: '',
  };

  constructor(
    private route: ActivatedRoute, 
    private router: Router, 
    private realestateService: RealEstateService) {
      route.params.subscribe(p =>{
        this.realestate.id = +p['id'] || 0;
      });
    }
  ngOnInit(): void {
    if(this.realestate.id)
    this.realestateService.getRealEstate(this.realestate.id)
      .subscribe(r => 
        {
          return this.setRealEstate(r as SaveRealEstate);
        }
      , err => {
        if (err.status == 404)
          this.router.navigate(['/']);
      });
    this.realestateService.getCladdings().subscribe(claddings => {
      this.claddings = claddings; 
    });
  }
  setRealEstate (r: SaveRealEstate) {
    this.realestate.id = r.id;
    this.realestate.level = r.level;
    this.realestate.address = r.address;
    this.realestate.claddingId = r.claddingId;
    this.realestate.price = r.price;
    this.realestate.area = r.area;
    this.realestate.numberOfRooms = r.numberOfRooms;
    this.realestate.isBooked = r.isBooked;
  }

  onCladdingChange() {
    var selectedCladding = this.claddings.find(c => c.id == this.realestate.claddingId);
    this.realestate.claddingId = selectedCladding.id;
  }

  submit() {
    if(this.realestate.id) {
      this.realestateService.update(this.realestate).subscribe(
        x => {
          console.log("The realEstate was successfully updated.");
        }
      );
    } else {
      this.realestateService.create(this.realestate).subscribe(
          res => this.setRealEstate(res as SaveRealEstate),
          err => {
            console.log("An unexpected error happened."); 
          });
    }

  }

  delete() {
    if (confirm("Are you sure?")) {
      this.realestateService.delete(this.realestate.id)
        .subscribe(x => {
          this.router.navigate(['/']);
        });
    }
  }

}
