import { Product } from '../product/product';

export interface QuantityChanger {
    product: Product;
    quantity: number;
}