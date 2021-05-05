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

// Import the module from the SDK
import { AuthModule } from '@auth0/auth0-angular';
import { FeedbackListComponent } from './components/feedback-list/feedback-list.component';
import { FeedbackService } from './services/feedback.service';

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
    ViewRealestateComponent,
    FeedbackListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    // Import the module into the application, with configuration
    AuthModule.forRoot({
      domain: 'furniture-store.eu.auth0.com',
      clientId: 'k09Nd723RLExPBtHlya1UBJOGA6gtDES',
      cacheLocation: 'localstorage'
    }),
    HttpClientModule,
    FormsModule,
    ToastyModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: '/realestates', pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'feedbacks', component: FeedbackListComponent },
      { path: 'realestates/new', component: RealestateFormComponent },
      { path: 'realestates/edit/:id', component: RealestateFormComponent },
      { path: 'realestates/:id', component: ViewRealestateComponent },
      { path: 'realestates', component: RealestateListComponent },
    ], { relativeLinkResolution: 'legacy' })
  ],
  providers: [
    RealEstateService,
    PhotoService,
    FeedbackService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
