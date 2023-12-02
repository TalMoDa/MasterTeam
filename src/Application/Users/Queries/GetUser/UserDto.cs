
using DreamTeam.Domain.Entities;

namespace DreamTeam.Application.Users.Queries.GetUser;

public class UserDto
{
    public Guid Id { get; set; }
    
    public int RoleId { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public Guid Creator { get; set; }

    public Guid Modifier { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifyDate { get; set; }

    public DateTime? DeletedDate { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDto>();
        }
    }

}

