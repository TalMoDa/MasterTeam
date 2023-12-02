using DreamTeam.Application.Common.Interfaces;

namespace DreamTeam.Application.Users.Queries.GetUser;

public record GetUserQuery(Guid Id) : IRequest<UserDto>;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
       var user = _context.Users.FirstOrDefault(u => u.Id == request.Id);
       
       Guard.Against.Null(user, nameof(user), "User not found");
       
       return Task.FromResult(_mapper.Map<UserDto>(user));
        
    }
}

