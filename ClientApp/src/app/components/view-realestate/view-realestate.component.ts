import { PhotoService } from './../../services/photo.service';
import { RealEstateService } from './../../services/realestate.service';
import { ToastyService } from 'ng2-toasty';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-view-realestate',
  templateUrl: './view-realestate.component.html',
  styleUrls: ['./view-realestate.component.css']
})
export class ViewRealestateComponent implements OnInit {
  @ViewChild('fileInput') fileInput: ElementRef;
  realEstate: any;
  realEstateId: number;
  photos: any[];
  isLoggedIn: boolean = false;

  constructor(
    public auth: AuthService,
    private router: Router,
    private photoService: PhotoService,
    private route: ActivatedRoute,
    private toasty: ToastyService,
    private realEstateService: RealEstateService) {
      route.params.subscribe(p => {
        this.realEstateId = +p['id'];
        if(isNaN(this.realEstateId) || this.realEstateId <=0) {
          router.navigate(['realestates']);
          return;
        }
      });
     }

  ngOnInit(): void {
    this.auth.isAuthenticated$.subscribe(r => {this.isLoggedIn = r;});
      
    this.photoService.getPhotos(this.realEstateId) 
      .subscribe(photos => this.photos = photos as any[]);

    this.realEstateService.getRealEstate(this.realEstateId)
      .subscribe(
        r => this.realEstate = r,
        err => { 
          if(err == 404) 
          {
            this.router.navigate(['/realestates']);
            return;
          }  
        }
      );
  }

  delete() {
    if(confirm('Are you sure?')) {
      this.realEstateService.delete(this.realEstate.Id)
        .subscribe(x => {
          this.router.navigate(['/realestates']);
        });
    }
  }

  uploadPhoto() {
    var nativeElement: HTMLInputElement = this.fileInput.nativeElement;

    this.photoService.upload(this.realEstateId, nativeElement.files[0])
      .subscribe( photo => {
        this.photos.push(photo);
      },
      err => {
        this.toasty.error({
          title: 'Error',
          msg: err.error,
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
        });
      });
  }

}
