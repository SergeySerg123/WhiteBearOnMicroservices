import { Brand } from '../brand/brand';

export interface Category {
    id: string;
    name: string;
    brands: Brand[];
}