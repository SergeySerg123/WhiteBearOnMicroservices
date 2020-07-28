import { Injectable } from '@angular/core';
import { HttpInternalService } from './http-internal.service';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private baseUrl = environment.catalogApiUrl;

  constructor(
    private httpService : HttpInternalService
  ) { }

  public getProducts() {
    return this.httpService.getFullRequest(this.baseUrl + '/api/products/items');
  }
}
