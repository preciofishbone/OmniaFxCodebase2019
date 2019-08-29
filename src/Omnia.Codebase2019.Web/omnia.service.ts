import { Composer, DevelopmentEnvironment } from "@omnia/tooling/composers";
import { Guid } from '@omnia/fx/models';

Composer
    .registerManifest(new Guid("c79622bf-3341-4f2f-a8c6-579c2dc3fb5c"), "Omnia.Codebase2019")
    .registerService({ description: "Description of Omnia.Codebase2019" })
    .AsWebApp()
    .withBuildOptions({
        include: ["client"],
        moduleOptions: {
            enableTransformResourcePath: true
        },
        bundleOptions: {
            commonsChunk: {
                name: new Guid("81c58f25-8fe9-46f4-a7c8-9d7fb70f4da1"),
                minChunks: 2
            }
        }
    }).requestSqlDatabase({
        //Specify your own unique id, later used as reference to the DB generated for you.
        uniqueId: new Guid("f8debb44-be08-4ae2-9cf5-c1cebc839123")
    });
    
   