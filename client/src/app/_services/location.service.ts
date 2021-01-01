import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Locations } from '../_models/locations';
import { Location } from '../_models/location';
import { LocationEdit } from '../_models/locationedit';

@Injectable({
  providedIn: 'root',
})
export class LocationService {
  baseUrl = environment.apiUrl;
  cities: any[];

  constructor(private http: HttpClient) {}

  list() {
    return this.http.get<Locations[]>(this.baseUrl + 'location');
  }

  detail(id: number) {
    return this.http.get<any>(this.baseUrl + `location/${id}`);
  }

  create(model: any) {
    return this.http.post(this.baseUrl + 'location', model).pipe(
      map((response: Location) => {
        console.log(response);
      })
    );
  }

  edit(id: number, model: any) {
    return this.http.put(this.baseUrl + `location/${id}`, model).pipe(
      map((response: any) => {
        console.log(response);
      })
    );
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + `location/${id}`).pipe(
      map((response: any) => {
        console.log(response);
      })
    );
  }

  getCities() {
    // if (this.cities.length > 0) return of(this.cities);
    return this.http.get<any[]>(this.baseUrl + 'city').pipe(
      map((response) => {
        this.cities = response;
        return response;
      })
    );
  }
}
