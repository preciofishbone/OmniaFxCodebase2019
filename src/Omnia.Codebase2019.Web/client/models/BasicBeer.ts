export enum BeerType {
    Lager = 0,
    PaleAle = 1
}

export interface BasicBeer {
    type: BeerType;
    brand: string;
}