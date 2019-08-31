//import Vue from 'vue';
//import { Component, Watch, Prop } from 'vue-property-decorator';
//import { vueCustomElement, IWebComponentInstance, WebComponentBootstrapper, Localize, Inject } from "@omnia/fx";
//import { IBeerComponent, BeerComponentData } from './IBeerComponent';
//import { BeerComponentStyles } from './BeerComponent.css';
//import { BeerStore } from '../core/stores';
//import { VBtn } from '@omnia/fx/ux/vuetify';
//import { BasicBeer, BeerType } from '../models';
//import { OmniaTheming } from '@omnia/fx/ux';

//@Component
//export default class BeerComponent extends Vue implements IWebComponentInstance, IBeerComponent {

//    @Prop({ default: false }) required: boolean;

//    @Inject(BeerStore) private beerStore: BeerStore;
//    @Inject(OmniaTheming) private omniaTheming: OmniaTheming;

//    private selectedBeer: BasicBeer;

//    created() {
//        this
//            .beerStore
//            .actions
//            .loadOrders
//            .dispatch();

//        this
//            .beerStore
//            .actions
//            .loadAvailable
//            .dispatch();
//    }

//    mounted() {
//        WebComponentBootstrapper
//            .registerElementInstance(this, this.$el);
//    }

//    private orderBeer() {
//        this
//            .beerStore
//            .actions
//            .order
//            .dispatch(this.selectedBeer);
//    }

//    render(h) {
//        return (

//            <div class={BeerComponentStyles.container}>
//                <div>
//                    <div class="d-inline-block" style="width: 300px;">
//                        <v-select
//                            dark={this.omniaTheming.promoted.body.dark}
//                            item-value="id"
//                            item-text="brand"
//                            items={this.beerStore.getters.getAvailable()}
//                            v-model={this.selectedBeer}
//                            label="Select Beer"
//                            return-object
//                            onChange={(o) => { console.dir(this.selectedBeer); }}>
//                        </v-select>
//                    </div>
//                    <div class="d-inline-block">
//                        <VBtn flat onClick={() => { this.orderBeer() }}>
//                            Order
//                    </VBtn>
//                    </div>
//                </div>
//                <div>Ordered beers</div>
//                {
//                    this.beerStore.getters.getUserOrders() ?
//                        this.beerStore.getters.getUserOrders().map((beer) => {
//                            return <div>
//                                {beer.brand}
//                            </div>
//                        }) :
//                        null
//                }
//            </div>
//        )
//    }
//}

//WebComponentBootstrapper.registerElement((manifest) => {
//    vueCustomElement(manifest.elementName, BeerComponent);
//});