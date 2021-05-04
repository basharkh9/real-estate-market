import { PhotoService } from './services/photo.service';
import { PaginationComponent } from './components/shared/pagination.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { RealestateFormComponent } from './components/realestate-form/realestate-form.component';
import { RealEstateService } from './services/realestate.service';
import { RealestateListComponent } from './components/realestate-list/realestate-list.component';
import { ViewRealestateComponent } from './components/view-realestate/view-realestate.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PaginationComponent,
    RealestateFormComponent,
    RealestateListComponent,
    ViewRealestateComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ToastyModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: '/realestates', pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'realestates/new', component: RealestateFormComponent },
      { path: 'realestates/edit/:id', component: RealestateFormComponent },
      { path: 'realestates/:id', component: ViewRealestateComponent },
      { path: 'realestates', component: RealestateListComponent },
    ], { relativeLinkResolution: 'legacy' })
  ],
  providers: [
    RealEstateService,
    PhotoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
