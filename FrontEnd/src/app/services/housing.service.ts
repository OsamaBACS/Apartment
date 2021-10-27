import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Property } from '../model/property';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class HousingService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  getAllCities(): Observable<string[]>{
    // return this.http.get<string[]>('http://localhost:5000/api/City');
    return this.http.get<string[]>(this.baseUrl + '/City/cities');
  }

  getProperty(Id: number){
    return this.http.get<Property>(this.baseUrl + '/property/detail/' + Id);
    // return this.getAllProperties(1).pipe(
    //   map(propertiesArray => {
    //     let propArray = propertiesArray.find((p) => p.id === Id);
    //     if(propArray === undefined) throw new Error('Some Error');

    //     return propArray;
    //   })
    // );
  }

  getAllProperties(SellRent?: number): Observable<Property[]> {
    return this.http.get<Property[]>(this.baseUrl + '/property/list/' + SellRent?.toString());
    // return this.http.get('data/properties.json').pipe(
    //   map((data: any) => {
    //     const propertiesArray: Array<Property> = [];
    //     const localProperties = JSON.parse(localStorage.getItem('newProp')!);
    //     if(localProperties){
    //       for (var id in localProperties) {
    //         if(SellRent){
    //           if (
    //             localProperties.hasOwnProperty(id) &&
    //             localProperties[id].SellRent === SellRent
    //           ) {
    //             propertiesArray.push(localProperties[id]);
    //           }
    //         } else {
    //           propertiesArray.push(localProperties[id]);
    //         }
    //       }
    //     }

    //     for (var id in data) {
    //       if (SellRent){
    //         if (data.hasOwnProperty(id) && data[id].SellRent === SellRent) {
    //           propertiesArray.push(data[id]);
    //         }
    //       } else {
    //         propertiesArray.push(data[id]);
    //       }
    //     }
    //     return propertiesArray;
    //   })
    // );
  }
  addProperty(property: Property) {
    let newProp = [property];
    if(localStorage.getItem('newProp')){
      newProp = [property, ...JSON.parse(localStorage.getItem('newProp')!)];
    }
    localStorage.setItem('newProp', JSON.stringify(newProp));
  }

  newPropId(){
    if(localStorage.getItem('PID')){
      localStorage.setItem('PID', String(+localStorage.getItem('PID')! + 1));
      return +localStorage.getItem('PID')!;
    } else {
      localStorage.setItem('PID', '101');
      return 101;
    }
  }

  getPropertyAge(dateOfEstablishment: Date): string
  {
    const today = new Date();
    const estDate = new Date(dateOfEstablishment);
    let age = today.getFullYear() - estDate.getFullYear();
    const m = today.getMonth() - estDate.getMonth();

    // Current month smaller than establishment month or
    // Same month but current date smaller than establishment date
    if(m < 0 || (m === 0 && today.getDate() < estDate.getDate()))
    {
      age--;
    }

    // Establishment date is future date
    if(today < estDate)
      return '0';

    // Age less than a year
    if(age === 0)
      return 'Age is less than a year';

    return age.toString();
  }
}
