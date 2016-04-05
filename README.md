# NancyFx Idempotent Request Sample

 Attach a unique key to any POST,PUT request made to the API via the Idempotency-Key: <key> header.
 
 ```csharp
 
//with idempotency key should not create additional entity
var idempotencyKey = Guid.NewGuid().ToString();
RequestOptions.Instance.SetIdempotencyKey(idempotencyKey);

DummyMessage message = client.Post<DummyMessage>(request);
DummyMessage message2 = client.Post<DummyMessage>(request);


//without idempotency key should  create additional entity
RequestOptions.Instance.SetIdempotencyKey(string.Empty);

DummyMessage message = client.Post<DummyMessage>(request);
DummyMessage message2 = client.Post<DummyMessage>(request);
 
 ```


