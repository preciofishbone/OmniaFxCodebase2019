import { TsxAllowUnknowProperties } from '@omnia/fx/ux'

export interface BeerComponentData {
    title: string;
}

/*@WebComponentInterface("codebase-beer")*/
export interface IBeerComponent {

    required: boolean;

    /*@DomProperty*/
    data?: BeerComponentData;
}

declare global {
    namespace JSX {
        interface Element { }
        interface ElementClass { }
        interface ElementAttributesProperty { }
        interface IntrinsicElements {
            /*@WebComponent*/
            "codebase-beer": TsxAllowUnknowProperties<IBeerComponent>
        }
    }
}