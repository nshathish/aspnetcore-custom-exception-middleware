# aspnetcore-custom-exception-middleware
various ways to handle exceptions globally in asp.net core web api 

## middleware
In the context of a HTTP request pipeline, middleware is also commonly referred to as _request delegates_, which are orchestrated using `Run, Use and Map`. Using `Run` will immediately short circuit the request pipeline. 
Also you can short circuit the pipeline by not calling `next` parameter.

### 01-inline middleware
### 02-middleware in a class
### 03-simple global exception handling middleware

> Don't call `next.Invoke` after the response has been sent to the client. Changes to __HttpResponse__ after the response has started throw an exception. 
    
For example, changes such as setting headers and a status code throw an exception. Writing to the response body after calling next:
* May cause a protocol violation. For example, writing more than the stated Content-Length.
* May corrupt the body format. For example, writing an HTML footer to a CSS file.
__HasStarted__ is a useful hint to indicate if headers have been sent or the body has been written to.
