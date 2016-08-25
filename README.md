# NancyFx Idempotent Request Sample

[![Build status](https://ci.appveyor.com/api/projects/status/iwspcowhfy458nqr?svg=true)](https://ci.appveyor.com/project/serdardemir/nancy-idempotentrequest)

Generates HTTP  [ETag]( https://en.wikipedia.org/wiki/HTTP_ETag)   unique key for prevent duplicate request to any POST,PUT request 


```csharp

protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
{
	base.ApplicationStartup(container, pipelines);

	pipelines.BeforeRequest += CheckCache;

	pipelines.AfterRequest += SetCache;
}

public Response CheckCache(NancyContext context)
public void SetCache(NancyContext context)

//Generating Entity Tag
var etag = EntityFilterHelper.GenerateETag(context.Request.Body);

```


