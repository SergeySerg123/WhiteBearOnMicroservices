import { ProductType } from '../productType/product-type.model';

export interface CategoryItem {
    id: string;
    name: string;
    types: ProductType[];
}