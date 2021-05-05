import { Component } from '@angular/core';
// Import the AuthService type from the SDK
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isLoggedIn: boolean;
  // Inject the authentication service into your component through the constructor
  constructor(public auth: AuthService) {}

  ngOnInit(): void {
    
    this.auth.isAuthenticated$.subscribe(r => {
      this.isLoggedIn = r;
      if(this.isLoggedIn) {
        this.auth.user$.subscribe(u => console.log(u));
        this.auth.idTokenClaims$.subscribe(t => {
          localStorage.setItem('token', t.__raw);
        });
      }
      });
    
  }
  
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
