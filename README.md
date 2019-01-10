# aspnetcore-custom-exception-middleware
various ways to handle exceptions globally in asp.net core web api 

## using middleware
* done using <code>Map, Use, Run</code>
* using <code>Run</code> will immediately short circuit the request pipeline

### 001-inline middleware
