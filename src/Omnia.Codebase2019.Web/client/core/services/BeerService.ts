import { Inject, HttpClientConstructor, HttpClient, Injectable } from '@omnia/fx';
import { IHttpApiOperationResult, InstanceLifetimes, GuidValue, Guid, EnterprisePropertyDefinition, User } from '@omnia/fx-models';
import { CodeBaseService, BasicBeer } from '../../models';

@Injectable({ lifetime: InstanceLifetimes.Transient })
export class BeerService {

    @Inject<HttpClientConstructor>(HttpClient, { configPromise: HttpClient.createOmniaServiceRequestConfig(CodeBaseService.Id) })
    private httpClient: HttpClient;

    private readonly baseUrl = "api";

    public order = <T extends BasicBeer>(beerToOrder: T): Promise<T> => {

        return new Promise<T>((resolve, reject) => {

            this.httpClient.post<IHttpApiOperationResult<T>>(this.baseUrl + "/orders", beerToOrder).then((response) => {

                if (response.status == 200) {
                    if (response.data.success) {
                        resolve(response.data.data);
                    } else {
                        reject(response.data.errorMessage)
                    }
                } else {
                    reject(response.statusText);
                }

            }).catch(reject);
        });
    }

    public getUserOrders = (user: User): Promise<Array<BasicBeer>> => {
        return new Promise<Array<BasicBeer>>((resolve, reject) => {

            this.httpClient.get<IHttpApiOperationResult<Array<BasicBeer>>>(this.baseUrl + "/orders/" + user.id).then((response) => {

                if (response.status == 200) {
                    if (response.data.success) {
                        resolve(response.data.data);
                    } else {
                        reject(response.data.errorMessage)
                    }
                } else {
                    reject(response.statusText);
                }

            }).catch(reject);
        });
    }

    public getAllOrders = (): Promise<{ [userId: string]: Array<BasicBeer>}> => {
        return new Promise<{ [userId: string]: Array<BasicBeer> }>((resolve, reject) => {

            this.httpClient.get<IHttpApiOperationResult<{ [userId: string]: Array<BasicBeer> }>>(this.baseUrl + "/orders").then((response) => {

                if (response.status == 200) {
                    if (response.data.success) {
                        resolve(response.data.data);
                    } else {
                        reject(response.data.errorMessage)
                    }
                } else {
                    reject(response.statusText);
                }

            }).catch(reject);
        });
    }

    public getAvailable = (): Promise<Array<BasicBeer>> => {
        return new Promise<Array<BasicBeer>>((resolve, reject) => {
            this.httpClient.get<IHttpApiOperationResult<Array<BasicBeer>>>(this.baseUrl + "/available").then((response) => {

                if (response.status == 200) {
                    if (response.data.success) {
                        resolve(response.data.data);
                    } else {
                        reject(response.data.errorMessage)
                    }
                } else {
                    reject(response.statusText);
                }

            }).catch(reject);
        });
    }

}