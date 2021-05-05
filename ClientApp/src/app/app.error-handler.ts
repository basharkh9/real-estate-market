 import { ToastyService } from 'ng2-toasty';
import { ErrorHandler, Inject, NgZone, isDevMode } from '@angular/core';

export class AppErrorHandler implements ErrorHandler {
  constructor(
    private ngZone: NgZone){}
    

  handleError(error: any): void {
    this.ngZone.run(() => {
      console.log(error)
    });
     
      throw error;
  }
}