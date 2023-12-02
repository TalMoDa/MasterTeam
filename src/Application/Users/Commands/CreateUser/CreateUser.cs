using DreamTeam.Application.Common.Interfaces;
using DreamTeam.Application.Users.Queries.GetUser;
using DreamTeam.Domain.Entities;

namespace DreamTeam.Application.Users.Commands.CreateUser;

public record CreateUserCommand(UserDto User) : IRequest<UserDto>;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.User);

        _context.Users.Add(user);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserDto>(user);
    }
}
