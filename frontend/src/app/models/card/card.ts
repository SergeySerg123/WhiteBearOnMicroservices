import { CardItem } from './card-item';

export interface Card {
    items: CardItem[];
}

export const initialCardState: Card = {
    items: []
}