import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ipagination } from '../shared/models/pagination';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl='https://localhost:5100/api'

  constructor(private http: HttpClient) { }
  getProduct(){
    return this.http.get<Ipagination>(this.baseUrl+'Products?PageSize=50');    
  }

  getBrands(){
    return this.http.get<Brand[]>(this.baseUrl+'products/brands');
  }

  getTypes(){
    return this.http.get<Type[]>(this.baseUrl+'products/types');
  }
}
