import { Bottle } from "../models/bottle/bottle";

export const additionReducer = (accumulator: Bottle, currentValue: Bottle): Bottle => {
    return {capacity: 0, price: accumulator.price + currentValue.price} as Bottle;
};