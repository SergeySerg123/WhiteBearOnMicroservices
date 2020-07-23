import { ProductBrand } from '../productBrand/product-brand.model';

export interface ProductType {
    id: string;
    name: string;
    brands: ProductBrand[];
}