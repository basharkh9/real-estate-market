import { RealEstateService } from 'src/app/services/realestate.service';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-realestate-list',
  templateUrl: './realestate-list.component.html',
  styleUrls: ['./realestate-list.component.css']
})
export class RealestateListComponent implements OnInit {
  isLoggedIn: boolean = false;
  private readonly PAGE_SIZE = 4;
  queryResult: any = {};
  cladding: any = {};
  query: any = {
    pageSize: this.PAGE_SIZE
  };
  columns = [
    { title: 'Id' },
    { title: 'Cladding', key: 'cladding', isSortable: true },
    { title: 'Level', key: 'level', isSortable: true },
    { title: 'Address', key: 'address', isSortable: true },
    { }
  ];
  realestates: any[];
  allRealestates: any[];
  claddings: any[];
  filter: any = {};

  constructor(public auth: AuthService,private realEstateService: RealEstateService) { }

  ngOnInit(): void {
    this.auth.isAuthenticated$.subscribe(r => {this.isLoggedIn = r;});
    this.realEstateService.getCladdings().subscribe(claddings => {
      this.claddings = claddings as any []; 
    });

    this.populateRealEstate();
  }

  private populateRealEstate() {
    this.realEstateService.getRealEstates(this.query)
      .subscribe(result => this.queryResult = result);
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateRealEstate();
  }

  onFilterChange() {
    this.query.page = 1; 
    this.populateRealEstate();
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending; 
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateRealEstate();
  }

  onPageChange(page) {
    this.query.page = page; 
    this.populateRealEstate();
  }

}
