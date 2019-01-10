# aspnetcore-custom-exception-middleware
various ways to handle exceptions globally in asp.net core web api 

## middleware
In the context of a HTTP request pipeline, middleware is also commonly referred to as _request delegates_, which are orchestrated using __Run, Use and Map__
* done using <code>Map, Use, Run</code>
* using <code>Run</code> will immediately short circuit the request pipeline

### 001-inline middleware
