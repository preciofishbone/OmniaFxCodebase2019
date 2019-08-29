import Vue from 'vue';
import { Component, Watch, Prop } from 'vue-property-decorator';
import { vueCustomElement, IWebComponentInstance, WebComponentBootstrapper, Localize, Inject } from "@omnia/fx";
import { IBeerComponent, BeerComponentData } from './IBeerComponent';
import {BeerComponentStyles} from './BeerComponent.css';

@Component
export default class BeerComponent extends Vue implements IWebComponentInstance, IBeerComponent {

    @Prop({ default: false }) required: boolean;
    @Prop({ default: { title: 'Hello from BeerComponent!' } }) data?: BeerComponentData

    mounted() {

        WebComponentBootstrapper
            .registerElementInstance(this, this.$el);

    }

    render(h) {
        return (
            <div class={BeerComponentStyles.container}>
                <div>{this.data.title}</div>
                {this.required ? <div>Im required</div> : null}
            </div>
        )
    }
}

WebComponentBootstrapper.registerElement((manifest) => {
    vueCustomElement(manifest.elementName, BeerComponent);
});