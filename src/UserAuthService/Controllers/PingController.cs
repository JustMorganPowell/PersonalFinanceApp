using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using UserAuthService.Application;
using UserAuthService.Domain;
using UserAuthService.Infrastructure.Mapping;

namespace UserAuthService.Controllers;   // file‑scoped namespace

[ApiController]
[Route("api/[controller]")]
public class PingController : ControllerBase
{
    // ─── private fields ───
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PingController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;   // field names MUST match
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var msg = await _mediator.Send(new PingQuery());
        var domain = new User(Guid.NewGuid(), "alice@example.com");
        var dto = _mapper.Map<UserDto>(domain);

        return Ok(new { msg, dto });
    }
}
