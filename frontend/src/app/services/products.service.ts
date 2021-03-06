import { Injectable } from '@angular/core';
import { HttpInternalService } from './http-internal.service';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product/product';
import { HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private baseUrl = environment.catalogApiUrl;

  constructor(
    private httpService : HttpInternalService
  ) { }

  public getProducts(): Observable<HttpResponse<any>> {
    return this.httpService.getFullRequest(this.baseUrl + '/api/products/items');
  }

  public getProduct(id: string): Observable<HttpResponse<any>> {
    return this.httpService.getFullRequest(this.baseUrl + '/api/products/items/' + id);
  }

  public createProduct(product: Product): Observable<HttpResponse<any>> {
    return this.httpService.postFullRequest(this.baseUrl + '/api/products/items', product);
  }

  public updateProduct(product: Product): Observable<HttpResponse<any>> {
    return this.httpService.putFullRequest(this.baseUrl + '/api/products/items', product);
  }

  public deleteProduct(id: string): Observable<HttpResponse<any>> {
    return this.httpService.deleteFullRequest(this.baseUrl + '/api/products/items/' + id);
  }
}
