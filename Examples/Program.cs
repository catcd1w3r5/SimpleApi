// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using SimpleApi;

var builder = WebApplication.CreateBuilder(args);

var settings = new SimpleApiSettings()
{
    ActiveAssemblies =
    {
        Assembly.GetExecutingAssembly()
    }
};

var app = builder.Build(settings);
app.Run();