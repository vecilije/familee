using Familee.Domain.Dtos;
using Familee.Domain.Entities;
using MediatR;

namespace Familee.Application.UseCases.AddFamilyMember
{
    public class AddFamilyMemberRequest : IRequest<FamilyMemberDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string ImagePath { get; set; }
    }
}