import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Favorite } from '../models/favorite';

@Injectable({
  providedIn: 'root'
})
export class RestaurantFavsService {

  url:string = "http://localhost:5226/api/Favorite";

  constructor(private Http:HttpClient) { }

  getAllRestos():Observable<Favorite[]> {
    return this.Http.get<Favorite[]> (this.url);
  }

  addFavorites(order:Favorite):Observable<Favorite> {
    return this.Http.post<Favorite> (this.url, order);
  }

  deleteFavorite(id:number):Observable<void> {
    return this.Http.delete<void> (this.url) // TODO: find out the path param to interpolate 
  }
}
