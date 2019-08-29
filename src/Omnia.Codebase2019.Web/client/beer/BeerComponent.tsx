import Vue from 'vue';
import { Component, Watch, Prop } from 'vue-property-decorator';
import { vueCustomElement, IWebComponentInstance, WebComponentBootstrapper, Localize, Inject } from "@omnia/fx";
import { IBeerComponent, BeerComponentData } from './IBeerComponent';
import { BeerComponentStyles } from './BeerComponent.css';
import { BeerStore } from '../core/stores/BeerStore';
import { VBtn } from '@omnia/fx/ux/vuetify';
import { BasicBeer, BeerType } from '../models';

@Component
export default class BeerComponent extends Vue implements IWebComponentInstance, IBeerComponent {

    @Prop({ default: false }) required: boolean;

    @Inject(BeerStore) private beerStore: BeerStore;

    created() {
        this.beerStore.actions.loadOrders.dispatch();
    }

    mounted() {
        WebComponentBootstrapper
            .registerElementInstance(this, this.$el);
    }

    private orderBeer() {
        let beer: BasicBeer = {
            brand: "Corona",
            type: BeerType.Lager
        };
        this.beerStore.actions.order.dispatch(beer);
    }

    render(h) {
        return (
            <div class={BeerComponentStyles.container}>

                <div>
                    <VBtn onClick={() => { this.orderBeer() }}>
                        Order
                    </VBtn>
                </div>
                <div>Ordered beers</div>
                {
                    this.beerStore.getters.getUserOrders() ?
                        this.beerStore.getters.getUserOrders().map((beer) => {
                            return <div>
                                {beer.brand}
                            </div>
                        }) :
                        null
                }

            </div>
        )
    }
}

WebComponentBootstrapper.registerElement((manifest) => {
    vueCustomElement(manifest.elementName, BeerComponent);
});