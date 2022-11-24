using Google.Protobuf.Reflection;
using GrpcEnumTranscoding;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddGrpc(opt => { opt.EnableDetailedErrors = true; })
    .AddJsonTranscoding(opt =>
        opt.TypeRegistry = TypeRegistry.FromFiles(Example.Country.CountryReflection.Descriptor));
services.AddGrpcReflection();
services.AddGrpcSwagger();
services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGrpcService<HelloGrpcService>();
app.MapGrpcReflectionService();
app.MapGet("/", () => "Use /swagger to view the API");

app.Run();