import { Category } from '../category/category';
import { Brand } from '../brand/brand';
import { Reaction } from '../reaction/reaction';

export interface Product {
    id: string;
    name: string;
    description: string;
    discount?: number;
    price: number; 
    beerType: number; 
    density: number;
    previewImg: string;
    raiting: number;
    category: Category;
    brand: Brand;
    reactions: Reaction[];
}