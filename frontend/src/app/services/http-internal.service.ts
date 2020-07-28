import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpInternalService {

  constructor(
    private http: HttpClient
  ) { }

  public getFullRequest(url: string) {
    return this.http.get(url, {observe: "response", responseType: 'json'});
  }

  public postFullRequest(url: string, data: any) {
    return this.http.post(url, data, {observe: "response", responseType: 'json'});
  }

  public putFullRequest(url: string, data: any) {
    return this.http.put(url, data, {observe: "response", responseType: 'json'});
  }

  public deleteFullRequest(url: string, data: any) {
    return this.http.delete(url);
  }
}
