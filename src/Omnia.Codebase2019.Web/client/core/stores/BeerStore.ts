import { Store } from '@omnia/fx/store';
import { Injectable, Inject, OmniaContext } from '@omnia/fx';
import { InstanceLifetimes, OmniaUserContext } from '@omnia/fx-models';
import { BasicBeer, BeerType } from '../../models';
import { BeerService } from '../services/BeerService';

@Injectable({
    onStartup: (storeType) => { Store.register(storeType, InstanceLifetimes.Scoped) }
})
export class BeerStore extends Store
{
    @Inject(BeerService) private beerService: BeerService;
    @Inject(OmniaContext) private omniaCtx: OmniaContext;

    private currentUser: OmniaUserContext;
    private beerOrdersState = this.state<{ [userId: string]: Array<BasicBeer> }>({});
   
    constructor()
    {
        super({
            id: "7261777c-2b9d-4831-b271-46b4b1248a4a"
        });
    }

    async onActivated()
    {
        this.currentUser = await this.omniaCtx.user;
        this.beerOrdersState.state[this.currentUser.id] = [];
        console.dir(this.currentUser.id);
    }

    onDisposing()
    {
        //Called when the store is disposed, do some cleanup here
    }

    /**
    * Implementation of getters
    */
    getters = {
        getOrdersByUserId: (userId: string) => {
            return this.beerOrdersState.state[userId];
        },
        getUserOrders: () => {
            return this.beerOrdersState.state[this.currentUser.id];
        }
    }

    /**
     * Implementation of mutations
     */
    mutations = {
        //orderBeer: (userName: string, newBeer: BasicBeer) => {
        //    this.beerOrders.mutate((beers) => {
        //        beers.state.push(newBeer);
        //    });
        //}
    }
    /**
     * Implementation of actions
     */
    actions = {
        loadOrders: this.action(() => {
            return new Promise<null>(async (resolve, reject) => {
                let orders = await this.beerService.getAllOrders();
                this.beerOrdersState.mutate(orders);
                Promise.resolve(null);
            });
        }),
        order: this.action((beerToOrder: BasicBeer) => {
            return new Promise<null>(async (resolve, reject) => {
                
                let orderedBeer = await this.beerService.order(beerToOrder);
                let user = await this.omniaCtx.user;

                console.dir(user.id);

                this.beerOrdersState.mutate((orders) => {
                    console.dir(user.id);
                    console.dir(orders);

                   // orders.state[user.id].push(orderedBeer);
                })

                Promise.resolve(null);

            });
        })
    }

}

