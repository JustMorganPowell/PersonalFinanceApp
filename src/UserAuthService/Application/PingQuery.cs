using MediatR;

namespace UserAuthService.Application;

public record PingQuery() : IRequest<string>;
