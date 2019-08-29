import { Composer } from '@omnia/tooling/composers';
import { Guid } from '@omnia/fx/models';

Composer
    .registerManifest(new Guid("79597847-6f4f-4560-a5c4-eff26c95e948"), "BeerComponent")
    .registerWebComponent({
        elementName: "codebase-beer",
        entryPoint: "./BeerComponent.jsx",
        typings: ["./IBeerComponent.ts"]
    });