using Grpc.Core;

namespace GrpcService.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<MyResponse> MyMethod(MyRequest request, ServerCallContext context)
    {
        _logger.LogInformation("The values are {Id} and {Value}", request.Id, request.Value);

        return Task.FromResult(new MyResponse
        {
            Id = request.Id,
        });
    }

}
