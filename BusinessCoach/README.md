# BusinessCoach Payload Codegen

Questo repository include una semplice classe DTO (`DeleteBillDto`) e una Entity (`BillDeletion`) per il caso noto di cancellazione fatture:

```json
{"externalId":"164934","billDateTime":"0001-01-01T00:00:00"}
```

Per generare automaticamente DTO/Entity da un payload JSON più ampio, popola `BusinessCoach/payload.json` con un esempio reale e comunica che vuoi procedere: aggiungerò un piccolo generatore che analizzerà lo schema e produrrà i file in `DocumentsTransformator/Dtos/BusinessCoach` e `DocumentsTransformator/Entities/BusinessCoach`.

Note:
- I DTO vengono modellati come `record` immutabili.
- Le Entity sono POCO con proprietà settabili.
- La convenzione di naming è PascalCase per le proprietà a partire da chiavi JSON camelCase.

