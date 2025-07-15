using MediatR;

namespace UserAuthService.Application;

public class PingHandler : IRequestHandler<PingQuery, string>
{
    public Task<string> Handle(PingQuery request, CancellationToken ct)
        => Task.FromResult("pong-from-mediatr");
}
