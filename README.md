# aspnetcore-custom-exception-middleware
various ways to handle exceptions globally in asp.net core web api 

## middleware
In the context of a HTTP request pipeline, middleware is also commonly referred to as _request delegates_, which are orchestrated using `Run, Use and Map`. Using `Run` will immediately short circuit the request pipeline

### 01-inline middleware
### 02-middleware in a class
