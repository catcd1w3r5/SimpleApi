using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SimpleApi;

namespace Examples;

public class InterfaceEndpoint : IEndpointInterface
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => Results.Ok(DateTime.Now));
        app.MapGet("/{id}", (string id) => Results.Ok("ID" + id));
        app.MapGet("/user", () => Results.Ok("User"));
    }
}