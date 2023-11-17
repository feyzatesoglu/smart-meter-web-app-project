import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ShowFormService {

  constructor() { }
  kayitFormuGoster: boolean[] = [false, false, false]; // Her buton için bir boolean değer saklayacak dizi

  toggleKayitFormuGoster(index: number) {
    this.kayitFormuGoster[index] = !this.kayitFormuGoster[index];
  }
}
