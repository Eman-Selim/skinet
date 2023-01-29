import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Ipagination } from './models/pagination';
import { Iproduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  Products:Iproduct[];
  constructor(private http:HttpClient){

  }
  ngOnInit(): void {
    this.http.get('http://localhost:5100/api/Products?PageSize=5').subscribe(
      (Response: Ipagination)=>{
      this.Products=Response.data;
    },error=>{
      console.log(error);
    });
  }
  
}
