# NancyFx Idempotent Request Sample

  Generates HTTP  [ETag]( https://en.wikipedia.org/wiki/HTTP_ETag)   unique key for prevent duplicate request to any POST,PUT request 

 
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


