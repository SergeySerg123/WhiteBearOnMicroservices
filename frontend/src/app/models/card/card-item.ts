import { Product } from '../product/product';
import { Bottle } from '../bottle/bottle';

export interface CardItem {
    product: Product;
    quantity: number;
    bottles: Bottle[];
    totalBottlesPrice: number;
}