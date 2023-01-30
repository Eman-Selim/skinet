import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ipagination } from '../models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl='https://localhost:5100/api'

  constructor(private http: HttpClient) { }
  getProduct(){
    return this.http.get<Ipagination>(this.baseUrl+'Products?PageSize=50');

    
  }
}
