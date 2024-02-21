# Sytner.Utilities

## Overview
The class library provided here is a cut down version of some of the internal NuGet package's used within Sytner. 

This will provide a taste of the common code used by Sytner. 

## Contents
- [Domain](#Domain)
- [Providers](#Providers)
- [Service Result](#Service%20Result)
- [Extensions](#Extensions)

## Domain
The domain entities are common interfaces and base classes, which are frequently used across Sytner for database entities. 

## Providers
Providers typically encapsulate the creation of information provided by the system. The primary purpose is to make these controllable from a unit testing point of view. 

## Service Result
### Returning a Service Result
The Service Result provides a common wrapper when returning a response, usually from a service. 

This is used commonly within Sytner projects, and is typically used via extensions. 

For example a successful response would return:  
`return ServiceResult<IEnumerable<WeatherForecast>>.Success(data)`

In the event of user error, we can respond accordingly:  
`return ServiceResult<IEnumerable<WeatherForecast>>.InvalidInput("The location provided does not exist")`

In the event of a server error, we use the service result to surface the issue, without having to throw an exception:  
`return ServiceResult<IEnumerable<WeatherForecast>>.InternalError("There was a problem getting data for your location")`

There are two variations of the Service Result:  
1) The ServiceResult<T>, which encapsulates a response of type T.
2) The ServiceResult, which has no content.

### Using a Service Result
To consume a service result, we would normally check if the result was successful using `IsSuccessful`, and access the wrapped object through `Content`:
``` csharp
ServiceResult<IList<ThirdPartyProduct>> allProductsResult = await GetAllProductsAsync();
if (allProductsResult.IsSuccessful)
{
    var productList = allProductsResult.Content;
    /// Consume the product list, perhaps convert to a DTO.
}
```

## Extensions
The controller can use the `ServiceResultToActionResult` extension, to convert a `ServiceResult` into an `IActionResult`.  
`return this.ServiceResultToActionResult(serviceResult);`

When handling failures, we can use the `ToType` extension to convert the ServiceResult's type. This allows us to bubble up an issue with minimal effort.
``` csharp
ServiceResult<IList<ThirdPartyProduct>> allProductsResult = await GetAllProductsAsync();
if (!allProductsResult.IsSuccessful)
{
    return allProducts.ToType<IList<ProductDto>>();
}

```