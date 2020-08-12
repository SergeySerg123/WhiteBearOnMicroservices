import { CardItem } from './card-item';

export interface Card {
    items: CardItem[];
    totalPrice: number;
}

export const initialCardState: Card = {
    items: [],
    totalPrice: 0
}