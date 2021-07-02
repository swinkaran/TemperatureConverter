import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { ITemperature } from './temperature';

@Injectable({
    providedIn: 'root'
  })
  export class TemperatureService {
    private temperatureUrl = 'https://localhost:44353/api/temperature/Celsius/5';
  
    constructor(private http: HttpClient) { }
  
    // Get all temperatures
    gettemperatures(): Observable<ITemperature[]> {
      return this.http.get<ITemperature[]>(this.temperatureUrl)
        .pipe(
          tap(data => console.log('All: ', JSON.stringify(data))),
          catchError(this.handleError)
        );
    }
  
    // Get one temperature
    gettemperature(id: string): Observable<ITemperature | undefined> {
      return this.gettemperatures()
        .pipe(
          map((temperatures: ITemperature[]) => temperatures.find(p => p.temperatureId === id))
        );
    }

    // Get one temperature
    gettemperatureByMetric(metric: string, value : number ): Observable<ITemperature[] | undefined> {
        const url = `https://localhost:44353/api/temperature/${metric}/${value}`;
        console.log("look for url : " + url)
        return this.http.get<ITemperature[]>(url)
          .pipe(
            tap(data => console.log('All: ', JSON.stringify(data))),
            catchError(this.handleError)
          );
      }

    private handleError(err: HttpErrorResponse): Observable<never> {
      let errorMessage = '';
      if (err.error instanceof ErrorEvent) {
        errorMessage = `An error occurred: ${err.error.message}`;
      } else {
        errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
      }
      console.error(errorMessage);
      return throwError(errorMessage);
    }
  
  }
  