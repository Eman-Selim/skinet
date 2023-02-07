import { Component, OnInit } from '@angular/core';
import { Iproduct } from '../shared/models/product';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products:Iproduct[];
  constructor(private shopService:ShopService) { }

  ngOnInit(): void {
    
  }
  getProducts(){
    this.shopService.getProduct().subscribe(Response=>{
      this.products=Response.data;
    },error=>{
      console.log(error);
    })
  }
  getBrands(){
    this.shopService.getBrands().subscribe(
    next: Response=>{this.products=Response.data,
      error=>console.log(error);
    })
  }

}
