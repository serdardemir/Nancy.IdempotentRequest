# NancyFx Idempotent Request Sample

 Attach a unique key to any POST,PUT request made to the API via the Idempotency-Key: <key> header.
 
 ```csharp
var idempotencyKey = Guid.NewGuid().ToString();

//with idempotency key should not create additional entity
RequestOptions.Instance.SetIdempotencyKey(idempotencyKey);



//without idempotency key should  create additional entity
RequestOptions.Instance.SetIdempotencyKey(string.Empty); 
 
 
 ```


