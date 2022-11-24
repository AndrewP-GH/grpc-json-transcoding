using Example.Hello;
using Grpc.Core;

namespace GrpcEnumTranscoding;

public class HelloGrpcService : HelloService.HelloServiceBase
{
    public override Task<SayResponse> Say(SayRequest request, ServerCallContext context) =>
        Task.FromResult(new SayResponse
        {
            Message = $"Hello {request.Name}!",
            Country = request.Country
        });
}