import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class QueryService {


private apiUrl = 'https://localhost:7069/api/Recommendation'; // API'nizin URL'si

constructor(private http: HttpClient) { }

postRecommendation(recommendationData: any) {
  return this.http.post<any>(`${this.apiUrl}/predict`, recommendationData);
}
}
