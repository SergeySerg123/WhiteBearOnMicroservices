import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HttpInternalService {
  public headers = new HttpHeaders();

  constructor(private http: HttpClient) {}

  public getHeaders(): HttpHeaders {
    return this.headers;
  }

  public getHeader(key: string): string {
    return this.headers[key];
  }

  public setHeader(key: string, value: string): void {
    this.headers[key] = value;
  }

  public deleteHeader(key: string): void {
    delete this.headers[key];
  }

  public getFullRequest<T>(url: string, httpParams?: HttpParams): Observable<HttpResponse<T>> {
    return this.http.get<T>(url, { 
      observe: 'response', 
      responseType: 'json', 
      params: httpParams 
    });
  }

  public postFullRequest<T>(url: string, data: any, httpParams?: HttpParams) : Observable<HttpResponse<T>> {
    return this.http.post<T>(url, data, {
      observe: 'response',
      responseType: 'json',
      params: httpParams
    });
  }

  public putFullRequest<T>(url: string, data: any, httpParams?: HttpParams): Observable<HttpResponse<T>> {
    return this.http.put<T>(url, data, {
      observe: 'response',
      responseType: 'json',
      params: httpParams
    });
  }

  public deleteFullRequest<T>(url: string, httpParams?: HttpParams): Observable<HttpResponse<T>> {
    return this.http.delete<T>(url, {
      params: httpParams, 
      observe: 'response', 
      responseType: 'json'
    });
  }
}
