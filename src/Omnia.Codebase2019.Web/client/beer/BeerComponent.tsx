import Vue from 'vue';
import { Component, Watch, Prop } from 'vue-property-decorator';
import { vueCustomElement, IWebComponentInstance, WebComponentBootstrapper, Localize, Inject, OmniaContext } from "@omnia/fx";
import { IBeerComponent, BeerComponentData } from './IBeerComponent';
import { BeerComponentStyles } from './BeerComponent.css';
import { VBtn } from '@omnia/fx/ux/vuetify';
import { BasicBeer, BeerType } from '../models';
import { OmniaTheming } from '@omnia/fx/ux';
import { BeerService } from '../core/services/BeerService';

@Component
export default class BeerComponent extends Vue implements IWebComponentInstance, IBeerComponent {

    @Prop({ default: false }) required: boolean;

    @Inject(BeerService) private beerService: BeerService;
    @Inject(OmniaTheming) private omniaTheming: OmniaTheming;
    @Inject(OmniaContext) private omniaCtx: OmniaContext;

    private selectedBeer: BasicBeer;
    private availableBeers: Array<BasicBeer> = [];
    private orderedBeers: Array<BasicBeer> = [];

    created() {
        this.beerService.getAvailable().then((avail) => {
            this.availableBeers = avail;
        });
        this.beerService.getAllOrders().then(async (all) => {
            
            let user = await this.omniaCtx.user;
            if (all[user.id]) {
                this.orderedBeers = all[user.id];
            }

        });

    }

    mounted() {
        WebComponentBootstrapper
            .registerElementInstance(this, this.$el);
    }

    private orderBeer() {
        this
            .beerService
            .order(this.selectedBeer).then((orderedBeer) => {
                this.orderedBeers.push(orderedBeer);
            });
    }

    render(h) {
        return (
            <div class={BeerComponentStyles.container}>
                <div>
                    <v-select
                        box
                        dark={this.omniaTheming.promoted.body.dark}
                        item-value="id"
                        item-text="brand"
                        items={this.availableBeers}
                        v-model={this.selectedBeer}
                        label="Select Beer"
                        return-object
                        onChange={(o) => { console.dir(this.selectedBeer); }}>
                    </v-select>

                    <VBtn onClick={() => { this.orderBeer() }}>
                        Order
                    </VBtn>
                </div>
                <div>Ordered beers</div>
                {  
                        this.orderedBeers.map((beer) => {
                            return <div>
                                {beer.brand}
                            </div>
                        })
                }
            </div>
        )
    }
}

WebComponentBootstrapper.registerElement((manifest) => {
    vueCustomElement(manifest.elementName, BeerComponent);
});