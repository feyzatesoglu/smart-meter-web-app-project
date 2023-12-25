import { Injectable } from '@angular/core';
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }
// alertify success için method
success(message: string){
  alertify.success(message);

}

// alertify error için method
error(message: string){
  alertify.error(message);

}

// alertify warning için method
warning(message: string){
  alertify.warning(message);

}

}
